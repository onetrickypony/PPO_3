using Microsoft.Win32;
using PPO_1.Plugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace PPO_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller controller;

        public MainWindow()
        {
            InitializeComponent();
            controller = new Controller(treeView);

            controller.LoadPlugins(treeView.Resources["FirstContext"] as  System.Windows.Controls.ContextMenu, treeView.Resources["SecondContext"] as System.Windows.Controls.ContextMenu);
            Properties.Settings.Default.Reload();
            this.Background = new SolidColorBrush(Properties.Settings.Default.MainWindowColor);
            treeView.FontWeight = Properties.Settings.Default.TreeViewFontSize;
        }

        private void button_load_Click(object sender, RoutedEventArgs e)
        {
            treeView.Items.Clear();
            controller.LoadFromFile(System.IO.Path.Combine(Directory.GetCurrentDirectory(), @textBox1.Text));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            controller.UnLoadDataToFile(System.IO.Path.Combine(Directory.GetCurrentDirectory(), @textBox1.Text));
        }

        private void buttonUndo_Click(object sender, RoutedEventArgs e)
        {
            controller.Undo();
        }

        private void buttonRedo_Click(object sender, RoutedEventArgs e)
        {
            controller.Redo();
        }

        private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem selectedItem = treeView.SelectedItem as TreeViewItem;
            if (selectedItem != null)
            {
                if (selectedItem.Parent == treeView)
                {
                    treeView.ContextMenu = treeView.Resources["FirstContext"] as System.Windows.Controls.ContextMenu;
                }
                else
                {
                    treeView.ContextMenu = treeView.Resources["SecondContext"] as System.Windows.Controls.ContextMenu;
                }
            }
        }

        private void MenuItem_AddGroup_click(object sender, RoutedEventArgs e)
        {
            WindowAddGroup winAG = new WindowAddGroup(controller, treeView.Items.Count);
            winAG.Show();
        }

        private void MenuItem_DeleteGroup_click(object sender, RoutedEventArgs e)
        {
            controller.DeleteGroup(treeView.Items.IndexOf(treeView.SelectedItem));           
        }

        private void MenuItem_EditGroupName_click(object sender, RoutedEventArgs e) 
        {
            TreeViewItem item = treeView.SelectedItem as TreeViewItem;
            WindowEditGroupName winEGN = new WindowEditGroupName(controller, item.Header as string, treeView.Items.IndexOf(item));
            winEGN.Show();
        }

        private void MenuItem_AddStudent_click(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = treeView.SelectedItem as TreeViewItem;
            WindowAddStudent winAS = new WindowAddStudent(controller, treeView.Items.IndexOf(item), item.Items.Count);
            winAS.Show();
        }

        //

        private void MenuItem_DeleteStudent_click(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = treeView.SelectedItem as TreeViewItem;
            TreeViewItem parent = item.Parent as TreeViewItem;
            controller.DeleteStudent(treeView.Items.IndexOf(parent), parent.Items.IndexOf(item));
        }

        private void MenuItem_EditStudent_click(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = treeView.SelectedItem as TreeViewItem;
            TreeViewItem parent = item.Parent as TreeViewItem;
            WindowEditStudent winES = new WindowEditStudent(controller, treeView.Items.IndexOf(parent), parent.Items.IndexOf(item));
            winES.Show();
        }

        private void MenuItemLargeFont_Click(object sender, RoutedEventArgs e)
        {
            treeView.FontWeight = FontWeights.Heavy;
            Properties.Settings.Default.TreeViewFontSize = FontWeights.Heavy;

        }

        private void MenuItemMiddleFont_Click(object sender, RoutedEventArgs e)
        {
            treeView.FontWeight = FontWeights.Medium;
            Properties.Settings.Default.TreeViewFontSize = FontWeights.Medium;
        }

        private void MenuItemSmallFont_Click(object sender, RoutedEventArgs e)
        {
            treeView.FontWeight = FontWeights.Light;
            Properties.Settings.Default.TreeViewFontSize = FontWeights.Light;
        }

        private void MenuItemWhiteBackground_Click(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.White);
            Properties.Settings.Default.MainWindowColor = Colors.White;
        }

        private void MenuItemGreyBackground_Click(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.DarkGray);
            Properties.Settings.Default.MainWindowColor = Colors.DarkGray;
        }

        private void MenuItemBeigeBackground_Click(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.Beige);
            Properties.Settings.Default.MainWindowColor = Colors.Beige;
        }

        private void MenuItemSaveSettings_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void MenuItemLoadDefaultSettings_Click(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.White);
            Properties.Settings.Default.MainWindowColor = Colors.White;
            treeView.FontWeight = FontWeights.Light;
            Properties.Settings.Default.TreeViewFontSize = FontWeights.Light;
        }
    }
}