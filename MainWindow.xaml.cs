using Sessia1.Models;
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

namespace Sessia1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        public static class Globals
        {
            public static int UserRole;
            public static Users userinfo { get; set; }
        }

        private void BtnSignIn_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
   
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var CurrentUser1 = AppData.db.Users.FirstOrDefault(u => u.FirstName == TxbLogin.Text && u.Password == TxbPassword.Text);
            if (CurrentUser1 != null)
            {
                Globals.UserRole = CurrentUser1.RoleID;
                Globals.userinfo = CurrentUser1;
                TxbPassword.IsEnabled = true;
                Glavnoe glavnoe = new Glavnoe();
                glavnoe.Show();
                this.Close();


            }
            else
            {
                MessageBox.Show("Ошибка входа:" +
                                "Такого пользователя нет, проверьте правильно ли ввели Логин и Пароль");
            }

        }
    }
}
