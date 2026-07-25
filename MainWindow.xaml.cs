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
using static System.Net.Mime.MediaTypeNames;

namespace HW3_WpfApp_TextRedactor
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (textBox != null)
                textBox.FontFamily = new FontFamily(fontName);
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            double doubleFontSize = Convert.ToDouble(((sender as ComboBox).SelectedItem as TextBlock).Text);
            if (textBox != null)
                textBox.FontSize = doubleFontSize;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.FontWeight == FontWeights.Normal)
            {
                textBox.FontWeight = FontWeights.Bold;
                imgBold.Opacity = 0.5;
            }
            else
            {
                textBox.FontWeight = FontWeights.Normal;
                imgBold.Opacity = 1;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox.FontStyle == FontStyles.Normal)
            {
                textBox.FontStyle = FontStyles.Italic;
                imgItalic.Opacity = 0.5;
            }
            else
            {
                textBox.FontStyle = FontStyles.Normal;
                imgItalic.Opacity = 1;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var underline = TextDecorations.Underline[0];
            if (textBox.TextDecorations.Contains(underline))
            {
                textBox.TextDecorations.Remove(underline);
                imgUnderline.Opacity = 1;
            }
            else
            {
                textBox.TextDecorations.Add(underline);
                imgUnderline.Opacity = 0.5;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var strikethrough = TextDecorations.Strikethrough[0];
            if (textBox.TextDecorations.Contains(strikethrough))
            {
                textBox.TextDecorations.Remove(strikethrough);
                imgStrikethrough.Opacity = 1;
            }
            else
            {
                textBox.TextDecorations.Add(strikethrough);
                imgStrikethrough.Opacity = 0.5;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Black;
            }
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Red;
            }
        }
    }
}