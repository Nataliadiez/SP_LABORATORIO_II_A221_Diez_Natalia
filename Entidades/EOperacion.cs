using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Enumera las diferentes operaciones que se pueden realizar en un barco.
    /// </summary>
    public enum EOperacion
    {
        Reparar_Mastil,
        Pintar,
        Cambiar_Velas,
        Reparar_Mascaron,
        Repara_Casco,
        Recargar_Cañones
    }

    /// <summary>
    /// Enumera los tipos de barcos disponibles.
    /// </summary>
    public enum ETipoBarco
    {
        Pirata,
        Marina
    }
}
