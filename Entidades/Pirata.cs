using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase Pirata que hereda de Barco y representa un barco de tipo Pirata.
    /// </summary>
    [Serializable]
    public class Pirata : Barco
    {
        /// <summary>
        /// Propiedad que obtiene o establece la cantidad de tripulación.
        /// Si la tripulación no está establecida, se genera un número aleatorio entre 10 y 30.
        /// </summary>
        public override int Tripulacion
        {
            get
            {
                if (this.tripulacion == 0)
                {
                    this.tripulacion = GenerarRandom.EnteroAleatrio(10, 30);
                }

                return this.tripulacion;
            }
            set => this.tripulacion = value;
        }

        /// <summary>
        /// Constructor por defecto para la clase Pirata.
        /// </summary>
        public Pirata()
        {

        }

        /// <summary>
        /// Constructor que inicializa una nueva instancia de la clase Pirata con los parámetros especificados.
        /// </summary>
        /// <param name="costo">Costo del barco.</param>
        /// <param name="estado">Estado de reparación del barco.</param>
        /// <param name="nombre">Nombre del barco.</param>
        /// <param name="operacion">Operación asociada al barco.</param>
        /// <param name="tripulacion">Cantidad de tripulación del barco.</param>
        public Pirata(float costo, bool estado, string nombre, EOperacion operacion, int tripulacion) : base(costo, estado, nombre, operacion, tripulacion)
        {

        }

        /// <summary>
        /// Método que calcula el costo del barco generando un número aleatorio entre 2000 y 12000.
        /// </summary>
        public override void CalcularCosto()
        {
            double numeroRandom;
            numeroRandom = GenerarRandom.DoubleAleatrio(2000, 12000);
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
