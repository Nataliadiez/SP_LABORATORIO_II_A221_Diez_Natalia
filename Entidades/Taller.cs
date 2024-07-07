using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que representa un taller donde se reparan barcos.
    /// </summary>
    public class Taller
    {
        // Atributos
        private List<Barco> barcos;

        /// <summary>
        /// Propiedad que obtiene o establece la lista de barcos en el taller.
        /// </summary>
        public List<Barco> Barcos
        {
            get => this.barcos;
            set => this.barcos = value;
        }

        /// <summary>
        /// Constructor que inicializa una nueva instancia de la clase Taller.
        /// </summary>
        public Taller()
        {
            this.barcos = new List<Barco>();
        }

        /// <summary>
        /// Método que verifica si un barco ya se encuentra en el taller.
        /// </summary>
        /// <param name="barco">El barco a buscar.</param>
        /// <returns>Verdadero si el barco se encuentra en el taller, falso en caso contrario.</returns>
        public bool EncontrarBarco(Barco barco)
        {
            bool resultado = false;
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

        /// <summary>
        /// Método que ingresa un barco al taller si no se encuentra ya en él.
        /// </summary>
        /// <param name="barco">El barco a ingresar.</param>
        /// <returns>El taller actualizado.</returns>
        public Taller IngresarBarco(Barco barco)
        {
            if (!this.EncontrarBarco(barco))
            {
                this.barcos.Add(barco);
            }
            return this;
        }

        /// <summary>
        /// Método que repara todos los barcos que no están reparados en el taller.
        /// </summary>
        /// <param name="taller">El taller con los barcos a reparar.</param>
        /// <returns>Verdadero si al menos un barco fue reparado, falso en caso contrario.</returns>
        public bool Reparar(Taller taller)
        {
            bool resultado = false;
            foreach (Barco brco in taller.Barcos)
            {
                if (!brco.EstadoReparado)
                {
                    brco.CalcularCosto();
                    string mensaje = $"Se reparó el {brco.Nombre} a un costo de {brco.Costo} berries";
                    AccesoDatos.Guardar(mensaje);
                    brco.EstadoReparado = true;
                    resultado = true;
                }
            }

            return resultado;
        }
    }
}
