using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class XmlManager : IArchivos
    {
        public bool Guardar(string path, Taller taller)
        {
            bool resultado;
            resultado = false;
            try
            {
                using(StreamWriter streamWriter = new StreamWriter(path))
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
