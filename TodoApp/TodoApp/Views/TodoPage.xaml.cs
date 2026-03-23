using TodoApp;

namespace TodoApp.Views;

public partial class TodoPage : ContentPage
{
    public static TodoPage Instance;
    public static List<ToDoClass> tasks = new List<ToDoClass>();

    public TodoPage()
    {
        InitializeComponent();
        Instance = this;
        todoList.ItemsSource = tasks;
    }

    public static void RefreshList()
    {
        if (Instance != null)
        {
            Instance.todoList.ItemsSource = null;
            Instance.todoList.ItemsSource = tasks;
        }
    }

    // Add Task Button
    private async void AddTask_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddTodoPage());
    }

    // Edit Task
    private async void Edit_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var task = button.CommandParameter as ToDoClass;
        await Navigation.PushAsync(new EditTodoPage(task));
    }

    // Delete Task
    private void Delete_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var task = button.CommandParameter as ToDoClass;
        tasks.Remove(task);
        RefreshList();
    }

    // Complete Task
    private void Complete_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var task = button.CommandParameter as ToDoClass;

        task.status = "completed";
        tasks.Remove(task);
        CompletedPage.completedTasks.Add(task);

        RefreshList();
    }
}