using System.Linq;
using System.Windows;
using MySqlConnector;
using Dapper;
using static ProjectAMa.LoginScreen;
using ProjectAMa.Models;

namespace ProjectAMa
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public StudentWindow()
        {
            InitializeComponent();
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = new MySqlConnection(Helper.CnnVal("OmaDB")))
            {
                var User = connection.Query<Userdata>($"select username,firstname,lastname from user where username='{UserName}'").ToList(); 
                UserList.ItemsSource = User;
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
        private void Courses_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = new MySqlConnection(Helper.CnnVal("OmaDB")))
            {
                var Courses = connection.Query<CourseData>($"select name,greditpoints" +
                    $" from course inner join grade on course.idcourse=grade.idcourse"+
                    $" inner join student on student.idstudent=grade.idstudent"+
                    $" inner join user users on users.iduser=student.idstudent where users.username='{UserName}'").ToList();           
                CourseList.ItemsSource = Courses;
            }
        }
        private void Grades_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = new MySqlConnection(Helper.CnnVal("OmaDB")))
            {
                var Grades = connection.Query<GradeData>($"select name,greditpoints,grade,date" +
                $" from course inner join grade on course.idcourse=grade.idcourse" +
                $" inner join student on student.idstudent=grade.idstudent" +
                $" inner join user users on users.iduser=student.idstudent where users.username='{UserName}'").ToList();
                GradeList.ItemsSource = Grades;
            }
        }
    }
}
