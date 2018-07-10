using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Model
{
    class Credentials :INotifyPropertyChanged
    {
        string _Password;
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                if (_Password != value)
                {
                    _Password = value;
                    OnPropertyChanged(Password);
                    
                }
            }
        }

        string _Username;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string p) {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null)
                ph(this, new PropertyChangedEventArgs(p));

        }
        public string Username
        {
            get
            {
                return _Username;
            }
            set
            {
                if (_Username != value)
                {
                    _Username = value;
                    OnPropertyChanged(Username);

                }
            }
        }
        
    } 

    
}
