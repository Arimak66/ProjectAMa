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
using System.Data.SqlClient;
using Org.BouncyCastle.Tls;

namespace ProjectAMa
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var connection = new MySqlConnection(Helper.CnnVal("OmaDB"));
            string Username = txtUsername.Text;
            string Password = txtPassword.Password;
            var output = connection.ExecuteScalar($"select count(username) from user where username='{Username}' and password='{Password}'");


            if (Convert.ToInt32(output)== 1)
            {
 
                var Identity = connection.ExecuteScalar<string>($"select identity from user where username='{Username}'");

                if (Convert.ToInt32(Identity) == 1)
                {

                    var Name = connection.ExecuteScalar<string>($"select firstname from user where username='{Username}'");
                    MessageBox.Show("Hello "+ Name+". You are a student, click OK to enter.");
                    StudentWindow studentWindow = new StudentWindow();
                    studentWindow.Show();
                    this.Close();
                }

                else if (Convert.ToInt32(Identity) == 2)
                {
                    var Name = connection.ExecuteScalar<string>($"select firstname from user where username='{Username}'");
                    MessageBox.Show("Hello " + Name+". You are an administrator, click OK to enter.");
                    AdministratorWindow administratorWindow = new AdministratorWindow();
                    administratorWindow.Show();
                    this.Close();
                }
                else if (Convert.ToInt32(Identity) == 3)
                {
                    var Name = connection.ExecuteScalar<string>($"select firstname from user where username='{Username}'");
                    MessageBox.Show("Hello " + Name+". You are a teacher, click OK to enter.");
                    TeacherWindow teacherWindow = new TeacherWindow();
                    teacherWindow.Show();
                    this.Close();
                }
                else MessageBox.Show("Unknown identity");
        
            }
            else
            { MessageBox.Show("Incorrect username or password"); }


        }
    }
}
