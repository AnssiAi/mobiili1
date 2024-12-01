using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace harjoitusi.ViewModels
{
    internal class ExerciseListViewModel: ObservableObject
    {
        private ExerciseViewModel _selectedExercise;

        public ExerciseViewModel SelectedExercise
        {
            get { return _selectedExercise; }
            set => SetProperty(ref _selectedExercise, value);
        }

        public ObservableCollection<ExerciseViewModel> ExerciseList { get; set; }

        public ExerciseListViewModel() => ExerciseList = [];

        public async Task RefreshItems()
        {
            IEnumerable<Models.Exercise> exerciseData = await Models.ExerciseDatabase.GetExercises();

            foreach (Models.Exercise ex in exerciseData)
            {
                ExerciseList.Add(new ExerciseViewModel(ex));
            }
        }

        public void DeleteItem(ExerciseViewModel item) => ExerciseList.Remove(item);

        public void AddItem(ExerciseViewModel item) => ExerciseList.Add(item);

        public async Task SaveItems()
        {
            await Models.ExerciseDatabase.WriteExercises(ExerciseList);
        }

    }
}
