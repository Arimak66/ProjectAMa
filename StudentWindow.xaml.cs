using System.Linq;
using System.Windows;
using MySqlConnector;
using Dapper;
using static ProjectAMa.AdministratorWindow;

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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Klikkasit sitten nappulaa, "+UserName);
            using (var connection = new MySqlConnection(Helper.CnnVal("OmaDB")))
            {
                var Users = connection.Query<Userdata>($"select firstname,lastname from user where username='{UserName}'").ToList();
                //string message = ToString(Users.firstname )
                welcomeText.DataContext = Users;
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
    }
}
