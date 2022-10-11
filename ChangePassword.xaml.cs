using System.Windows;
using MySqlConnector;
using Dapper;

namespace ProjectAMa
{
//Common password changing window for all user categories. Encryption/decryption needed here as well
    public partial class ChangePassword : Window
    {

        public ChangePassword()
        {
            InitializeComponent();

        }
        private void SetNewPassword_Click(object sender, RoutedEventArgs e)
        {
            string UserName = LoginScreen.UserName;
            using (var connection = new MySqlConnection(Helper.CnnVal("OmaDB")))
            {
                var output = connection.ExecuteScalar($"select password from user where username = '{UserName}';").ToString();
                if (!BCrypt.Net.BCrypt.Verify(OldPassword.Password, output))
                {
                    MessageBox.Show("Old password does not match, try again!");
                    OldPassword.Password = "";
                    NewPassword.Password = "";
                    ConfirmNewPassword.Password = "";
                }
            }
            if (NewPassword.Password != ConfirmNewPassword.Password)
            {
                MessageBox.Show("New passwords do not match, try again!");
                OldPassword.Password = "";
                NewPassword.Password= "";
                ConfirmNewPassword.Password = "";
            }
            using (var connection = new MySqlConnection(Helper.CnnVal("OmaDB")))
            { 
                string PassWord= BCrypt.Net.BCrypt.HashPassword(NewPassword.Password);
                connection.Execute($"update user set password = '{PassWord}'where username='{UserName}'");
                MessageBox.Show("Password changed successfully!");
                OldPassword.Password = "";
                NewPassword.Password = "";
                ConfirmNewPassword.Password = "";
            }
        }
        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
