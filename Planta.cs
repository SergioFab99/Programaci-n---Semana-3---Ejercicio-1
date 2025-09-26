using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaciónSemana_3Ejercicio_1.Plantas
{
    internal abstract class Planta
    {
        internal string Nombre { get; set; }
        internal int TiempoDeVida { get; set; }
        internal int FrutosPorCosecha { get; set; }
        internal float ValorSemilla { get; set; }
        internal float ValorProducto { get; set; }

        internal int Edad { get; private set; }

        internal bool ListoParaCosechar
        {
            get
            {
                return Edad >= TiempoDeVida;
            }
        }

        protected Planta(string nombre, int tiempoDeVida, int frutos, float valorSemilla, float valorProducto)
        {
            Nombre = nombre;
            TiempoDeVida = tiempoDeVida;
            FrutosPorCosecha = frutos;
            ValorSemilla = valorSemilla;
            ValorProducto = valorProducto;
            Edad = 0;
        }

        internal void Envejecer()
        {
            Edad++;
        }

        internal virtual float Cosechar()
        {
            return FrutosPorCosecha * ValorProducto;
        }

        // Metodo interno para reemplazar el antiguo ToString publico
        internal string ObtenerDescripcion()
        {
            return string.Format("{0} - Edad: {1}/{2}, Productos: {3}", Nombre, Edad, TiempoDeVida, FrutosPorCosecha);
        }
    }
}