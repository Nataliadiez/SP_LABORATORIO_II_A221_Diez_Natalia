using Entidades;
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
            Pirata barco1 = new Pirata(150, false, "El Holándes", EOperacion.Pintar, 5);
            

            //Console.WriteLine(barco1.ToString());
            Console.WriteLine(AccesoDatos.Guardar("Hola me llamo Natt"));
            Console.ReadKey();
        }
    }
}
