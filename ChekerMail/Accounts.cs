using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChekerMail
{
    class Accounts
    {
        private Dictionary<string, string> _acc;
        public string this[string key] 
        {
            get => _acc[key];
            set => _acc[key] = value;
        }
        public Accounts(params string [] acc) 
        {
            
        }
    }
}
