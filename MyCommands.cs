using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HW3_WpfApp_TextRedactor
{
    class MyCommands
    {
        public static RoutedCommand Bold {  get; set; }
        public static RoutedCommand Italic { get; set; }
        public static RoutedCommand Underlined { get; set; }
        public static RoutedCommand Strikethrough { get; set; }

        static MyCommands()
        {
            InputGestureCollection inputsBold = new InputGestureCollection();
            InputGestureCollection inputsItallic = new InputGestureCollection();
            InputGestureCollection inputsUnderlined = new InputGestureCollection();
            InputGestureCollection inputsStrikethrough = new InputGestureCollection();

            inputsBold.Add(new KeyGesture(Key.B, ModifierKeys.Control, "Ctrl+B"));
            inputsItallic.Add(new KeyGesture(Key.I, ModifierKeys.Control, "Ctrl+I"));
            inputsUnderlined.Add(new KeyGesture(Key.U, ModifierKeys.Control, "Ctrl+U"));
            inputsStrikethrough.Add(new KeyGesture(Key.M, ModifierKeys.Control, "Ctrl+M"));

            Bold = new RoutedCommand("Bold", typeof(MediaCommands), inputsBold);
            Italic = new RoutedCommand("Italic", typeof(MediaCommands), inputsItallic);
            Underlined = new RoutedCommand("Underlined", typeof(MediaCommands), inputsUnderlined);
            Strikethrough = new RoutedCommand("Strikethrough", typeof(MediaCommands), inputsStrikethrough);
        }
    }
}
