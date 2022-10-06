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
            using (var connection = new MySqlConnection(Helper.CnnVal("OmaDB")))
            {
                var output = connection.ExecuteScalar($"select password from user where username = '{LoginScreen.UserName}';").ToString();
                if(output != OldPassword.Text) { MessageBox.Show("Väärä vanha salasana! Yritäppä uuvestaan");
                    OldPassword.Text = "";
                    NewPassword.Text = "";
                    ConfirmNewPassword.Text = "";
                }
            }
            if (NewPassword.Text != ConfirmNewPassword.Text)
            { 
                MessageBox.Show("Eipä mätsää salasanat, yritäppä uuvestaan");
                OldPassword.Text = "";
                NewPassword.Text = "";
                ConfirmNewPassword.Text = "";          
            }
            MessageBox.Show("Ei vielä toimi, mutta maltahan ootella");
        }
        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
