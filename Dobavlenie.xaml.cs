using Sessia1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
    /// Логика взаимодействия для Dobavlenie.xaml
    /// </summary>
    public partial class Dobavlenie : Window
    {
        public Dobavlenie()
        {
            InitializeComponent();
            Off.ItemsSource = AppData.db.Offices.ToList();
            CmbRole.ItemsSource = AppData.db.Roles.ToList();
        }

        private void Save2_Btn_Click(object sender, RoutedEventArgs e)
        {
            Users people = new Users();

            people.Email = Em.Text;
            people.FirstName = First.Text;
            people.LastName = Last.Text;

            var CurrentOffice = Off.SelectedItem as Offices;
            people.OfficeID = CurrentOffice.ID;
            
            var CurrentDate = Datee.SelectedDate.Value;
            people.Birthdate = CurrentDate;

            var CurrentRole = CmbRole.SelectedItem as Roles;
            people.RoleID = CurrentRole.ID;

            people.Password = Pass.Text;



            AppData.db.Users.Add(people);
            AppData.db.SaveChanges();
            MessageBox.Show("Добавлено");

            Glavnoe glavnoe = new Glavnoe();
            glavnoe.Show();
            this.Close(); 

        }

      
    }
}
