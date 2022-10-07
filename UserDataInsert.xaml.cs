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
using System.Xml.Linq;
using MySqlConnector;
using Dapper;

namespace ProjectAMa
{
// New user insertion for administrators
    public partial class UserDataInsert : Window
    {
        public UserDataInsert()
        {
            InitializeComponent();
        }
        private void IdentitySelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
     //placeholder possibly
        }
        private void CreateNewUser_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = new MySqlConnection(Helper.CnnVal("OmaDB")))
            {
                if (InsertUsername.Text != null)    
                {
                    string PassWord = BCrypt.Net.BCrypt.HashPassword(InsertPassword.Text);
                    connection.Execute($"insert into user (username,password,identity,firstname,lastname) values " +
                    $"('{InsertUsername.Text}','{PassWord}','{IdentitySelect.SelectedIndex +1}'," +
                    $"'{InsertFirstname.Text}','{InsertLastname.Text}')");
                    MessageBox.Show("New user was created succesfully!");

                    InsertUsername.Text = "";
                    InsertPassword.Text = "";
                    InsertFirstname.Text = "";
                    InsertLastname.Text = "";
                }
                else
                {
                    MessageBox.Show("You must give values!");
                }


            }
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void IdentitySelect_Select(object sender, RoutedEventArgs e)
        {

        }
    }
}
