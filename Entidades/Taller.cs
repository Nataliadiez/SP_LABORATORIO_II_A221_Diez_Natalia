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
            this.barcos = new List<Barco>();
        }

        //Métodos
        public bool EncontrarBarco(Barco barco)
        {
            bool resultado;
            resultado = false;
            foreach (Barco barcoLista in this.barcos)
            {
                if (barcoLista.CompararBarcos(barco))
                {
                    resultado = true;
                    break;
                }
            }

            return resultado;
        }

        public Taller IngresarBarco(Barco barco)
        {
            if (this.EncontrarBarco(barco))
            {
                this.barcos.Add(barco);
            }
            return this;
        }
        public bool Reparar(Taller taller)
        {
            bool resultado;
            resultado = false;
            if(taller is Taller)
            {
                foreach (Barco barcoLista in ((Taller)taller).barcos)
                {
                    if (barcoLista.EstadoReparado == false)
                    {
                        barcoLista.CalcularCosto();
                        //guardar el costo en la base de datos. Ver qué le voy a pasar y usar try catch.
                        AccesoDatos.Guardar();
                        barcoLista.EstadoReparado = true;
                        resultado = true;
                    }
                }
            }
            return resultado;
        }

    }
}
