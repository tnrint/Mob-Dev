namespace ToDoMaui_Listview;
using System;
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

    // EDIT (save changes from editor to selected item)
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

    // DELETE - prefer BindingContext of Button or MenuItem, ask for confirmation
    private async void DeleteToDoItem(object sender, EventArgs e)
    {
        ToDoClass item = null;

        // Button inside the ViewCell uses its BindingContext
        if (sender is Button btn && btn.BindingContext is ToDoClass btnItem)
        {
            item = btnItem;
        }
        // Context menu (MenuItem)
        else if (sender is MenuItem menu && menu.BindingContext is ToDoClass menuItem)
        {
            item = menuItem;
        }
        // Fallback: try to parse ClassId (not used in updated XAML but kept safe)
        else if (sender is Button btn2 && int.TryParse(btn2.ClassId, out int id))
        {
            item = todoList.FirstOrDefault(x => x.id == id);
        }

        if (item == null)
            return;

        bool confirm = await DisplayAlert("Delete", "Delete this item?", "Delete", "Cancel");
        if (!confirm)
            return;

        todoList.Remove(item);

        if (selectedItem != null && selectedItem.id == item.id)
        {
            CancelEdit(null, null);
        }
    }

    // optional: context-menu Edit handler
    private void EditMenu_Clicked(object sender, EventArgs e)
    {
        if (sender is MenuItem menu && menu.BindingContext is ToDoClass item)
        {
            selectedItem = item;
            titleEntry.Text = item.title;
            detailsEditor.Text = item.detail;

            addBtn.IsVisible = false;
            editBtn.IsVisible = true;
            cancelBtn.IsVisible = true;
        }
    }

    // explicit context-menu delete (kept for clarity)
    private async void DeleteMenu_Clicked(object sender, EventArgs e)
    {
        if (sender is MenuItem menu && menu.BindingContext is ToDoClass item)
        {
            bool confirm = await DisplayAlert("Delete", "Delete this item?", "Delete", "Cancel");
            if (confirm)
            {
                todoList.Remove(item);
                if (selectedItem != null && selectedItem.id == item.id)
                {
                    CancelEdit(null, null);
                }
            }
        }
    }

    // preserved (unused) tapped handler - no longer wired in XAML
    private void todoLV_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        // kept for reference; do not clear selection here so ItemSelected can be used for edit.
    }
}
