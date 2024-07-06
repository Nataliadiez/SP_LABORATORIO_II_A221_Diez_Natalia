using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
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
        }
        public bool EstadoReparado {
            get => estadoReparado;
        }
        public string Nombre {
            get => nombre;
        }
        public EOperacion Operacion {
            get => operacion;
        }

        public abstract int Tripulacion { get; }

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
        public bool CompararBarcos()
        {
            return true;
        }

        public abstract void CalcularCosto();


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Costo: {this.costo}");
            sb.AppendLine($"Estado de repacación: {this.estadoReparado}");
            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Operación: {this.operacion}");
            return sb.ToString();
        }

    }
}
