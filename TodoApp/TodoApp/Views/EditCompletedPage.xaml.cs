namespace TodoApp.Views;

public partial class EditCompletedPage : ContentPage
{
    ToDoClass currentTask;

    public EditCompletedPage(ToDoClass task)
    {
        InitializeComponent();

        currentTask = task;

        // Show task name
        taskLabel.Text = task.item_name;
    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Confirm", "Delete this task?", "Yes", "No");

        if (confirm)
        {
            CompletedPage.completedTasks.Remove(currentTask);

            await Navigation.PopAsync();
        }
    }
}