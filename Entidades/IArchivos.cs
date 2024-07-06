using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IArchivos
    {
        //Serializar
        bool Guardar(string path, Taller taller);
        //Deserializar
        List<Barco> Leer(string path);
    }
}
