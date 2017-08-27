using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVMDemo.ViewModels
{
    class LoginViewModel : INotifyPropertyChanged
    {
        #region Variables
        public event PropertyChangedEventHandler PropertyChanged;

        private string _email;
        bool _isBusy = false;
        bool _isLogin;
        string _displayMessage;
        public Command LoginCommand { get; }
        public string Email { get { return _email; }
            set { _email = value;
                NotifyPropertyChanged("Email");
                NotifyPropertyChanged("DisplayMessage");
            } }

        public string Displaymessage { get { return _displayMessage; }
            set { _displayMessage =
                    "Hey Pal ! Entered email: " + Email + " is" + (Regex.Match(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success ? "Valid" : "not valid");
                if(Regex.Match(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success){
                    ((Command)this.LoginCommand).ChangeCanExecute();
                }
            } }

        public bool IsBusy { get { return _isBusy; } set { _isBusy = value; NotifyPropertyChanged("IsBusy"); } }

        public bool IsLogin { get { return _isLogin; } set { _isLogin = value; } }

        #endregion

        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public LoginViewModel()
        {
            LoginCommand = new Command(async () =>
             {
                 _isBusy = true;
                await Task.Delay(2000);
                 _isBusy = false;

             },()=> ! _isBusy);
        }
    }
}

