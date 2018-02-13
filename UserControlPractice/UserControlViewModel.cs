using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            MessageBox.Show("HI");
        }


        private bool OnCanExcuteMethod(object p)
        {
            return true;
        }


        //아이템소스 바인딩
        private ObservableCollection<string> itemList;
        public ObservableCollection<string> ItemList
        {
            get
            {
                if (itemList == null)
                {
                    itemList = new ObservableCollection<string>();
                }
                return itemList;
            }
            set
            {
                this.itemList = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }

    }
}
