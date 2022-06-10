using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
namespace ChekerMail
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Accounts account; 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = "Document";
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt|*.txt";
            bool? result = dialog.ShowDialog();
            if (result == true) 
            {
                account = new Accounts(File.ReadAllLines(dialog.FileName));
                lbltotalAccounts.Content = account.AddLabelProcess();
            }
            return;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (account == null) 
            {
                MessageBox.Show("Отсутствует список аккаунтов");
                return;
            }
            account.G_B_inP_P += (g, b, inP, Proc) =>
            {
                lblGood.Content = g;
                lblBad.Content = b;
                lblinProcessing.Content = inP;
                lblProcessed.Content = Proc;
            };
            account.result += (r) =>
            {
                txtResult.Text += r;
            };
        }
    }
}
