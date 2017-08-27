using MVVMDemo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace MVVMDemo.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        #region Variables
        public event PropertyChangedEventHandler PropertyChanged;

        private User _user;
        bool _isBusy;
        bool _isLogin;
        string _displayMessage;
        public User user { get { return _user; } set { _user = value; NotifyPropertyChanged("user"); } }
        public string Displaymessage { get { return _displayMessage; } set { _displayMessage = value;  } }
        public bool IsBusy { get { return _isBusy; } set { _isBusy = value; } }
      

        #endregion


        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public  RegisterViewModel()
        {

        }
    }
}
