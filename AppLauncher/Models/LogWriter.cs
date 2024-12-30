namespace AppLauncher.Models
{
    using System;
    using System.IO;

    public class LogWriter
    {
        private static readonly string LogFilePath = "log.txt";

        public static void AppendAppStartLog(string fileName)
        {
            AppendTextToFile(LogFilePath, $"{DateTime.Now} {fileName} を起動しました。");
        }

        public static void ErrorLog(string message)
        {
            AppendTextToFile(LogFilePath, $"{DateTime.Now} {message}");
        }

        /// <summary>
        /// 指定した場所にあるテキストファイルに、指定したテキストを追加で書き込みます。
        /// ファイルが存在しない場合は新しく作成します。
        /// </summary>
        /// <param name="filePath">テキストファイルのパス</param>
        /// <param name="textToAppend">追加するテキスト</param>
        private static void AppendTextToFile(string filePath, string textToAppend)
        {
            try
            {
                File.AppendAllText(filePath, textToAppend + Environment.NewLine);
                Console.WriteLine($"テキストを '{filePath}' に追加しました。");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"エラーが発生しました: {ex.Message}");
            }
        }
    }
}