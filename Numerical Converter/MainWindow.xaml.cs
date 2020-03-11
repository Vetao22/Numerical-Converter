using System;
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

namespace Numerical_Converter
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = txtInput.Text;

            int convertionSelected = cmbChoice.SelectedIndex;

            if(convertionSelected == 0 || convertionSelected == 2)
            {
                txtInput.Text = RemoveLetters(text);
            }            
            MaxDigitsReached();

            txtInput.CaretIndex = txtInput.Text.Count();

        }

        string RemoveLetters(string text)
        {
            string result = "";

            foreach(char c in text)
            {
                if(Char.IsNumber(c))
                {
                    result += c;
                }
            }

            return result;
        }

        void MaxDigitsReached()
        {
            if(txtInput.Text.Count() == txtInput.MaxLength)
            {
                MessageBox.Show("You can type up to 8 digits", "Atention!", MessageBoxButton.OK, MessageBoxImage.Exclamation );
            }
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(txtInput.Text))
            {
                int convertionSelected = cmbChoice.SelectedIndex;
                string input = txtInput.Text;

                switch(convertionSelected)
                {
                    case 0:
                        txtResult.Text = Converter.DecToBin(input);
                        break;

                    case 1:
                        txtResult.Text = Converter.BinToDec(input);
                        break;

                    case 2:
                        txtResult.Text = Converter.DecToHex(input);
                        break;

                    case 3:
                        txtResult.Text = Converter.HexToDec(input);
                        break;

                    case 4:
                        txtResult.Text = Converter.BinToHex(input);
                        break;

                    case 5:
                        txtResult.Text = Converter.HexToBin(input);
                        break;
                }
                
            }
            
        }

        private void cmbChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtInput != null)
            {
                txtInput.Text = "";
            }
        }
    }
}
