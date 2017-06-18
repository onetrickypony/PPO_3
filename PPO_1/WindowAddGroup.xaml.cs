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
    /// Логика взаимодействия для WindowAddGroup.xaml
    /// </summary>
    public partial class WindowAddGroup : Window
    {
        private Controller controller;
        private int position;

        public WindowAddGroup(Controller ctrler, int position)
        {
            InitializeComponent();
            controller = ctrler;
            this.position = position;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            controller.AddGroup(textBox.Text, position);
            this.Close();
        }
    }
}
