using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaConsola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double resultado;
            Random rnd = new Random();
            resultado = rnd.NextDouble() * (12000 - 2000) + 2000;
            Console.WriteLine(Math.Round(resultado, 2));
            Console.ReadKey();
        }
    }
}
