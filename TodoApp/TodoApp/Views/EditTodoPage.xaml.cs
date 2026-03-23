namespace TodoApp.Views;

public partial class EditTodoPage : ContentPage
{
    ToDoClass currentTask;
    // ✅ ADD THIS CONSTRUCTOR
    public EditTodoPage(ToDoClass task)
    {
        InitializeComponent();

        currentTask = task;

        // Load data into UI
        taskName.Text = task.item_name;
        taskDescription.Text = task.item_description;
    }

    // SAVE EDIT
    private async void Save_Clicked(object sender, EventArgs e)
    {
        currentTask.item_name = taskName.Text;
        currentTask.item_description = taskDescription.Text;

        await DisplayAlert("Success", "Task updated!", "OK");
        await Navigation.PopAsync();
    }

    // DELETE COMPLETED TASK
    private async void Delete_Clicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Confirm", "Delete this task?", "Yes", "No");

        if (confirm)
        {
            CompletedPage.completedTasks.Remove(currentTask);

            await Navigation.PopAsync();
        }
    }
    private void Complete_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var task = button.CommandParameter as ToDoClass;

        task.status = "completed";

        TodoPage.tasks.Remove(task);
        CompletedPage.completedTasks.Add(task);

        TodoPage.RefreshList();

        Navigation.PopAsync();
    }
}