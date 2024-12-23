using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
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

        /// <summary>
        /// ApplicationListViewModel の中で、選択中のアイテムを起動します。<br/>
        /// 選択中のアイテムが無い場合や、無効なパスが入っている場合は処理をせず動作を終了します。
        /// </summary>
        public AsyncDelegateCommand ExecuteAppCommand => new AsyncDelegateCommand(async () =>
        {
            var appInfo = ApplicationListViewModel.SelectedItem;

            if (appInfo == null || !File.Exists(appInfo.FullPath))
            {
                return;
            }

            var filePath = appInfo.FullPath;

            if (File.Exists(filePath))
            {
                try
                {
                    await Task.Run(() =>
                    {
                        appInfo.Process = Process.Start(new ProcessStartInfo
                        {
                            FileName = filePath,
                            UseShellExecute = true,
                        });

                        appInfo.IsRunning = true;
                    });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Debug.WriteLine($"The file '{filePath}' does not exist.");
            }
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