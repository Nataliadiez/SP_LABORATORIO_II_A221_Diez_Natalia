using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase Marina que hereda de Barco y representa un barco de tipo Marina.
    /// </summary>
    [Serializable]
    public class Marina : Barco
    {
        /// <summary>
        /// Propiedad que obtiene o establece la cantidad de tripulación.
        /// Si la tripulación no está establecida, se genera un número aleatorio entre 30 y 60.
        /// </summary>
        public override int Tripulacion
        {
            get
            {
                if (this.tripulacion == 0)
                {
                    this.tripulacion = GenerarRandom.EnteroAleatrio(30, 60);
                }
                return this.tripulacion;
            }
            set => this.tripulacion = value;
        }

        /// <summary>
        /// Constructor por defecto para la clase Marina.
        /// </summary>
        public Marina()
        {

        }

        /// <summary>
        /// Constructor que inicializa una nueva instancia de la clase Marina con los parámetros especificados.
        /// </summary>
        /// <param name="costo">Costo del barco.</param>
        /// <param name="estado">Estado de reparación del barco.</param>
        /// <param name="nombre">Nombre del barco.</param>
        /// <param name="operacion">Operación asociada al barco.</param>
        /// <param name="tripulacion">Cantidad de tripulación del barco.</param>
        public Marina(float costo, bool estado, string nombre, EOperacion operacion, int tripulacion) : base(costo, estado, nombre, operacion, tripulacion)
        {

        }

        /// <summary>
        /// Método que calcula el costo del barco generando un número aleatorio entre 5000 y 25000.
        /// </summary>
        public override void CalcularCosto()
        {
            double numeroRandom;
            numeroRandom = GenerarRandom.DoubleAleatrio(5000, 25000);
            this.costo = (float)numeroRandom;
        }

        /// <summary>
        /// Método que devuelve una cadena que representa el objeto actual.
        /// </summary>
        /// <returns>Cadena que representa el objeto actual.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($" Tripulación: {Tripulacion}");

            return sb.ToString();
        }
    }
}
