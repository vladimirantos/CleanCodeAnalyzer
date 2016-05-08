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
using Cleaner;
using Cleaner.Comparator;
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
        private readonly CcaFactory _ccaFactory = new CcaFactory();
        private bool _isCalibration = false;
        public MainWindow()
        {
            InitializeComponent();
            StartButton.IsEnabled = false;
            ShowGraphButton.IsEnabled = false;
            if (!_ccaFactory.CalibrationDataExists())
            {
                StatusBar.Text = "Chybí kalibrační data";
                CalibrationDataButton.IsEnabled = false;
            }
            ShowGraphButton.IsEnabled = true;
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
                LoadCalibrationData.IsEnabled = false;
                StatusBar.Text = "Byl vložen projekt " + _path;
            }
            StartButton.IsEnabled = true;
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
                LoadProjectButton.IsEnabled = false;
                StatusBar.Text = "Byl vložen kalibrační projekt " + _path;
            }
            StartButton.IsEnabled = true;
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            LoadProjectButton.IsEnabled = true;
            LoadCalibrationData.IsEnabled = true;
            StartButton.IsEnabled = false;
            ProgressDialogController progress;
            try
            {
                if (_isCalibration)
                {
                    progress = await this.ShowProgressAsync("Probíhá kalibrace", "Chvilku to potrvá...");
                    progress.SetIndeterminate();
                    await Task.Run(() => _ccaFactory.Calibrate(_path));
                    await progress.CloseAsync();
                    await this.ShowMessageAsync("Hotovo", "Kalibrace dokončena, můžete nahrát projekt...");
                    StatusBar.Text = "Kalibrace byla dokončena. Nahrajte projekt k analýze";
                    CalibrationDataButton.IsEnabled = true;
                }
                else
                {
                    progress = await this.ShowProgressAsync("Probíhá analýza", "Chvilku to potrvá...");
                    progress.SetIndeterminate();
                    await Task.Run(() => _ccaFactory.Analyze(_path));
                    await progress.CloseAsync();
                    await this.ShowMessageAsync("Hotovo", "Analýza dokončena...");
                    ShowTable(_ccaFactory.Result);
                    StatusBar.Text = "Analýza byla dokončena";
                    ShowGraphButton.IsEnabled = true;
                }
            }
            catch (CcaException ex)
            {
                await this.ShowMessageAsync("Chyba!", ex.Message);
            }
            //catch(Exception)
            //{
            //   await this.ShowMessageAsync("Chyba!", "Došlo k neočekávané chybě...");
            //}
            
        }

        private void CalibrationDataButton_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, float> data = _ccaFactory.GetCalibrationData();
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

        private void ShowTable(List<CcaResult> results)
        {
            DataGridBinder binder = new DataGridBinder(results);
            DataGrid.ItemsSource = binder.GetData();
        }

        private void ShowGraphButton_Click(object sender, RoutedEventArgs e)
        {
            ToxicityGraph tg = new ToxicityGraph(_ccaFactory.Result);
            tg.Show();
        }
    }
}
