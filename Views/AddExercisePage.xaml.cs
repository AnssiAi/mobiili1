using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace harjoitusi.Views;

public partial class AddExercisePage : ContentPage
{
    string enteredName;
    string enteredType;
    string enteredTag;
    string enteredTarget;
    ObservableCollection<string> tags = new ObservableCollection<string>();
    ObservableCollection<string> targets = new ObservableCollection<string>();

    public AddExercisePage()
	{
		InitializeComponent();

        tagsList.ItemsSource = tags;
        targetsList.ItemsSource = targets;
	}

    private void Name_Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        enteredName = ((Entry)sender).Text;
    }

    private void Name_Entry_Completed(object sender, EventArgs e)
    {
        enteredName = ((Entry)sender).Text;
    }
    private void Type_Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        enteredType = ((Entry)sender).Text;
    }

    private void Type_Entry_Completed(object sender, EventArgs e)
    {
        enteredType = ((Entry)sender).Text;
    }
    private void Tag_Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        enteredTag = ((Entry)sender).Text;
    }

    private void Tag_Entry_Completed(object sender, EventArgs e)
    {
        enteredTag = ((Entry)sender).Text;
    }
    private void Target_Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        enteredTarget = ((Entry)sender).Text;
    }

    private void Target_Entry_Completed(object sender, EventArgs e)
    {
        enteredTarget = ((Entry)sender).Text;
    }
    private void Add_Tag_Button_Clicked(object sender, EventArgs e)
    {
        tags.Add(enteredTag);
    }
    private void Add_Target_Button_Clicked(object sender, EventArgs e)
    {
        targets.Add(enteredTarget);
    }

    private async void Add_Button_Clicked(object sender, EventArgs e)
    {
        Models.Exercise newItem = new Models.Exercise(App.MainViewModel.ExerciseList.Count() +1 , enteredName, enteredType, tags.ToList(), targets.ToList());
        App.MainViewModel.AddItem(new ViewModels.ExerciseViewModel(newItem));
        await Navigation.PopAsync();
    }

}