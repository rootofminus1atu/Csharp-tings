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

namespace button_test
{
    /// <summary>
    /// Interaction logic for CustomInput.xaml
    /// </summary>
    public partial class CustomInput : UserControl
    {
        public CustomInput()
        {
            InitializeComponent();
            UpdateButtonText();
        }

        private void btnKeyInput_Click(object sender, RoutedEventArgs e)
        {
            btnKeyInput.IsEnabled = false;
            UpdateButtonText();

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

            btnKeyInput.IsEnabled = true;
            UpdateButtonText();

            this.KeyDown -= OnInputEvent;
            this.MouseDown -= OnInputEvent;
        }

        private void UpdateButtonText()
        {
            if (btnKeyInput.IsEnabled)
            {
                btnKeyInput.Content = "Key chosen";
            }
            else
            {
                btnKeyInput.Content = "Press a key";
            }
        }
    }
}
