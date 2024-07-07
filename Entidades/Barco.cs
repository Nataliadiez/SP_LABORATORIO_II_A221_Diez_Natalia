using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Pirata))]
    [XmlInclude(typeof(Marina))]
    public abstract class Barco
    {
        // Atributos
        protected float costo;
        protected bool estadoReparado;
        protected string nombre;
        protected EOperacion operacion;
        protected int tripulacion;

        // Propiedades
        /// <summary>
        /// Obtiene o establece el costo del barco.
        /// </summary>
        public float Costo
        {
            get => costo;
            set => costo = value;
        }

        /// <summary>
        /// Obtiene o establece el estado de reparación del barco.
        /// </summary>
        public bool EstadoReparado
        {
            get => estadoReparado;
            set => estadoReparado = value;
        }

        /// <summary>
        /// Obtiene o establece el nombre del barco.
        /// </summary>
        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        /// <summary>
        /// Obtiene o establece la operación del barco.
        /// </summary>
        public EOperacion Operacion
        {
            get => operacion;
            set => operacion = value;
        }

        /// <summary>
        /// Obtiene o establece la tripulación del barco.
        /// </summary>
        public abstract int Tripulacion { get; set; }

        // Constructores
        /// <summary>
        /// Constructor por defecto para la serialización.
        /// </summary>
        public Barco()
        {
        }

        /// <summary>
        /// Constructor que inicializa un barco con los valores especificados.
        /// </summary>
        /// <param name="costo">Costo del barco.</param>
        /// <param name="estado">Estado de reparación del barco.</param>
        /// <param name="nombre">Nombre del barco.</param>
        /// <param name="operacion">Operación del barco.</param>
        /// <param name="tripulacion">Tripulación del barco.</param>
        public Barco(float costo, bool estado, string nombre, EOperacion operacion, int tripulacion)
        {
            this.costo = costo;
            this.estadoReparado = estado;
            this.nombre = nombre;
            this.operacion = operacion;
            this.tripulacion = tripulacion;
        }

        // Métodos
        /// <summary>
        /// Compara dos barcos por su nombre.
        /// </summary>
        /// <param name="barco">El barco a comparar.</param>
        /// <returns>True si los nombres son iguales, False en caso contrario.</returns>
        public bool CompararBarcos(Barco barco)
        {
            bool resultado = false;
            if (this.Nombre == barco.Nombre)
            {
                resultado = true;
            }
            return resultado;
        }

        /// <summary>
        /// Método abstracto que se implementa en las clases derivadas para calcular el costo del barco.
        /// </summary>
        public abstract void CalcularCosto();

        /// <summary>
        /// Devuelve una cadena que representa el estado actual del barco.
        /// </summary>
        /// <returns>Una cadena con la información del barco.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Estado de reparación: {this.estadoReparado}");
            sb.AppendLine($" Nombre: {this.nombre}");
            sb.AppendLine($" Operación: {this.operacion}");
            sb.AppendLine($" Costo: {this.costo}");
            return sb.ToString();
        }
    }
}
