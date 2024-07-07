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
            set => this.barcos = value;
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
            foreach (Barco brco in this.barcos)
            {
                if (brco.CompararBarcos(barco))
                {
                    resultado = true;
                    break;
                }
            }
            return resultado;
        }

        public Taller IngresarBarco(Barco barco)
        {
            if (this.EncontrarBarco(barco) == false)
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
                foreach (Barco brco in ((Taller)taller).Barcos)
                {
                    if (brco.EstadoReparado == false)
                    {
                        brco.CalcularCosto();
                        string mensaje = $"Se reparó el {brco.Nombre} a un costo de {brco.Costo} berries";
                        AccesoDatos.Guardar(mensaje);
                        brco.EstadoReparado = true;
                        resultado = true;
                    }
                }
            }
            return resultado;
        }

    }
}
