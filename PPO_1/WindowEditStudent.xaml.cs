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

namespace PPO_1
{
    /// <summary>
    /// Логика взаимодействия для WindowEditStudent.xaml
    /// </summary>
    public partial class WindowEditStudent : Window
    {
        Controller controller;
        int grpos;
        int perpos;

        public WindowEditStudent(Controller controller, int grpos, int perpos)
        {
            InitializeComponent();
            this.controller = controller;
            this.grpos = grpos;
            this.perpos = perpos;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            controller.EditStudent(textBox_surname.Text, textBox_name.Text, textBox_fathername.Text, int.Parse(textBox_rating.Text), textBox_avatar.Text, grpos, perpos);
            this.Close();
            /*
            try
            {
                controller.EditStudent(textBox_surname.Text, textBox_name.Text, textBox_fathername.Text, int.Parse(textBox_rating.Text), textBox_avatar.Text, grpos, perpos);
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректный ввод.");
            }    
            this.Close();
            */
        }

    }
}
