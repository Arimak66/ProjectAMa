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
using MySqlConnector;
using Dapper;

namespace ProjectAMa
{
    /// <summary>
    /// Interaction logic for CreateNewCourse.xaml
    /// </summary>
    public partial class CreateNewCourse : Window
    {
        public CreateNewCourse()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = new MySqlConnection(Helper.CnnVal("OmaDB")))

                
            {
                //var output = connection.Query($"count(idcourse) from course").ToString() ;
                //MessageBox.Show(output);
                //int idCourse=Convert.ToInt32(output)+1;
                int idCourse = Convert.ToInt32(textCourseId.Text);
                short creditPoints = Convert.ToInt16(textCreditpoints.Text);
                connection.Execute($"insert into course (idcourse,name,greditpoints) values ({idCourse},'{textNewCourseName.Text}',{creditPoints})"); ;

                MessageBox.Show("New course created succesfully!");
                textNewCourseName.Text = "";
                textCreditpoints.Text = "";

            }
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
