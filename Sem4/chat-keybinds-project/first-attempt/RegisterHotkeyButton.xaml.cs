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

namespace first_attempt
{
    /// <summary>
    /// Represents a button that allows the user to pick a hotkey.
    /// Later on I hope it will be possible to trigger an event or pass the hotkey data back up to the MainWindow.
    /// </summary>
    public partial class RegisterHotkeyButton : UserControl
    {
        // boilerplate for passing in props
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(RegisterHotkeyButton), new PropertyMetadata(string.Empty));

        // boilerplate
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public RegisterHotkeyButton()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            btnRegister.Content = Text;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            this.KeyDown += ListenForKeyEvent;
            btnRegister.Content = "Press a key...";
        }

        private void ListenForKeyEvent(object sender, KeyEventArgs e)
        {
            if (e is KeyEventArgs keyArgs)
            {
                Trace.WriteLine($"Key pressed: {keyArgs.Key}");
                btnRegister.Content = $"{keyArgs.Key}";
                // triggering an event or modifying the data in the parent, or something else
                // coming soon
            }

            this.KeyDown -= ListenForKeyEvent;
        }
    }
}
