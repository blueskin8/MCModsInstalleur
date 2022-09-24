using System;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MCModsInstalleur
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void InstallMod(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Minecraft mod (*.jar)|*.jar";
            openFileDialog.InitialDirectory = @"C:\Users\" + Environment.UserName + @"\Downloads";

            if (openFileDialog.ShowDialog() == true)
            {
                File.Copy(openFileDialog.FileName.ToString(), @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\.minecraft\mods\" + System.IO.Path.GetFileName(openFileDialog.FileName.ToString()));
            }



            if (System.IO.Path.GetFileName(openFileDialog.FileName.ToString()) != "")
            {
                MessageBox.Show(System.IO.Path.GetFileName(openFileDialog.FileName.ToString()) + " installé sur votre client dans : " + @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\.minecraft\mods\");
            }            
        }


        public void UninstallMod(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Minecraft mod (*.jar)|*.jar";
            openFileDialog.InitialDirectory = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\.minecraft\mods\";

            if (openFileDialog.ShowDialog() == true)
            {
                File.Delete(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\.minecraft\mods\" + System.IO.Path.GetFileName(openFileDialog.FileName.ToString()));
            }

            if (System.IO.Path.GetFileName(openFileDialog.FileName.ToString()) != "")
            {
                MessageBox.Show(System.IO.Path.GetFileName(openFileDialog.FileName.ToString()) + " supprimé de vottre client depuis : " + @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\.minecraft\mods\");
            }
        }

        public void CurseForge(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer", "https://www.curseforge.com/minecraft/mc-mods");
        }
    }
}