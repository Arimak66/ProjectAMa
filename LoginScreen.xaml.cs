using System;
using System.Windows;
using MySqlConnector;
using Dapper;

namespace ProjectAMa
{
    //This is a common login-window for all categories of university-users. Users are directed to different window paths based on their credentials/authorizations
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }
        //Probably should use Singleton or some other means to be able to convey "username" to the appropriate windows

        public static string UserName;
        public void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var connection = new MySqlConnection(Helper.CnnVal("OmaDB"));
            string Username = txtUsername.Text;
            string Password = txtPassword.Password;
            UserName = txtUsername.Text;
 
            if (Username == "" || Password == "")
            {
                MessageBox.Show("Username or Password cannot be empty! Try Again!");
            }
            //var output = connection.ExecuteScalar($"select count(username) from user where username='{Username}' and password='{Password}'");
            //if (Convert.ToInt32(output)== 1)
            var output = connection.ExecuteScalar($"select password from user where username='{Username}'").ToString();
            if (BCrypt.Net.BCrypt.Verify(Password, output) /*|| txtPassword.Password == output*/)
            {

                UserName = Username;


                var Identity = connection.ExecuteScalar<string>($"select identity from user where username='{Username}'");

                if (Convert.ToInt32(Identity) == 1)
                {
                    var Name = connection.ExecuteScalar<string>($"select firstname from user where username='{Username}'");
                    MessageBox.Show("Hello "+ Name+". You are listed as a student, click OK to enter.");
                    StudentWindow studentWindow = new StudentWindow();
                    studentWindow.Show();
                    this.Close();
                }
                else if (Convert.ToInt32(Identity) == 2)
                {
                    var Name = connection.ExecuteScalar<string>($"select firstname from user where username='{Username}'");
                    MessageBox.Show("Hello " + Name+". You are listed as an administrator, click OK to enter.");
                    AdministratorWindow administratorWindow = new AdministratorWindow();
                    administratorWindow.Show();
                    this.Close();
                }
                else if (Convert.ToInt32(Identity) == 3)
                {
                    var Name = connection.ExecuteScalar<string>($"select firstname from user where username='{Username}'");
                    MessageBox.Show("Hello " + Name+". You are listed as a teacher, click OK to enter.");
                    TeacherWindow teacherWindow = new TeacherWindow();
                    teacherWindow.Show();
                    this.Close();
                }
                else MessageBox.Show("Unknown identity");
            }
            else
            { MessageBox.Show("Incorrect username or password");
                txtUsername.Text = "";
                txtPassword.Password = "";
            }
        }
    }
}
