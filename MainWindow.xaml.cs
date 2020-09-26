using System;
using System.IO;
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

using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;


namespace NoEmptyMethods
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _mFolderName = "No Folder Selected";
        private string _mFolderPath = "";
        private string[] _mFiles;

        public MainWindow()
        {
            InitializeComponent();
            FolderNameDisplay.Text = _mFolderName;
        }

        private void Select_Folder_Button_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.Forms.FolderBrowserDialog openBrowserDialog = new FolderBrowserDialog();

            var dlg = new CommonOpenFileDialog();
            dlg.Title = "My Title";
            dlg.IsFolderPicker = true;
            //dlg.InitialDirectory = currentDirectory;

            dlg.AddToMostRecentlyUsedList = false;
            dlg.AllowNonFileSystemItems = false;
            //dlg.DefaultDirectory = currentDirectory;
            dlg.EnsureFileExists = true;
            dlg.EnsurePathExists = true;
            dlg.EnsureReadOnly = false;
            dlg.EnsureValidNames = true;
            dlg.Multiselect = false;
            dlg.ShowPlacesList = true;

            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                _mFolderPath = dlg.FileName;
                //_mFolderName = openBrowserDialog.SafeFileName;
                //_mFolderPath = openBrowserDialog.FileName;
                FolderNameDisplay.Text = _mFolderPath;
                _mFiles = Directory.GetFiles(_mFolderPath, "*.cs", SearchOption.AllDirectories);
            }

            /*
            openBrowserDialog.Filter = "cSharp Files (*.cs)|*.cs|All files (*.*)|*.*";
            if (openBrowserDialog.ShowDialog() == true)
            {
                _mFolderName = openBrowserDialog.SafeFileName;
                _mFolderPath = openBrowserDialog.FileName;
                FileNameDisplay.Content = _mFolderName;
                string[] files = Directory.GetFiles(_mFolderPath, "*.cs", SearchOption.AllDirectories);

            }
            */

        }

        private void Run_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_mFolderPath == "")
            {
                MessageBox.Show("Please Select a Folder!", "Error");
            }
            else
            {
                foreach (string filepath in _mFiles)
                {
                    string text = File.ReadAllText(filepath);
                    text = RegExHandler.MatchAndDelete(text);
                    File.WriteAllText(filepath, text);
                }

            }

            MessageBox.Show("Folder Processed Successfully!", "Success");

        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();

        }
    }
}
