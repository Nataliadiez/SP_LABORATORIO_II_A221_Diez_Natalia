using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Taller
    {
        //Atributos
        List<Barco> barcos;

        //Propiedades
        public List<Barco> Barcos 
        {
            get => this.barcos;
        }

        //Constructores
        public Taller()
        {

        }

        //Métodos
        public bool EncontrarBarco()
        {
            bool resultado;
            resultado = false;
            return resultado;
        }

        public Taller IngresarBarco()
        {
            Taller taller = new Taller();
            return taller;
        }

        public bool Reparar()
        {
            bool resultado;
            resultado = false;
            return resultado;
        }

    }
}
