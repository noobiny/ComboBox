using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace UserControlPractice
{

    class MainWindowViewModel : MyInterface
    {
        UserControlViewModel userControlViewModel;
        public UserControlViewModel SubVM
        {
            get { return userControlViewModel; }
            set { userControlViewModel = value; OnPropertyChanged("SubVM"); }    //Class Instance Binding *
        }

        public MainWindowViewModel()
        {
            SubVM = new UserControlViewModel();
            ClickCommand = new TestCommand(OnExcuteMethod, OnCanExcuteMethod);
        }

        private bool OnCanExcuteMethod(object p)
        {
            return true;
        }

        private void OnExcuteMethod(object p)
        {
            StringModel stringModel = new StringModel { Name = Input };

            userControlViewModel.ItemList.Add(stringModel);
            Input = "";
        }


        //클릭 커맨드
        public TestCommand ClickCommand
        {
            get;
            set;
        }

        //입력 텍스트 프로퍼티
        private string input;
        public string Input
        {
            get { return input; }
            set
            {
                if (input != value)
                {
                    input = value;
                    OnPropertyChanged("Input");
                }
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


    public class TestCommand : ICommand // 커맨드 이벤트 어댑터
    {

        public delegate void CommandOnExecute(object p);
        public delegate bool CommandOnCanExecute(object p);
        private CommandOnExecute _execute;
        private CommandOnCanExecute _canExecute;

        public TestCommand(CommandOnExecute onExe, CommandOnCanExecute onCanExe)
        {

            _execute = onExe;
            _canExecute = onCanExe;

        }
        public event EventHandler CanExecuteChanged
        {

            add
            {
                CommandManager.RequerySuggested += value;

            }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object p)
        {

            return _canExecute(p);
        }

        public void Execute(object p)
        {
            _execute(p);

        }

    }
}
