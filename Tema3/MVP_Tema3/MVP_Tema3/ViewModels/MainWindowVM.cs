using MVP_Tema3.Helpers;
using MVP_Tema3.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVP_Tema3.ViewModels
{
    class MainWindowVM:BaseVM
    {
        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                if (!string.Equals(userName, value))
                {
                    userName = value;
                    NotifyPropertyChanged("UserName");
                }
            }
        }
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (!string.Equals(password, value))
                {
                    password = value;
                    NotifyPropertyChanged("Password");
                }
            }
        }


        private ICommand openWindowCommand;
        public ICommand OpenWindowCommand
        {
            get
            {
                if(openWindowCommand==null)
                {
                    openWindowCommand = new RelayCommand(OpenWindowLogin);
                }

                return openWindowCommand;
            }
        }


        public void OpenWindowLogin(object obj)
        {
            ElevVM elevVM = new ElevVM();
            List<ElevVM> list = elevVM.ElevList.ToList();

            foreach(ElevVM elev in list)
            {
                if(elev.NumeUtilizator.Equals(userName) && elev.Parola.Equals(password))
                {
                    ElevView el = new ElevView();
                    el.ShowDialog();
                }
            }
        }
    }
}
