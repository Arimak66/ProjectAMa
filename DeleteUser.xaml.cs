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
    /// Interaction logic for DeleteUser.xaml
    /// </summary>
    public partial class DeleteUser : Window
    {
        public DeleteUser()
        {
            InitializeComponent();
        }

        private void deleteUser_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Yes");
        }

        private void noDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("No");
        }
    }
}
