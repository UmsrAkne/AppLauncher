namespace AppLauncher.Models
{
    /// <summary>
    /// ApplicationInfo を Json で記録、読み込みするのに、余分な情報を取り除いたクラスです。
    /// </summary>
    public class SimplifiedApplicationInfo
    {
        public string DisplayName { get; set; }

        public string FullPath { get; set; }
    }
}