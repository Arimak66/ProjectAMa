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

    }
}
