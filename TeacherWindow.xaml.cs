using ProjectAMa.Models;
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
using Dapper;
using MySql.Data.MySqlClient;

namespace ProjectAMa
{
    /// <summary>
    /// Interaction logic for TeacherWindow.xaml
    /// </summary>
    public partial class TeacherWindow : Window
    {
        public TeacherWindow()
        {
            InitializeComponent();
        }
        private void ListAllStudents_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = new MySqlConnection(Helper.CnnVal("OmaDB")))
            {
                var Users = connection.Query<Userdata>($"select username,identity,firstname,lastname from user where identity=1").ToList();
                UserList.ItemsSource = Users;
            }
        }
        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            changePassword.Show();
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


        private void CreateNewCourse_Click(object sender, RoutedEventArgs e)
        {
            CreateNewCourse createNewCourse = new CreateNewCourse();
            createNewCourse.Show();
        }

        private void GradeStudent_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Under construction");
        }
    }
}
