using ProgramaciónSemana_3Ejercicio_1.Plantas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaciónSemana_3Ejercicio_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al Simulador de Granja!");

            Console.Write("Ingresa tu dinero inicial: ");
            string entrada = Console.ReadLine();
            float dineroInicial = 100f;
            if (!float.TryParse(entrada, out dineroInicial))
            {
                Console.WriteLine("Entrada inválida. Se usará $100 por defecto.");
            }

            Jugador jugador = new Jugador(dineroInicial);
            Granja granja = new Granja(jugador);

            granja.MostrarMenu();
        }
    }
}