using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using GalaSoft.MvvmLight; // to use ObservableObject class

namespace WpfApp1.Model
{

    //This is the class for each ToDo entry that defines each entry's attributes, namely, Checked(to include) and ToDoEntry string
    public class ToDoEntryClass : ObservableObject
    {
        public ToDoEntryClass(string ToDoEntryItem)
        {
            this.ToDoEntry = ToDoEntryItem;
        }

        private string _toDoEntry;
        public string ToDoEntry
        {
            get
            {
                return _toDoEntry;
            }
            set
            {
                _toDoEntry = value;
                RaisePropertyChanged("ToDoEntry");
            }
        }

        private bool _checked;
        public bool Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                _checked = value;
                RaisePropertyChanged("Checked");
            }
        }
    }
}
