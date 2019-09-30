using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteConvercaoData
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Teste de convercao de datas");
            string data = "9/1/2019 12:00:00 AM";
            string mes = "09";

            DateTime dt;
            if (DateTime.TryParseExact(data,
                                        "M/d/yyyy hh:mm:ss tt",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None,
                out dt))
            {
                //valid date
            }
            else
            {
                //invalid date
            }

            if ((mes.StartsWith("0") ? mes.Substring(1, 1) : mes) == dt.Month.ToString())
            {
                Console.WriteLine("Ok");
            }

            Console.ReadLine();
        }
    }
}
