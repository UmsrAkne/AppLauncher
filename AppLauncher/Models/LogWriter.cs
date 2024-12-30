namespace AppLauncher.Models
{
    using System;
    using System.IO;

    public static class LogWriter
    {
        private static readonly string LogFilePath = "log.txt";

        public static void AppendAppStartLog(string fileName)
        {
            AppendTextToFile($"{DateTime.Now} {fileName} を起動しました。");
        }

        public static void ErrorLog(string message)
        {
            AppendTextToFile($"{DateTime.Now} {message}");
        }

        /// <summary>
        /// 指定した場所にあるテキストファイルに、指定したテキストを追加で書き込みます。
        /// ファイルが存在しない場合は新しく作成します。
        /// </summary>
        /// <param name="textToAppend">追加するテキスト</param>
        private static void AppendTextToFile(string textToAppend)
        {
            try
            {
                File.AppendAllText(LogFilePath, textToAppend + Environment.NewLine);
                Console.WriteLine($"テキストを '{LogFilePath}' に追加しました。");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"エラーが発生しました: {ex.Message}");
            }
        }
    }
}