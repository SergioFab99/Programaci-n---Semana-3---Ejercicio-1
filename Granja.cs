using System;
using System.Collections.Generic;
using ProgramaciónSemana_3Ejercicio_1.Plantas;

namespace ProgramaciónSemana_3Ejercicio_1
{
    public class Granja
    {
        private Jugador Jugador { get; set; }

        public Granja(Jugador jugador)
        {
            Jugador = jugador;
        }

        public void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SIMULADOR DE GRANJA ===");
                Console.WriteLine($"Dinero actual: ${Jugador.Dinero:F2}");
                Console.WriteLine($"Plantas en campo: {Jugador.PlantasEnCampo.Count}");
                Console.WriteLine("\nOpciones:");
                Console.WriteLine("1. Comprar espacio ($10 cada uno)");
                Console.WriteLine("2. Comprar semilla");
                Console.WriteLine("3. Pasar turno");
                Console.WriteLine("4. Ver plantas");
                Console.WriteLine("5. Cosechar");
                Console.WriteLine("6. Salir");

                Console.Write("\nElige una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ComprarEspacio();
                        break;
                    case "2":
                        ComprarSemilla();
                        break;
                    case "3":
                        PasarTurno();
                        break;
                    case "4":
                        Jugador.MostrarPlantas();
                        Console.ReadKey();
                        break;
                    case "5":
                        Cosechar();
                        break;
                    case "6":
                        Console.WriteLine("Gracias por jugar!");
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ComprarEspacio()
        {
            Console.Write("¿Cuántos espacios quieres comprar? (precio: $10 cada uno): ");
            if (int.TryParse(Console.ReadLine(), out int cantidad))
            {
                if (Jugador.ComprarEspacio(cantidad))
                {
                    Console.WriteLine($"Compraste {cantidad} espacios.");
                }
                else
                {
                    Console.WriteLine("No tienes suficiente dinero.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
            Console.ReadKey();
        }

        private void ComprarSemilla()
        {
            Console.WriteLine("Semillas disponibles:");
            foreach (string s in Jugador.SemillasDisponibles)
            {
                Console.WriteLine($"- {s}");
            }

            Console.Write("¿Qué semilla quieres comprar? ");
            string tipo = Console.ReadLine();

            if (Jugador.ComprarSemilla(tipo))
            {
                Console.WriteLine($"Semilla de {tipo} comprada.");
            }
            else
            {
                Console.WriteLine("No tienes suficiente dinero o semilla no disponible.");
            }
            Console.ReadKey();
        }

        private void PasarTurno()
        {
            Jugador.PasarTurno();

            var listas = Jugador.GetPlantasListasParaCosechar();
            if (listas.Count > 0)
            {
                Console.WriteLine("\n⚠️ ¡Hay plantas listas para cosechar! Puedes cosechar ahora.");
            }
            else
            {
                Console.WriteLine("\n✅ No hay plantas listas para cosechar.");
            }

            Console.ReadKey();
        }

        private void Cosechar()
        {
            var listas = Jugador.GetPlantasListasParaCosechar();
            if (listas.Count == 0)
            {
                Console.WriteLine("No hay plantas listas para cosechar.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Plantas listas para cosechar:");
            for (int i = 0; i < listas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {listas[i]}");
            }

            Console.Write("Selecciona el número de la planta a cosechar: ");
            if (int.TryParse(Console.ReadLine(), out int indice) && indice >= 1 && indice <= listas.Count)
            {
                var planta = listas[indice - 1];
                float ingreso = Jugador.VenderPlanta(planta);
                Jugador.Dinero += ingreso;
                Console.WriteLine($"✔️ Cosechaste {planta.Nombre} y ganaste ${ingreso:F2}");
            }
            else
            {
                Console.WriteLine("Selección inválida.");
            }
            Console.ReadKey();
        }
    }
}