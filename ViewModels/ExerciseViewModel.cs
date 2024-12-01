using CommunityToolkit.Mvvm.ComponentModel;
using harjoitusi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace harjoitusi.ViewModels
{
    internal class ExerciseViewModel: ObservableObject
    {
        int _id;

        string _name;

        string _type;

        List<string> _tags;

        List<string> _targets;

        public int Id
        {
            get { return _id; }
            set => SetProperty(ref _id, value);
        }
        public string Name
        {
            get { return _name; }
            set => SetProperty(ref _name, value);
        }
        public string Type
        {
            get { return _type; }
            set => SetProperty(ref _type, value);
        }
        public List<string> Tags
        { 
            get { return _tags; } 
            set => SetProperty(ref _tags, value);
        }
        public List<string> Targets
        {
            get { return _targets; }
            set => SetProperty(ref _targets, value);
        }

        public ExerciseViewModel(Exercise exercise)
        {
            _id = exercise.Id;
            _name = exercise.Name;
            _type = exercise.Type;
            _tags = exercise.Tags;
            _targets = exercise.Targets;
        }
    }
}
