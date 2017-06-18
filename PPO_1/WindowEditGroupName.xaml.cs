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
    /// Логика взаимодействия для WindowEditGroupName.xaml
    /// </summary>
    public partial class WindowEditGroupName : Window
    {
        Controller controller;
        int position;

        public WindowEditGroupName(Controller controller, string groupname, int position)
        {
            InitializeComponent();
            this.controller = controller;
            this.position = position;
            textBox.Text = groupname;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            controller.EditGroup(textBox.Text, position);
            this.Close();
        }
    }
}
