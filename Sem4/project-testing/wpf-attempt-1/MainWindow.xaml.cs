using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
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

namespace wpf_attempt_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SoundPlayer soundPlayer = new SoundPlayer("vineboom.wav");
        private bool isListening = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnListening_Click(object sender, RoutedEventArgs e)
        {
            isListening = !isListening;
            ((Button)sender).Content = isListening ? "Stop Listening" : "Start Listening";
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            soundPlayer.Dispose();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Trace.WriteLine("keyyy");
        }
    }
}
