using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChekerMail
{
    class Accounts
    {
        private Dictionary<string,string>_acc = new Dictionary<string, string>();
        public string this[string key] 
        {
            get => _acc[key];
            set => _acc[key] = value;
        }
        public Accounts(string[] acc)
        {
            AddDictionaty(acc);
        }
        public Accounts() { }

        //Разделяй и влавствуй
        private void AddDictionaty(string[] value) 
        {
            string[] f;
            foreach (var item in value)
            {
                f = item.Split(':');
                for (int i = 0; i < 1; i++)
                {
                    _acc.Add(f[i], f[i + 1]);
                }
            }
            f = null;
        }
        public String AddLabelProcess() => _acc.Count.ToString();
    }
}
