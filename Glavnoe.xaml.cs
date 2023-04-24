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
using System.Windows.Shapes;

namespace Sessia1
{
    /// <summary>
    /// Логика взаимодействия для Glavnoe.xaml
    /// </summary>
    public partial class Glavnoe : Window
    {
        Session1_XXEntities1 db = new Session1_XXEntities1();
        public Glavnoe()
        {
            InitializeComponent();
            Combo.ItemsSource = AppData.db.Offices.ToList();

            if (MainWindow.Globals.UserRole == 1)
            {
                skritoe.Visibility = Visibility.Visible;
            }
            else
            {
                skritoe.Visibility = Visibility.Collapsed;
            }
            var officesese = Session1_XXEntities1.GetContext().Offices.ToList();
            officesese.Insert(0, new Offices
            {
                Title = "All offices"
            });
            Combo.SelectedIndex = 0;
            Combo.ItemsSource = officesese;
            UpdateTable();
        }
        public void UpdateTable()
        {
            var thisUsers = db.Users.ToList();
            if (Combo.SelectedIndex > 0 && Combo.SelectedIndex != 1)
            {
                thisUsers = thisUsers.Where(p => p.OfficeID == Combo.SelectedIndex + 1).ToList();
            }
            else if (Combo.SelectedIndex == 1)
            {
                thisUsers = thisUsers.Where(p => p.Offices.Title == "Abu dhabi").ToList();
            }
            UsersGrid2.ItemsSource = thisUsers;
        }

        private void Add2_Btn_Click(object sender, RoutedEventArgs e)
        {
            Users user = UsersGrid2.SelectedItem as Users;
            if (user.RoleID == 1)
            {
                user.RoleID = 2;
                MessageBox.Show("Роль изменена на " + "User");
            }
            else
            {
                user.RoleID = 1;
                MessageBox.Show("Роль изменена на " + "Administrator");
            }
            Session1_XXEntities1.GetContext().SaveChanges();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            Users user = UsersGrid2.SelectedItem as Users;
            if (user.Active == true)
            {
                user.Active = false;
                MessageBox.Show("Off");
            }
            else
            {
                user.Active = true;
                MessageBox.Show("On");
            }
            Session1_XXEntities1.GetContext().SaveChanges();
            AppData.db.SaveChanges();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UsersGrid2.ItemsSource = AppData.db.Users.ToList();
        }

        private void All_offices(object sender, SelectionChangedEventArgs e)
        {
            UpdateTable();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dobavlenie dobavlenie = new Dobavlenie();
            dobavlenie.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

    }
}
