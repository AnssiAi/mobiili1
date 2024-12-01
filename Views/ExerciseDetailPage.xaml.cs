namespace harjoitusi.Views;

public partial class ExerciseDetailPage : ContentPage
{
	public ExerciseDetailPage()
	{
		InitializeComponent();

		BindingContext = App.MainViewModel.SelectedExercise;
	}
}