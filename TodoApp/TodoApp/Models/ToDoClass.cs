using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TodoApp
{
    public class ToDoClass : INotifyPropertyChanged
    {
        int _item_id;
        string _item_name;
        string _item_description;
        string _status;
        int _user_id;

        public int item_id
        {
            get { return _item_id; }
            set { _item_id = value; OnPropertyChanged(); }
        }

        public string item_name
        {
            get { return _item_name; }
            set { _item_name = value; OnPropertyChanged(); }
        }

        public string item_description
        {
            get { return _item_description; }
            set { _item_description = value; OnPropertyChanged(); }
        }

        public string status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged(); }
        }

        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}