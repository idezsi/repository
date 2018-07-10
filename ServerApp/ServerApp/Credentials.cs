using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace ClientApp.Model
    {
        public class Credentials
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
                        

                    }
                }
            }

            string _Username;

           
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
                       

                    }
                }
            }

        }


    }

}
