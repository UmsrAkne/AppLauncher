using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using AppLauncher.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace AppLauncher.ViewModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MainWindowViewModel : BindableBase
    {
        private string title = "App Launcher";
        private ApplicationInfo inputApplicationInfo = new ();

        public MainWindowViewModel()
        {
            SetDummies();
        }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public ApplicationListViewModel ApplicationListViewModel { get; set; } = new ();

        public ApplicationInfo InputApplicationInfo
        {
            get => inputApplicationInfo;
            set => SetProperty(ref inputApplicationInfo, value);
        }

        public DelegateCommand RegisterAppCommand => new DelegateCommand(() =>
        {
            var info = InputApplicationInfo;
            if (string.IsNullOrWhiteSpace(info.DisplayName) || string.IsNullOrWhiteSpace(info.FullPath))
            {
                return;
            }

            ApplicationListViewModel.ApplicationInfos.Add(info);
            InputApplicationInfo = new ApplicationInfo();
        });

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