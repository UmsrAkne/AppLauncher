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
    }
}