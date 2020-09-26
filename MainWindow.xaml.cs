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


namespace NoEmptyMethods
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _mFileName = "No File Selected";
        private string _mFilePath = "";

        public MainWindow()
        {
            InitializeComponent();
            FileNameDisplay.Content = _mFileName;
        }

        private void Select_File_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "cSharp Files (*.cs)|*.cs|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                _mFileName = openFileDialog.SafeFileName;
                _mFilePath = openFileDialog.FileName;
                FileNameDisplay.Content = _mFileName;

            }

        }

        private void Run_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_mFilePath == "")
            {
                MessageBox.Show("Please Select a File!", "Error");
            }
            else
            {
                string text = File.ReadAllText(_mFilePath);
                text = RegExHandler.MatchAndDelete(text);
                File.WriteAllText("heyaBuddy.cs", text);
                MessageBox.Show("File Processed Successfully!", "Success");
            }
            }
        
    }
}
