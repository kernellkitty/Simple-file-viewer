using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace skebobus
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void b_scan_Click(object sender, RoutedEventArgs e)
        {
            tree.Items.Clear();

            string path = f_path.Text;

            if (Directory.Exists(path))
            {
                DirectoryInfo dir = new DirectoryInfo(path);

                TreeViewItem root = new TreeViewItem();
                root.Header = "📁" + dir.Name;

                string[] sub = Directory.GetDirectories(path);

                foreach (string folder in sub)
                {
                    DirectoryInfo s_folder = new DirectoryInfo(folder);
                    TreeViewItem child = new TreeViewItem();
                    child.Header = "📁" + s_folder.Name;
                    root.Items.Add(child);
                    
                    ShowRecursive(folder, child);

                    string[] files2 = Directory.GetFiles(folder);
                    foreach (string file in files2)
                    {
                        FileInfo file_node = new FileInfo(file);
                        TreeViewItem child_f2 = new TreeViewItem();
                        child_f2.Header = file_node.Name;
                        child.Items.Add(child_f2);
                    }
                }

                string[] files = Directory.GetFiles(path);

                foreach (string file in files)
                {
                    FileInfo s_file = new FileInfo(file);
                    TreeViewItem child_f = new TreeViewItem();
                    child_f.Header = s_file.Name;
                    root.Items.Add(child_f);
                }
                tree.Items.Add(root);

            }
            else { MessageBox.Show("Error! \nDirectory not found."); }

        }
        public static void ShowRecursive(string path, TreeViewItem parent)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            TreeViewItem root = new TreeViewItem();
            root.Header = "📁" + dir.Name;
            parent.Items.Add(root);

            string[] folder_sub = Directory.GetDirectories(path);
            string[] file_sub = Directory.GetFiles(path);
            if (folder_sub.Length != 0)
            {


                foreach (string file in file_sub)
                {
                    FileInfo s_file = new FileInfo(file);
                    TreeViewItem file_node = new TreeViewItem();
                    file_node.Header = s_file.Name;
                    root.Items.Add(file_node);
                }

                foreach (string folder in folder_sub)
                {

                    ShowRecursive(folder, root);
                }
            }
        }
    }
}
