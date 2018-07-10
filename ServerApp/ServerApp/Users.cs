using ServerApp.ClientApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    public class Users
    {

        public Users() {
            _UsersDict.Add("user", "pass");
            _UsersDict.Add("user1", "pass1");
            _UsersDict.Add("user2", "pass2");
        }
        private Dictionary<string, string> _UsersDict = new Dictionary<string, string>();


        public Dictionary<string, string> UsersDict {
            get { return _UsersDict; }
           
        }

    }
}
