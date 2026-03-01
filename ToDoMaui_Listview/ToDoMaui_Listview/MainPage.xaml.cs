namespace ToDoMaui_Listview;
using System.Collections.ObjectModel;
using System.Linq;


public partial class MainPage : ContentPage
{
    ObservableCollection<ToDoClass> todoList = new ObservableCollection<ToDoClass>();

    int currentId = 1;
    ToDoClass selectedItem = null;

    public MainPage()
    {
        InitializeComponent();
        todoLV.ItemsSource = todoList;
    }

    // ADD
    private void AddToDoItem(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(titleEntry.Text) ||
            string.IsNullOrWhiteSpace(detailsEditor.Text))
        {
            DisplayAlert("Error", "Please enter title and details.", "OK");
            return;
        }

        ToDoClass item = new ToDoClass
        {
            id = currentId++,
            title = titleEntry.Text,
            detail = detailsEditor.Text
        };

        todoList.Add(item);

        titleEntry.Text = "";
        detailsEditor.Text = "";
    }

    // SELECT ITEM
    private void TodoLV_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        selectedItem = e.SelectedItem as ToDoClass;

        titleEntry.Text = selectedItem.title;
        detailsEditor.Text = selectedItem.detail;

        addBtn.IsVisible = false;
        editBtn.IsVisible = true;
        cancelBtn.IsVisible = true;
    }

    // EDIT
    private void EditToDoItem(object sender, EventArgs e)
    {
        if (selectedItem == null)
            return;

        selectedItem.title = titleEntry.Text;
        selectedItem.detail = detailsEditor.Text;

        CancelEdit(null, null);
    }

    // CANCEL
    private void CancelEdit(object sender, EventArgs e)
    {
        titleEntry.Text = "";
        detailsEditor.Text = "";

        selectedItem = null;

        addBtn.IsVisible = true;
        editBtn.IsVisible = false;
        cancelBtn.IsVisible = false;

        todoLV.SelectedItem = null;
    }

    // DELETE
    private void DeleteToDoItem(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        int id = Convert.ToInt32(btn.ClassId);

        var itemToRemove = todoList.FirstOrDefault(x => x.id == id);

        if (itemToRemove != null)
            todoList.Remove(itemToRemove);
    }

    // Tapped
    private void todoLV_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        // You can add your logic here, for example:
        // Deselect the item after tap
        ((ListView)sender).SelectedItem = null;
        // Optionally handle the tapped item
        // var tappedItem = e.Item;
    }
}
