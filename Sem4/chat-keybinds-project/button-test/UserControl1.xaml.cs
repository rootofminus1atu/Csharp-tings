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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void btnTestControl_Click(object sender, RoutedEventArgs e)
        {
            this.KeyDown += OnTestControlButtonInputEvent;
        }

        private void OnTestControlButtonInputEvent(object sender, RoutedEventArgs e)
        {
            if (e is KeyEventArgs keyArgs)
            {
                Trace.WriteLine($"Key pressed: {keyArgs.Key}");
            }

            this.KeyDown -= OnTestControlButtonInputEvent;
        }
    }
}
