using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
namespace CleanCodeAnalyzer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Zarovka z = new Zarovka();
        //private CcaLoader _ccaLoader;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadProjectButton_Click(object sender, RoutedEventArgs e)
        {
            //var folderSelectorDialog = new CommonOpenFileDialog();
            //folderSelectorDialog.EnsureReadOnly = true;
            //folderSelectorDialog.IsFolderPicker = true;
            //folderSelectorDialog.AllowNonFileSystemItems = false;
            //folderSelectorDialog.Multiselect = false;
            //folderSelectorDialog.Title = "Cesta k projektu";
            //if (folderSelectorDialog.ShowDialog() == CommonFileDialogResult.Ok)
            //{
            //    string path = folderSelectorDialog.FileName;
                string path = @"C:\Users\Vladimír Antoš\Documents\Visual Studio 2015\Projects\CleanCodeAnalyzer\TestApp"; //todo:odstranit
            
            //ccaLoader = CcaLoader.Create(path);
            //logTextBlock.Text += "Nahrávám projekt " + path + "\n";
            //}
        }

        private void loadFileButtion_Click(object sender, RoutedEventArgs e)
        {
            var folderSelectorDialog = new CommonOpenFileDialog();
            folderSelectorDialog.Multiselect = true;
            folderSelectorDialog.Title = "Výběr souborů";
            folderSelectorDialog.ShowDialog();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
           // logTextBlock.Text += "Spouštím parsování \n";
            //_ccaLoader.Start();   
        }

        private void LoadProject(string path)
        {
            //CcaLoader ccaLoader = new CcaLoader(path);
            //ccaLoader.Start();
        }
    }
}
