using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlPractice
{
    public interface MyInterface : INotifyPropertyChanged
    {


        //public event PropertyChangedEventHandler PropertyChanged;
        //private void OnPropertyChanged(string p)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(p));
        //    }
        //}


    }
}
