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
            List<ElevVM> elevList = elevVM.ElevList.ToList();

            foreach(ElevVM elev in elevList)
            {
                if(elev.NumeUtilizator.Equals(userName) && elev.Parola.Equals(password))
                {
                    ElevView el = new ElevView(elev.ElevId);
                    
                    el.ShowDialog();
                }
            }


            ProfesorVM profVM = new ProfesorVM();
            List<ProfesorVM> profList = profVM.ProfesorList.ToList();

            foreach (ProfesorVM prof in profList)
            {
                if (prof.NumeUtilizator.Equals(userName) && prof.Parola.Equals(password) && prof.Diriginte == false)
                {
                    ProfesorView pr = new ProfesorView(prof.ProfesorId);

                    pr.ShowDialog();
                }
                if (prof.NumeUtilizator.Equals(userName) && prof.Parola.Equals(password) && prof.Diriginte == true)
                {
                    DiriginteView di = new DiriginteView();

                    di.ShowDialog();
                }
            }

            AdministratorVM adminVM = new AdministratorVM();
            List<AdministratorVM> adminList = adminVM.AdminList.ToList();

            foreach(AdministratorVM admin in adminList)
            {
                if(admin.NumeUtilizator.Equals(userName) && admin.Parola.Equals(password))
                {
                    AdministratorView ad = new AdministratorView();

                    ad.ShowDialog();
                }
            }
        }
    }
}
