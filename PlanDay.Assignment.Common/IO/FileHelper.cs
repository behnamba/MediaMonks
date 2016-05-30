using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDay.Assignment.Common.IO
{
    public class FileHelper
    {
        public static void Writefile(string path, string content)
        {
            FileInfo fi = new FileInfo(path);

            string currentLog = ReadFile(path);

            using (TextWriter txtWriter = new StreamWriter(fi.Open(FileMode.OpenOrCreate)))
            {
                txtWriter.Write(string.Format("{0} {1}", currentLog, content));
            }
        }

        public static string ReadFile(string path)
        {
            return File.ReadAllText(path, Encoding.UTF8);
        }

        public static void Delete(string path)
        {
            FileInfo fi = new FileInfo(path);
            using (TextWriter txtWriter = new StreamWriter(fi.Open(FileMode.Truncate)))
            {
                txtWriter.Write("");
            }
        }
    }
}
