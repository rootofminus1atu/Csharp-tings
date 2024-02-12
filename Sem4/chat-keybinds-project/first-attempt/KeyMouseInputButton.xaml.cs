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
    /// Interaction logic for KeyMouseInputButton.xaml
    /// </summary>
    public partial class KeyMouseInputButton : UserControl
    {
        public KeyMouseInputButton()
        {
            InitializeComponent();
            UpdateButtonText();
        }

        private void btnKeyInput_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            // UpdateButtonText();

            this.KeyDown += OnInputEvent;
            this.MouseDown += OnInputEvent;

            Trace.WriteLine("Press any key or mouse button...");
        }

        private void OnInputEvent(object sender, RoutedEventArgs e)
        {
            if (e is KeyEventArgs keyArgs)
            {
                Trace.WriteLine($"Key pressed: {keyArgs.Key}");
            }
            else if (e is MouseButtonEventArgs mouseArgs)
            {
                Trace.WriteLine($"Mouse button pressed: {mouseArgs.ChangedButton}");
            }

            // UpdateButtonText();
            btnKeyInput.IsEnabled = true;

            this.KeyDown -= OnInputEvent;
            this.MouseDown -= OnInputEvent;
        }

        private void UpdateButtonText()
        {
            if (btnKeyInput.IsEnabled)
            {
                btnKeyInput.Content = "Click Me";
            }
            else
            {
                btnKeyInput.Content = "Press key or mouse button";
            }
        }
    }
}
