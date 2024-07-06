using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Marina:Barco
    {
        //Atributos
        //Propiedades
        public override int Tripulacion
        {
            get
            {
                if (Tripulacion == 0)
                {
                    Tripulacion = GenerarRandom.EnteroAleatrio(30, 60);
                }
                return Tripulacion;
            }
            set
            {
                return;
            }
        }
        //Constructores
        public Marina(float costo, bool estado, string nombre, EOperacion operacion, int tripulacion) : base(costo, estado, nombre, operacion, tripulacion)
        {

        }
        //Métodos
        public override void CalcularCosto()
        {
            double numeroRandom;
            numeroRandom = GenerarRandom.DoubleAleatrio(5000, 25000);
            this.costo = (float)numeroRandom;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Tripulación: {Tripulacion}");
            
            return sb.ToString();
        }
    }
}
