using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase encargada de gestionar la serialización y deserialización de objetos en formato XML.
    /// </summary>
    public class XmlManager : IArchivos
    {
        /// <summary>
        /// Serializa la lista de barcos de un taller y la guarda en un archivo XML.
        /// </summary>
        /// <param name="path">Ruta del archivo donde se guardará la lista de barcos.</param>
        /// <param name="taller">Taller que contiene la lista de barcos a serializar.</param>
        /// <returns>Verdadero si se guardó exitosamente, falso en caso contrario.</returns>
        public bool Guardar(string path, Taller taller)
        {
            bool resultado = false;
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Barco>));
                    serializer.Serialize(streamWriter, taller.Barcos);
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return resultado;
        }

        /// <summary>
        /// Deserializa un archivo XML y obtiene la lista de barcos de un taller.
        /// </summary>
        /// <param name="path">Ruta del archivo XML a deserializar.</param>
        /// <returns>Lista de barcos deserializada del archivo XML.</returns>
        public List<Barco> Leer(string path)
        {
            Taller taller1 = new Taller();
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Barco>));
                    taller1.Barcos = (List<Barco>)deserializer.Deserialize(streamReader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return taller1.Barcos;
        }
    }
}
