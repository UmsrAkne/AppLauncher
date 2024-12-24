using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using AppLauncher.Models;
using Prism.Mvvm;

namespace AppLauncher.ViewModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MainWindowViewModel : BindableBase
    {
        private string title = "App Launcher";

        public MainWindowViewModel()
        {
            SetDummies();
        }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public ApplicationListViewModel ApplicationListViewModel { get; set; } = new ();

        [Conditional("DEBUG")]
        private void SetDummies()
        {
            ApplicationListViewModel.ApplicationInfos = new ObservableCollection<ApplicationInfo>()
            {
                new ApplicationInfo()
                {
                    DisplayName = "Application1",
                    FullPath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\test\test.exe",
                },
                new ApplicationInfo()
                {
                    DisplayName = "bat1",
                    FullPath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\test\testbat.bat",
                },
                new ApplicationInfo() { DisplayName = "testName1", FullPath = @"C:\test\test1\test2\test3\text4", },
                new ApplicationInfo() { DisplayName = "testName2", FullPath = @"C:\test\test1\test2\test3\text4", },
                new ApplicationInfo() { DisplayName = "testName3", FullPath = @"C:\test\test1\test2\test3\text4", },
                new ApplicationInfo() { DisplayName = "testName4", FullPath = @"C:\test\test1\test2\test3\text4", },
                new ApplicationInfo() { DisplayName = "longLongLongTestName4", FullPath = @"C:\test\test1\test2\test3\text4", },
                new ApplicationInfo() { DisplayName = "testName1", FullPath = @"C:\test\test1\test2\test3\text4", },
                new ApplicationInfo() { DisplayName = "testName2", FullPath = @"C:\test\test1\test2\test3\text4", },
                new ApplicationInfo() { DisplayName = "testName3", FullPath = @"C:\test\test1\test2\test3\text4", },
                new ApplicationInfo() { DisplayName = "testName4", FullPath = @"C:\test\test1\test2\test3\text4", },
                new ApplicationInfo() { DisplayName = "longLongLongTestName4", FullPath = @"C:\test\test1\test2\test3\text4", },
                new ApplicationInfo() { DisplayName = "testName1", FullPath = @"C:\test\test1\test2\test3\text4", },
                new ApplicationInfo() { DisplayName = "testName2", FullPath = @"C:\test\test1\test2\test3\text4", },
                new ApplicationInfo() { DisplayName = "testName3", FullPath = @"C:\test\test1\test2\test3\text4", },
                new ApplicationInfo() { DisplayName = "testName4", FullPath = @"C:\test\test1\test2\test3\text4", },
                new ApplicationInfo() { DisplayName = "longLongLongTestName4", FullPath = @"C:\test\test1\test2\test3\text4", },
                new ApplicationInfo() { DisplayName = "testName1", FullPath = @"C:\test\test1\test2\test3\text4", },
                new ApplicationInfo() { DisplayName = "testName2", FullPath = @"C:\test\test1\test2\test3\text4", },
                new ApplicationInfo() { DisplayName = "testName3", FullPath = @"C:\test\test1\test2\test3\text4", },
                new ApplicationInfo() { DisplayName = "testName4", FullPath = @"C:\test\test1\test2\test3\text4", },
                new ApplicationInfo() { DisplayName = "longLongLongTestName4", FullPath = @"C:\test\test1\test2\test3\text4", },
            };
        }
    }
}