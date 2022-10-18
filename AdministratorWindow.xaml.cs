using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MySqlConnector;
using Dapper;
using ProjectAMa.Models;

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
            //InitializeUser();
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
            try 
            { 
            Userdata userinfo = (Userdata)UserList.SelectedItems[0];
                string status;
                //if (userinfo == null) { MessageBox.Show("Select a user first"); }
                if (userinfo.Identity == 1) { status = "Student"; }
                else if (userinfo.Identity == 2) { status = "Administrator"; }
                else { status = "Teacher"; }

                MessageBox.Show("You selected user: " + userinfo.Firstname + " " + userinfo.Lastname + " whose identity is " + status);
            }
            catch { MessageBox.Show("Select first user or list of users"); }
        }

        private void deleteUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Userdata userinfo = (Userdata)UserList.SelectedItems[0];
                string status;
                if (userinfo.Identity == 1) { status = "Student"; }
                else if (userinfo.Identity == 2) { status = "Administrator"; }
                else { status = "Teacher"; }
                MessageBox.Show("You try to delete user: " + userinfo.Firstname + " " + userinfo.Lastname + " whose identity is " + status+" is this OK?");
                using (var connection = new MySqlConnection(Helper.CnnVal("OmaDB")))
                {
                    var Users = connection.Execute($"delete from user where username='{userinfo.Username}'");
                    MessageBox.Show("User " + userinfo.Username + ", " + userinfo.Firstname + " " + userinfo.Lastname + " was deleted successfully!");
                }
            }
            catch { MessageBox.Show("Select first user or list of users"); }
        }
            public void SC_Click(object sender, SelectionChangedEventArgs e)
            {

            }
    } 
}
