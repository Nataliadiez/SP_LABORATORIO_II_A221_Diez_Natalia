using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace Entidades
{
    public static class GenerarRandom
    {
        public static double DoubleAleatrio(int num1, int num2)
        {
            double resultado;
            Random rnd = new Random();
            resultado = rnd.NextDouble() * (num2 - num1) + num1;
            return Math.Round(resultado, 2);
        }

        public static int EnteroAleatrio(int num1, int num2)
        {
            int resultado;
            Random rnd = new Random();
            resultado = rnd.Next(num1, num2);
            return resultado;
        }
    }
}
