using EncryptPhoneNumbers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptPhoneNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Processamento de encriptação de números telefônicos.");
            Console.WriteLine("INICIANDO...");

            List<string> numbersFormat = new List<string>();
            string url = "https://www.xpto.com.br/c/";
            string saida = string.Empty;

            var numbers = Files.GetNumbers();

            foreach (var _numero in numbers)
            {
                string _formatado = _numero + "," + url + Base36.Encode(Convert.ToInt64(_numero)) + ";";
                numbersFormat.Add(_formatado);
            }

            Files.SalveFile(numbersFormat);

            Console.WriteLine("Convercao: {0}", saida);
            Console.WriteLine("Fim do processamento");
            Console.ReadLine();
        }
    }
}