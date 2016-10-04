using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcHistory
{
    public class HistoryManager
    {
        public void WriteHistory(string currentLine)
        {
            File.AppendAllText(@"C:/calcLog.txt", currentLine);
        }

        public List<string> ReadHistory()
        {
            using (StreamReader history = new StreamReader(@"C:/calcLog.txt", System.Text.Encoding.Default))
            {
                List<string> lines = new List<string>();
                string line;
                while ((line = history.ReadLine()) != null)
                {
                    lines.Add(line);
                }

                return lines;
            }
        }
    }
}
