using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AppLauncher.Models;
using Prism.Mvvm;

namespace AppLauncher.ViewModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MainWindowViewModel : BindableBase
    {
        private const string JsonFilePath = "appInfos.json";
        private ApplicationInfo inputApplicationInfo = new ();

        public MainWindowViewModel()
        {
            SetDummies();
        }

        public TextWrapper TextWrapper { get; set; } = new ();

        public ApplicationListViewModel ApplicationListViewModel { get; set; } = new ();

        public ApplicationInfo InputApplicationInfo
        {
            get => inputApplicationInfo;
            private set => SetProperty(ref inputApplicationInfo, value);
        }

        public AsyncDelegateCommand RegisterAppCommand => new AsyncDelegateCommand(async () =>
        {
            var info = InputApplicationInfo;
            if (string.IsNullOrWhiteSpace(info.DisplayName) || string.IsNullOrWhiteSpace(info.FullPath))
            {
                return;
            }

            ApplicationListViewModel.ApplicationInfos.Add(info);
            InputApplicationInfo = new ApplicationInfo();

            await SaveToJsonAsync();
        });

        /// <summary>
        /// JSON からリストを読み込んで追加します。アプリの起動時のイベントに合わせて実行します。
        /// </summary>
        public AsyncDelegateCommand LoadFromJsonAsync => new AsyncDelegateCommand(async () =>
        {
            if (!File.Exists(JsonFilePath))
            {
                return;
            }

            try
            {
                var json = await File.ReadAllTextAsync(JsonFilePath);
                var simplifiedList = JsonSerializer.Deserialize<List<SimplifiedApplicationInfo>>(json);

                if (simplifiedList != null)
                {
                    foreach (var item in simplifiedList)
                    {
                        ApplicationListViewModel.ApplicationInfos.Add(new ApplicationInfo
                        {
                            DisplayName = item.DisplayName,
                            FullPath = item.FullPath,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"エラー: JSON 読み込み中に問題が発生しました。{ex.Message}");
            }
        });

        /// <summary>
        /// JSON にリストを保存します。
        /// </summary>
        private async Task SaveToJsonAsync()
        {
            try
            {
                var simplifiedList = ApplicationListViewModel.ApplicationInfos
                    .Select(app => new SimplifiedApplicationInfo
                    {
                        DisplayName = app.DisplayName,
                        FullPath = app.FullPath,
                    })
                    .ToList();

                var json = JsonSerializer.Serialize(simplifiedList, new JsonSerializerOptions
                {
                    WriteIndented = true, // 整形された JSON にする
                });

                await File.WriteAllTextAsync(JsonFilePath, json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"エラー: JSON 保存中に問題が発生しました。{ex.Message}");
            }
        }

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
                    FullPath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\test\testBat.bat",
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