using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GenerarRandom
    {
        public static double DoubleAleatrio()
        {
            double resultado;
            Random rnd = new Random();
            resultado = rnd.NextDouble();
            return resultado;
        }

        public static int EnteroAleatrio()
        {
            int resultado;
            Random rnd = new Random();
            resultado = rnd.Next();
            return resultado;
        }
    }
}
