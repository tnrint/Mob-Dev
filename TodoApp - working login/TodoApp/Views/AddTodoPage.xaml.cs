using System.Formats.Tar;
using TodoApp;

namespace TodoApp.Views;

public partial class AddTodoPage : ContentPage
{
    public AddTodoPage()
    {
        InitializeComponent();
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
        ToDoClass task = new ToDoClass();

        task.item_name = taskName.Text;
        task.item_description = taskDescription.Text;
        task.status = "pending";

        TodoPage.tasks.Add(task);
        TodoPage.RefreshList();
        await Navigation.PopAsync();
    }
}