using TodoApp;

namespace TodoApp.Views;

public partial class CompletedPage : ContentPage
{
    public static CompletedPage Instance;
    public static List<ToDoClass> completedTasks = new List<ToDoClass>();

    public CompletedPage()
    {
        InitializeComponent();
        Instance = this;
        completedList.ItemsSource = completedTasks;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshList();
    }

    public static void RefreshList()
    {
        if (Instance != null)
        {
            Instance.completedList.ItemsSource = null;
            Instance.completedList.ItemsSource = completedTasks;
        }
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var task = button.CommandParameter as ToDoClass;

        completedTasks.Remove(task);
        RefreshList();
    }
}