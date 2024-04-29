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
using GlobalHotKey;
using NHotkey.Wpf;
using NHotkey;
using NonInvasiveKeyboardHookLibrary;
using System.Runtime.InteropServices;

namespace first_attempt
{
    /// <summary>
    /// The app
    /// 
    /// I sadly was not able to record a video, but I wrote some comments to make it easier to understand what's being built here.
    /// Although this is a very heavy WIP, so it is messy and can get confusing.
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder text, int count);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder sb = new StringBuilder(nChars);
            IntPtr hWnd = GetForegroundWindow();

            if (hWnd != IntPtr.Zero)
            {
                GetWindowText(hWnd, sb, nChars);
            }

            return sb.ToString();
        }
        private string GetActiveProcessName()
        {
            IntPtr hwnd = GetForegroundWindow();
            uint processId;
            GetWindowThreadProcessId(hwnd, out processId);
            Process process = Process.GetProcessById((int)processId);
            return process.ProcessName;
        }

        /// <summary>
        /// Test variable to see if it's possible to past text automatically somewhere. It is!
        /// </summary>
        private string pasteThis = "Hellooo";

        /// <summary>
        /// The keyboard hook manager that will listen to keyboard presses and see if any hotkeys were pressed.
        /// </summary>
        private KeyboardHookManager keyboardHookManager;

        
        /// <summary>
        /// Currently using this as a way to keep track of what the user wants to say and what button should activate that.
        /// They will have an option to change the hotkey, the text, to add or delete new entries.
        /// </summary>
        public List<ThingToSay> thingsToSay = new()
        {
            new ThingToSay("Fire in the hole", null),
            new ThingToSay("Hello everyone", "H")
        };
        
        public MainWindow()
        {
            InitializeComponent();
            dgThingsToSay.ItemsSource = thingsToSay;

            // setting up the keyboard hook, currently just testing it out with a NumPad0 press
            keyboardHookManager = new KeyboardHookManager();
            keyboardHookManager.Start();
            keyboardHookManager.RegisterHotkey(0x60, () =>
            {
                Debug.WriteLine("NumPad0 detected");
                // get the current open window and print it to the console

                var currentWindow = GetActiveProcessName();
                Trace.WriteLine("Current Active Window: " + currentWindow);
            });
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // getting all open windows
            // doing that so that later we could allow the user to pick a configuration for a given open application
            // for example if they have Discord and Minecraft open, those 2 should show up from a dropdown
            // and then the user can pick a configuration for them
            // for example for Minecraft they can pick the chat button to be 'T'
            // while for discord the chat button would be 'Enter'
            var openWindowProcesses = Process.GetProcesses()
                .Where(p => p.MainWindowHandle != IntPtr.Zero && p.ProcessName != "explorer");

            // debug printing
            foreach (var window in openWindowProcesses)
            {
                Trace.WriteLine(window.ProcessName);
            }
        }

        private static IEnumerable<Process> GetProcesses()
        {
            return Process.GetProcesses()
                .Where(p => p.MainWindowHandle != IntPtr.Zero && p.ProcessName != "explorer");
        }



        /// <summary>
        /// For testing purposes.
        /// Testing how to click keys and write text on the behalf of the user.
        /// </summary>
        private void tabPasteEnter()
        {
            System.Windows.Forms.SendKeys.SendWait("{TAB}");
            System.Windows.Forms.SendKeys.SendWait(pasteThis);
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
        }

        private void cbxWindows_DropDownOpened(object sender, EventArgs e)
        {

        }

        private void cbxWindows_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnKeyInput_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
