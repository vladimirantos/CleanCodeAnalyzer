using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Cleaner;
using Cleaner.Parser;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
namespace CleanCodeAnalyzer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Cca _cca;
        private TaskFactory _taskFactory;
        public MainWindow()
        {
            InitializeComponent();
            startButton.IsEnabled = false;
            _taskFactory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);

            dataGrid.DataContext = new ObservableCollection<object>()
            {
                new
                {
                    Title = "FileWriter.cs",
                    Loc = 5,
                    Lloc = 3,
                    Cyklo = 8,
                    Arguments = 9,
                    Names = 14,
                    Sum = 39
                },
                new
                {
                    Title = "Database.cs",
                    Loc = 1,
                    Lloc = 1,
                    Cyklo = 2,
                    Arguments = 3,
                    Names = 33,
                    Sum = 40
                },
                new
                {
                    Title = "User.cs",
                    Loc = 8,
                    Lloc = 7,
                    Cyklo = 17,
                    Arguments = 4,
                    Names = 6,
                    Sum = 42
                },
                new
                {
                    Title = "Collection.cs",
                    Loc = 6,
                    Lloc = 2,
                    Cyklo = 11,
                    Arguments = 4,
                    Names = 10,
                    Sum = 33
                },
                new
                {
                    Title = "Parser.cs",
                    Loc = 14,
                    Lloc = 7,
                    Cyklo = 6,
                    Arguments = 2,
                    Names = 7,
                    Sum = 36
                },
                new
                {
                    Title = "Factory.cs",
                    Loc = 2,
                    Lloc = 2,
                    Cyklo = 14,
                    Arguments = 11,
                    Names = 6,
                    Sum = 35
                }
            };
        }

        private void loadProjectButton_Click(object sender, RoutedEventArgs e)
        {
            var folderSelectorDialog = new CommonOpenFileDialog();
            folderSelectorDialog.EnsureReadOnly = true;
            folderSelectorDialog.IsFolderPicker = true;
            folderSelectorDialog.AllowNonFileSystemItems = false;
            folderSelectorDialog.Multiselect = false;
            folderSelectorDialog.Title = "Cesta k projektu";
            if (folderSelectorDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string path = folderSelectorDialog.FileName;
                _cca = new Cca(path);
                _cca.Parser.OnParsing += OnParsing;
                //string path = @"C:\Users\Vladimír Antoš\Documents\Visual Studio 2015\Projects\CleanCodeAnalyzer\TestApp"; //todo:odstranit
            }
            startButton.IsEnabled = true;
        }

        private void loadFileButton_Click(object sender, RoutedEventArgs e)
        {
            var folderSelectorDialog = new CommonOpenFileDialog();
            folderSelectorDialog.Multiselect = true;
            folderSelectorDialog.Title = "Výběr souborů";
            folderSelectorDialog.ShowDialog();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            _cca.Start();
//            Task.WaitAll(_taskFactory.StartNew(() => _cca.Start()));
            startButton.IsEnabled = false;
        }

        private void OnParsing(object sender, ParseEvent e)
        {
            logTextBox.Text += $"Parsuji soubor: {e.File}\n\tNalezena třída: {e.Class}\n";
        }
    }
}
