using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace History
{
    public class HistoryManager
    {
        public void WriteHistory(string currentLine)
        {
            File.AppendAllText(@"C:/calcLog.txt", currentLine);
        }

        public string ReadHistory()
        {
            if (File.Exists(@"C:/calcLog.txt"))
            {
                using (StreamReader history = new StreamReader(@"C:/calcLog.txt", Encoding.Default))
                {
                    string text;
                    text = history.ReadToEnd();
                    return text;
                }
                
            }
            return "";
        }
    }
}
