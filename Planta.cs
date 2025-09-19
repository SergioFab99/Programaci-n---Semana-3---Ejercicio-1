using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaciónSemana_3Ejercicio_1.Plantas
{
    public abstract class Planta
    {
        public string Nombre { get; set; }
        public int TiempoDeVida { get; set; }
        public int FrutosPorCosecha { get; set; }
        public float ValorSemilla { get; set; }
        public float ValorProducto { get; set; }

        public int Edad { get; private set; }

        public bool ListoParaCosechar
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

        public void Envejecer()
        {
            Edad++;
        }

        public virtual float Cosechar()
        {
            return FrutosPorCosecha * ValorProducto;
        }

        public override string ToString()
        {
            return $"{Nombre} - Edad: {Edad}/{TiempoDeVida}, Productos: {FrutosPorCosecha}";
        }
    }
}