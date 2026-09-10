using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

        private void Button_Click_to_Bold(object sender, RoutedEventArgs e)
        {
            if (textBox.FontWeight == FontWeights.Normal)
            {
                textBox.FontWeight = FontWeights.Bold;
                imgBold.Opacity = 0.5;
                if (menuBold != null) menuBold.IsChecked = true;
            }
            else
            {
                textBox.FontWeight = FontWeights.Normal;
                imgBold.Opacity = 1;
                if (menuBold != null) menuBold.IsChecked = false;
            }
        }

        private void Button_Click_to_Itallic(object sender, RoutedEventArgs e)
        {
            if (textBox.FontStyle == FontStyles.Normal)
            {
                textBox.FontStyle = FontStyles.Italic;
                imgItalic.Opacity = 0.5;
                if (menuItalic != null) menuItalic.IsChecked = true;
            }
            else
            {
                textBox.FontStyle = FontStyles.Normal;
                imgItalic.Opacity = 1;
                if (menuItalic != null) menuItalic.IsChecked = false;
            }
        }

        private void Button_Click_to_Uderline(object sender, RoutedEventArgs e)
        {
            var underline = TextDecorations.Underline[0];
            if (textBox.TextDecorations.Contains(underline))
            {
                textBox.TextDecorations.Remove(underline);
                imgUnderline.Opacity = 1;
                if (menuUndrln != null) menuUndrln.IsChecked = false;
            }
            else
            {
                textBox.TextDecorations.Add(underline);
                imgUnderline.Opacity = 0.5;
                if (menuUndrln != null) menuUndrln.IsChecked = true;
            }
        }

        private void Button_Click_to_Strikethrough(object sender, RoutedEventArgs e)
        {
            var strikethrough = TextDecorations.Strikethrough[0];
            if (textBox.TextDecorations.Contains(strikethrough))
            {
                textBox.TextDecorations.Remove(strikethrough);
                imgStrikethrough.Opacity = 1;
                if (menuStrke != null) menuStrke.IsChecked = false;
            }
            else
            {
                textBox.TextDecorations.Add(strikethrough);
                imgStrikethrough.Opacity = 0.5;
                if (menuStrke != null) menuStrke.IsChecked = true;
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

        private void MenuItem_ClickOpen(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }

        }

        private void MenuItem_ClickSave(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void MenuItem_ClickShutdown(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Сохранить перед выходом?","Сохранение" ,MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                MenuItem_ClickSave(null, null);
            }
            System.Windows.Application.Current.Shutdown();
        }
    }
}