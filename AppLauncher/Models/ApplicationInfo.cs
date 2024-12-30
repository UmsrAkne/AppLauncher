using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace AppLauncher.Models
{
    /// <summary>
    /// 起動可能なアプリケーションの実行ファイルのパスを中心とした情報を格納するためのクラスです。
    /// </summary>
    public class ApplicationInfo : BindableBase
    {
        private string fullPath = string.Empty;
        private string displayName = string.Empty;
        private bool isRunning;
        private bool canRestart;

        public string FullPath { get => fullPath; set => SetProperty(ref fullPath, value); }

        public string DisplayName { get => displayName; set => SetProperty(ref displayName, value); }

        public bool IsRunning { get => isRunning; set => SetProperty(ref isRunning, value); }

        public bool CanRestart { get => canRestart; set => SetProperty(ref canRestart, value); }

        public AsyncDelegateCommand RestartAppAsyncCommand => new AsyncDelegateCommand(async () =>
        {
            try
            {
                Process.Kill(); // プロセスを強制終了
                await Process.WaitForExitAsync(); // 終了を非同期で待機
                Process.Dispose();
            }
            catch (Exception ex)
            {
                LogWriter.ErrorLog($"プロセスの終了中にエラーが発生しました: {ex.Message}");
                return;
            }

            try
            {
                LogWriter.AppendAppStartLog(FullPath);
                await ExecuteAppCommand.ExecuteAsync();
            }
            catch (Exception ex)
            {
                LogWriter.ErrorLog($"新しいアプリケーションの起動に失敗しました: {ex.Message}");
                CanRestart = false;
            }
        });

        /// <summary>
        /// ApplicationListViewModel の中で、選択中のアイテムを起動します。<br/>
        /// 選択中のアイテムが無い場合や、無効なパスが入っている場合は処理をせず動作を終了します。
        /// </summary>
        public AsyncDelegateCommand ExecuteAppCommand => new AsyncDelegateCommand(async () =>
        {
            if (!File.Exists(FullPath) || IsRunning)
            {
                return;
            }

            var filePath = FullPath;

            if (File.Exists(filePath))
            {
                try
                {
                    await Task.Run(() =>
                    {
                        Process = Process.Start(new ProcessStartInfo
                        {
                            FileName = filePath,
                            UseShellExecute = true,
                        });

                        if (Process != null)
                        {
                            Process.EnableRaisingEvents = true;
                            Process.Exited += (_, _) =>
                            {
                                IsRunning = false;
                                CanRestart = false;
                            };
                        }

                        IsRunning = true;
                        CanRestart = true;
                        LogWriter.AppendAppStartLog(filePath);
                    });
                }
                catch (Exception ex)
                {
                    LogWriter.ErrorLog($"ファイルを開く際にエラーが発生しました: {ex.Message}");
                }
            }
            else
            {
                LogWriter.ErrorLog($"開こうとしたファイルが存在しません: {filePath}");
            }
        });

        private Process Process { get; set; }
    }
}