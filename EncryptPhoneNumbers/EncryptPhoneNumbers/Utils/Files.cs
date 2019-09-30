using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptPhoneNumbers.Utils
{
    public static class Files
    {
        public static List<string> GetNumbers()
        {
            List<string> numbers = new List<string>();
            string filePath = @"C:\ArquivosETL\ReadFile.csv";
            StreamReader reader = new StreamReader(File.OpenRead(filePath));            

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (!String.IsNullOrWhiteSpace(line))
                {
                    numbers.Add(line);
                }
            }

            numbers.Add("var numbers");

            return numbers;
        }

        public static bool SalveFile(List<string> numbersEncrypt)
        {
            bool validate = false;
            string newLine = string.Empty;
            string path = @"C:\ArquivosETL";
            string filePath = @"C:\ArquivosETL\CreateFile.csv";

            var csv = new StringBuilder();

            try
            {
                foreach (var item in numbersEncrypt)
                {
                    newLine = string.Format("{0}", item);
                    csv.AppendLine(newLine);
                }

                csv.AppendLine(newLine);

                using (FileStream fs = File.Create(filePath))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                    fs.Write(info, 0, info.Length);
                }

                File.WriteAllText(filePath, csv.ToString());
                validate = true;
            }
            catch (Exception ex)
            {
                validate = false;
            }

            return validate;
        }
    }
}
