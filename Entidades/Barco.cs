using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public abstract class Barco
    {
        //Atributos
        protected float costo;
        protected bool estadoReparado;
        protected string nombre;
        protected EOperacion operacion;
        protected int tripulacion;

        //Propiedades
        public float Costo {
            get => costo;
            set => costo = value;
        }
        public bool EstadoReparado {
            get => estadoReparado;
            set => estadoReparado = value;
        }
        public string Nombre {
            get => nombre; 
            set => nombre = value;
        }
        public EOperacion Operacion {
            get => operacion; 
            set => operacion = value;
        }

        public abstract int Tripulacion { get; set; }

        //Constructores
        public Barco()
        {

        }
       
        public Barco(float costo, bool estado, string nombre, EOperacion operacion, int tripulacion)
        {
            this.costo = costo;
            this.estadoReparado= estado;
            this.nombre = nombre;
            this.operacion = operacion;
            this.tripulacion = tripulacion;
        }

        //Métodos
        public bool CompararBarcos(Barco barco)
        {
            bool resultado;
            resultado = false;
            if (this.Nombre == barco.Nombre)
            {
                resultado = true;
            }
            return resultado;
        }

        public abstract void CalcularCosto();


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Estado de repacación: {this.estadoReparado}");
            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Operación: {this.operacion}");
            sb.AppendLine($"Costo: {this.costo}");
            return sb.ToString();
        }

    }
}
