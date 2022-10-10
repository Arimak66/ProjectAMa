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
using MySqlConnector;
using Dapper;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System.Collections.ObjectModel;
using System.Configuration;
using Org.BouncyCastle.Crypto;

namespace ProjectAMa
{
    /// <summary>
    /// Interaction logic for AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        public AdministratorWindow()
        {
            InitializeComponent();
        }

        public class Userdata
        {
            public string Username { get; set; }
            public int Identity { get; set; }    
            public string Firstname { get; set; }
            public string Lastname { get; set; }

            public Userdata(string username, int identity ,string firstname, string lastname)
            { this.Username = username; this.Identity = identity; this.Firstname = firstname; this.Lastname = lastname; }

            public string UserInfo
            {
                get
                {
                    return $"{Username} {Firstname} {Lastname} ";
                }
            }
        }
            private void AddNewUser_Click(object sender, RoutedEventArgs e)
            {
                UserDataInsert userDataInsert = new UserDataInsert();
                userDataInsert.Show();
            }
            private void CloseThisWindow_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }
            private void ChangePassword_Click(object sender, RoutedEventArgs e)
            {
                ChangePassword changePassword = new ChangePassword();
                changePassword.Show();
            }
            private void CreateNewCourse_Click(object sender, RoutedEventArgs e)
            {
                CreateNewCourse createNewCourse = new CreateNewCourse();
                createNewCourse.Show();
            }
            private void ListAllUsers_Click(object sender, RoutedEventArgs e)
            {
                using (var connection = new MySqlConnection(Helper.CnnVal("OmaDB")))
                {
                    var Users = connection.Query<Userdata>($"select username,identity,firstname,lastname from user").ToList();
                    UserList.ItemsSource = Users;
                }
            }
            private void ListAllStudents_Click(object sender, RoutedEventArgs e)
            {
            using (var connection = new MySqlConnection(Helper.CnnVal("OmaDB")))
                {
                    var Users = connection.Query<Userdata>($"select username,identity,firstname,lastname from user where identity=1").ToList();
                    UserList.ItemsSource = Users;
                }
            }
            private void ListAllTeachers_Click(object sender, RoutedEventArgs e)
            {
                using (var connection = new MySqlConnection(Helper.CnnVal("OmaDB")))
                {
                    var Users = connection.Query<Userdata>($"select username,identity, firstname,lastname from user where identity=3").ToList();
                    UserList.ItemsSource = Users;
                }
            }
            private void ListAllAdministrators_Click(object sender, RoutedEventArgs e)
            {
                using (var connection = new MySqlConnection(Helper.CnnVal("OmaDB")))
                {
                    var Users = connection.Query<Userdata>($"select username,identity,firstname,lastname from user where identity=2").ToList();
                    UserList.ItemsSource = Users;
                }
            }

        private void SelectUser_Click(object sender, RoutedEventArgs e)
        {
            string status;
            Userdata userinfo= (Userdata)UserList.SelectedItems[0];
            if(userinfo.Identity == 1) {status = "Student"; }
            else if (userinfo.Identity == 2) { status = "Administrator";}
            else {status = "Teacher"; }

            MessageBox.Show("Valitsit käyttäjän: "+userinfo.Firstname +" "+userinfo.Lastname+" identity= "+status);
            //using (var connection = new MySqlConnection(Helper.CnnVal("OmaDB")))
            //{

            //}



        }

        private void SC_Click(object sender, SelectionChangedEventArgs e)
        {

        }


      
    }
}


