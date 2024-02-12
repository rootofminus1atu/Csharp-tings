﻿using System;
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

namespace first_attempt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string pasteThis = "Hellooo";
        private KeyboardHookManager keyboardHookManager;
        
        
        public MainWindow()
        {
            InitializeComponent();

            keyboardHookManager = new KeyboardHookManager();
            keyboardHookManager.Start();
            keyboardHookManager.RegisterHotkey(0x60, () =>
            {
                Debug.WriteLine("NumPad0 detected");
            });
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            // do this in the combobox

            Trace.WriteLine("WOA");

            var openWindowProcesses = Process.GetProcesses()
                .Where(p => p.MainWindowHandle != IntPtr.Zero && p.ProcessName != "explorer");

            foreach (var window in openWindowProcesses)
            {
                Trace.WriteLine(window.ProcessName);
            }

            Trace.WriteLine("WOA end");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }


        private void cbxWindows_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbxWindows_DropDownOpened(object sender, EventArgs e)
        {
            Trace.WriteLine("hii");
        }

        

        private void btnDoFunny_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Doing the funnny");



            Trace.WriteLine("before");

            System.Threading.Thread.Sleep(1000);

            

            Trace.WriteLine("after");
        }

        private void tabPasteEnter()
        {
            System.Windows.Forms.SendKeys.SendWait("{TAB}");
            System.Windows.Forms.SendKeys.SendWait(pasteThis);
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
        }

        private void btnKeyInput_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;

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

            this.KeyDown -= OnInputEvent;
            this.MouseDown -= OnInputEvent;
        }
    }
}
