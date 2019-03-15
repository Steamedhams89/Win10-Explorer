﻿using Explorer.Entities;
using Explorer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Explorer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPageModel ViewModel { get; set; }

        public MainPage()
        {
            this.ViewModel = new MainPageModel();

            this.InitializeComponent();
            TextBoxPath.PreviewKeyDown += TextBoxPath_PreviewKeyDown;
        }

        private void TextBoxPath_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
                ViewModel.NavigateTo(new FileSystemElement { Path = TextBoxPath.Text });
        }

        private void OpenPowershell_Clicked(object sender, RoutedEventArgs e)
        {
            ViewModel.LaunchExe("C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe", $"-noexit -command \"cd {ViewModel.Path}\"");
        }
    }
}
