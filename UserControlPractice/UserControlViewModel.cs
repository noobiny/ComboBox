using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace UserControlPractice
{

    public class StringModel : MyInterface
    {
        private string name;
        private int no;

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public int No
        {
            get { return no; }
            set
            {
                if (no != value)
                {
                    no = value;
                    OnPropertyChanged("No");
                }
            }
        }

        public override string ToString()
        {
            return Name;
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
            //ItemList.Remove(p.ToString());
            StringModel stringModel = p as StringModel;
            if (stringModel != null)
            {
                ItemList.Remove(stringModel);
            }

        }

        private bool OnCanExcuteMethod(object p)
        {
            return true;
        }

        //아이템소스 바인딩
        private ObservableCollection<StringModel> itemList;
        public ObservableCollection<StringModel> ItemList
        {
            get
            {
                if (itemList == null)
                {
                    itemList = new ObservableCollection<StringModel>();
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
