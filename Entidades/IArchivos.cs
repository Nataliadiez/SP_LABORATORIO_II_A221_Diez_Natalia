using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interfaz para definir métodos de serialización y deserialización.
    /// </summary>
    public interface IArchivos
    {
        /// <summary>
        /// Serializa y guarda el objeto Taller en la ruta especificada.
        /// </summary>
        /// <param name="path">Ruta del archivo donde se guardará el Taller.</param>
        /// <param name="taller">Objeto Taller a serializar y guardar.</param>
        /// <returns>True si la operación fue exitosa, false en caso contrario.</returns>
        bool Guardar(string path, Taller taller);

        /// <summary>
        /// Deserializa y lee una lista de objetos Barco desde la ruta especificada.
        /// </summary>
        /// <param name="path">Ruta del archivo desde donde se leerán los objetos Barco.</param>
        /// <returns>Lista de objetos Barco deserializados.</returns>
        List<Barco> Leer(string path);
    }
}
