using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace PG
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

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            int passwordLength = Convert.ToInt32(passwordLengthText.Text);
            Random random = new Random();
            char[] password = new char[passwordLength];
            string alphabet = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890_";
            for (int i = 0; i < passwordLength; i++)
            {
                password[i] = alphabet[random.Next(0, alphabet.Length - 1)];
            }
            resultPassword.Text = resultPassword.Text + "\n" + nameSurname.Text + " - " + new string(password);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)//запрет на ввод других симоволов
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ClearField_Click(object sender, RoutedEventArgs e)
        {
            resultPassword.Text = "";          
        }
        
        private void SaveToFile_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter saveToFile = new StreamWriter("password.txt")) 
            {
                saveToFile.Write(resultPassword.Text);
            }
            System.Windows.Forms.MessageBox.Show("File save complete", "PG Save");
        }

        private void NameSurname_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            nameSurname.Text = "";
        }

        private void PasswordLengthText_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordLengthText.SelectAll();
        }
    }
}
