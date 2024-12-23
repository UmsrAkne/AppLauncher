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

        public ObservableCollection<ApplicationInfo> ApplicationInfos { get; private set; } = new ();

        [Conditional("DEBUG")]
        private void SetDummies()
        {
            ApplicationInfos = new ObservableCollection<ApplicationInfo>()
            {
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