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
using Cleaner;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace CleanCodeAnalyzer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private string _path;
        private CcaFactory _ccaFactory = new CcaFactory();
        private bool _isCalibration = false;
        public MainWindow()
        {
            InitializeComponent();
            startButton.IsEnabled = false;
            ShowGraphButton.IsEnabled = false;
        }

        private void GithubButton_Click(object sender, RoutedEventArgs e) => Process.Start("https://github.com/vladimirantos/CleanCodeAnalyzer");

        private void LoadProjectButton_Click(object sender, RoutedEventArgs e)
        {
            var folderSelectorDialog = new CommonOpenFileDialog
            {
                EnsureReadOnly = true,
                IsFolderPicker = true,
                AllowNonFileSystemItems = false,
                Multiselect = false,
                Title = "Cesta k projektu"
            };
            if (folderSelectorDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                _path = folderSelectorDialog.FileName;
                _isCalibration = false;
                loadCalibrationData.IsEnabled = false;
            }
            startButton.IsEnabled = true;
        }

        private void LoadCalibrationData_Click(object sender, RoutedEventArgs e)
        {
            var folderSelectorDialog = new CommonOpenFileDialog
            {
                EnsureReadOnly = true,
                IsFolderPicker = true,
                AllowNonFileSystemItems = false,
                Multiselect = false,
                Title = "Cesta k projektu"
            };
            if (folderSelectorDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                _path = folderSelectorDialog.FileName;
                _isCalibration = true;
                loadProjectButton.IsEnabled = false;
            }
            startButton.IsEnabled = true;
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            loadProjectButton.IsEnabled = true;
            loadCalibrationData.IsEnabled = true;
            startButton.IsEnabled = false;
            ProgressDialogController progress;
            try
            {
                if (_isCalibration)
                {
                    progress = await this.ShowProgressAsync("Probíhá kalibrace", "Chvilku to potrvá...");
                    progress.SetIndeterminate(); //Infinite
                    await Task.Run(() => _ccaFactory.Calibrate(_path));
                    await progress.CloseAsync();
                    await this.ShowMessageAsync("Hotovo", "Kalibrace dokončena, můžete nahrát projekt...");
                }
                else
                {
                    progress = await this.ShowProgressAsync("Probíhá analýza", "Chvilku to potrvá...");
                    progress.SetIndeterminate(); //Infinite
                    await Task.Run(() => _ccaFactory.Calibrate(_path));
                    await progress.CloseAsync();
                    await this.ShowMessageAsync("Hotovo", "Analýza dokončena...");
                }
            }
            catch
            {
                await this.ShowMessageAsync("Chyba!", "Pozor, došlo k neočekávané chybě");
            }
        }

        private void CalibrationDataButton_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, int> data = _ccaFactory.GetCalibrationData();
            StringBuilder sb = new StringBuilder();
            foreach (var kvp in data)
            {
                sb.AppendLine($"{kvp.Key}: {kvp.Value}");
            }
            MessageBox("Kalibrační data", sb.ToString());
        }

        private async void MessageBox(string title, string message)
        {
            await this.ShowMessageAsync(title, message);
        }
    }
}
