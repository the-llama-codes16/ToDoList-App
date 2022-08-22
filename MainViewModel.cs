using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command; // to use RelayCommand
using System.Collections.ObjectModel; // to use Observable Collection
using WpfApp1.Model ; // to use the ToDoEntryClass
using System.Linq; // to use LINQ

namespace WpfApp1.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    /// 


    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        
        public MainViewModel()
        { 
            _toDoEntryList = new ObservableCollection<ToDoEntryClass>();
        }

        //The Observable Collection the ListBox binds to 
        private ObservableCollection<ToDoEntryClass> _toDoEntryList;
        public ObservableCollection<ToDoEntryClass> ToDoEntryList
        {
            get
            {
                return (_toDoEntryList);
            }
        }

        private const string CheckedItemsPropertyName = "CheckedItems";
        private int _checkedItems;
        //The property the "Finished" counter binds to
        public int CheckedItems
        {
            get
            {
                _checkedItems = ToDoEntryList.Count(item => item.Checked);
                return _checkedItems;
            }
        }

        private const string UncheckedItemsPropertyName = "UncheckedItems";
        private int _uncheckedItems;
        //The property the "Unfinished" counter binds to
        public int UncheckedItems
        {
            get
            {
                _uncheckedItems = ToDoEntryList.Count(item => !item.Checked);
                return _uncheckedItems;
            }
        }


        #region Commands

        //A RelayCommand Property for the Add Button to Bind to, and will add a new element to the list
        private RelayCommand _addButtonClickCommand;
        public RelayCommand AddButtonClickCommand
        {
            get
            {
                return _addButtonClickCommand
                    ?? (_addButtonClickCommand = new RelayCommand (ExecuteAddButtonClickCommand));
            }
        }   

        //The Execute method for the Add button
        private void ExecuteAddButtonClickCommand()
        {
            ToDoEntryList.Add(new ToDoEntryClass(ToDoEntryInput));
            ExecuteCountCheckedItems();
            ToDoEntryInput = string.Empty;
            RaisePropertyChanged(ToDoEntryInputPropertyName);
            return;
        }

        private const string ToDoEntryInputPropertyName = "ToDoEntryInput";
        private string _toDoEntryInput;
        //The string property for the TextBox to Bind to
        public string ToDoEntryInput
        {
            get
            {
                return _toDoEntryInput;
            }
            set
            {
                _toDoEntryInput = value;
                RaisePropertyChanged(ToDoEntryInputPropertyName);
            }
        }

       
        //A RelayCommand property for the Checked and Unchecked events of the CheckBox to bind to
        private RelayCommand _countCheckedItemsCommand;
        public RelayCommand CountCheckedItemsCommand
        {
            get
            {
                return _countCheckedItemsCommand
                    ?? (_countCheckedItemsCommand = new RelayCommand(ExecuteCountCheckedItems));
            }
        }

        // The Execute method which notifies the Checked and Unchecked properties to initiate "recount"
        private void ExecuteCountCheckedItems()
        {
            RaisePropertyChanged(CheckedItemsPropertyName);
            RaisePropertyChanged(UncheckedItemsPropertyName);
        }
        #endregion
    }
}


