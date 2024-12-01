namespace harjoitusi.Views;

public partial class ExerciseListPage : ContentPage
{
	public ExerciseListPage()
	{
		InitializeComponent();
	}

    private async void ListViewItem_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        await Navigation.PushAsync(new Views.ExerciseDetailPage());
    }
    private void MenuItem_Clicked(object sender, EventArgs e)
    {
        MenuItem menuItem = (MenuItem)sender;
        ViewModels.ExerciseViewModel item = (ViewModels.ExerciseViewModel)menuItem.BindingContext;
        App.MainViewModel.DeleteItem(item);
    }

    private async void Add_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.AddExercisePage());
    }

    private async void Save_Button_Clicked(object sender, EventArgs e)
    {
        await App.MainViewModel.SaveItems();
    }
}