using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace UserControlPractice
{

    public class UserControlViewModel : INotifyPropertyChanged
    {

        public TestCommand RemoveCommand
        {
            get;
            set;
        }


        public UserControlViewModel()
        {
            RemoveCommand = new TestCommand(OnExcuteMethod, OnCanExcuteMethod);
        }

        private void OnExcuteMethod(object p)
        {
            itemList.Remove(p as ComboBoxItem);
        }
        
        private bool OnCanExcuteMethod(object p)
        {
            return true;
        }


        //아이템소스 바인딩
        private ObservableCollection<ComboBoxItem> itemList;
        public ObservableCollection<ComboBoxItem> ItemList
        {
            get
            {
                if (itemList == null)
                {
                    itemList = new ObservableCollection<ComboBoxItem>();
                }
                return itemList;
            }
            set
            {
                itemList = value;
            }
        }

        public void AddItem(string content)
        {
            itemList.Add(new ComboBoxItem() { Content = content });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }
    }
}
