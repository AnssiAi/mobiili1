using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace harjoitusi.Models
{
    internal class ExerciseDatabase
    {
        //Task, joka palauttaa valmistuessaan kokoelman Item
        public async static Task<IEnumerable<Exercise>> GetExercises()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "exercises.json");
            try
            {
                if (!File.Exists(filePath))
                {
                    var defaultItems = new List<Exercise>();
                    JsonSerializerOptions writeOptions = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                    };

                    string defaultJson = JsonSerializer.Serialize(defaultItems, writeOptions);

                    await File.WriteAllTextAsync(filePath, defaultJson);
                    return [];
                }
                using FileStream stream = File.OpenRead(filePath);

                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                IEnumerable<Exercise>? result = await JsonSerializer.DeserializeAsync<IEnumerable<Exercise>>(stream, options);
                Console.WriteLine(filePath + "file read successfully");

                return result ?? Enumerable.Empty<Exercise>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A read error occurred: {ex.Message}");
                return [];
            }
        }

        public async static Task WriteExercises(ObservableCollection<ViewModels.ExerciseViewModel> exercises)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(exercises, options);

            string filePath = Path.Combine(FileSystem.AppDataDirectory, "exercises.json");

            try
            {
                using StreamWriter writer = new StreamWriter(filePath);
                await writer.WriteAsync(json);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"I/O error: {ioEx.Message}");
            }
            catch (UnauthorizedAccessException uaEx)
            {
                Console.WriteLine($"Permission error: {uaEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
