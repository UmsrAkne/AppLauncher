using System;
using System.Diagnostics;
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
        private Process process;

        public string FullPath { get => fullPath; set => SetProperty(ref fullPath, value); }

        public string DisplayName { get => displayName; set => SetProperty(ref displayName, value); }

        public bool IsRunning { get => isRunning; set => SetProperty(ref isRunning, value); }

        public Process Process { get => process; set => SetProperty(ref process, value); }

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
                Debug.WriteLine($"プロセスの終了中にエラーが発生しました: {ex.Message}");
                return;
            }

            try
            {
                Debug.WriteLine($"新しいアプリケーション {FullPath} を起動します...");
                Process = Process.Start(FullPath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"新しいアプリケーションの起動に失敗しました: {ex.Message}");
            }
        });
    }
}