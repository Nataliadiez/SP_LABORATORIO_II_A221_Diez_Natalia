using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Pirata : Barco
    {
        //Atributos
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

        //Constructores
        public Pirata()
        {

        }

        public Pirata(float costo, bool estado, string nombre, EOperacion operacion, int tripulacion) :base(costo, estado, nombre, operacion, tripulacion)
        {

        }

        //Métodos
        public override void CalcularCosto()
        {
            double numeroRandom;
            numeroRandom = GenerarRandom.DoubleAleatrio(2000, 12000);
            this.costo = (float)numeroRandom;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($" Tripulación: {Tripulacion}");
            return sb.ToString();
        }
    }
}
