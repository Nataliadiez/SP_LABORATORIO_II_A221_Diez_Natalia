using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace Entidades
{
    /// <summary>
    /// Clase estática para generar números aleatorios.
    /// </summary>
    public static class GenerarRandom
    {
        /// <summary>
        /// Genera un número decimal aleatorio entre los valores especificados.
        /// </summary>
        /// <param name="num1">Valor mínimo.</param>
        /// <param name="num2">Valor máximo.</param>
        /// <returns>Un número decimal aleatorio redondeado a 2 decimales.</returns>
        public static double DoubleAleatrio(int num1, int num2)
        {
            double resultado;
            Random rnd = new Random();
            resultado = rnd.NextDouble() * (num2 - num1) + num1;
            return Math.Round(resultado, 2);
        }

        /// <summary>
        /// Genera un número entero aleatorio entre los valores especificados.
        /// </summary>
        /// <param name="num1">Valor mínimo.</param>
        /// <param name="num2">Valor máximo.</param>
        /// <returns>Un número entero aleatorio.</returns>
        public static int EnteroAleatrio(int num1, int num2)
        {
            int resultado;
            Random rnd = new Random();
            resultado = rnd.Next(num1, num2);
            return resultado;
        }
    }
}
