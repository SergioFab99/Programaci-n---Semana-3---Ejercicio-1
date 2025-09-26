using System;
using System.Collections.Generic;
using ProgramaciónSemana_3Ejercicio_1.Plantas;

namespace ProgramaciónSemana_3Ejercicio_1
{
    internal class Jugador
    {
        internal float Dinero { get; set; }
        internal List<Planta> PlantasEnCampo { get; private set; }
        internal List<string> SemillasDisponibles { get; private set; }

        internal Jugador(float dineroInicial)
        {
            Dinero = dineroInicial;
            PlantasEnCampo = new List<Planta>();
            SemillasDisponibles = new List<string> { "Tomate", "Lechuga" };
        }

        internal bool ComprarEspacio(int cantidad)
        {
            float precioTotal = cantidad * 10.0f;
            if (Dinero >= precioTotal)
            {
                Dinero -= precioTotal;
                return true;
            }
            return false;
        }

        internal bool ComprarSemilla(string tipo)
        {
            Planta planta = GetPlantaPorNombre(tipo);
            if (planta == null) return false;

            if (Dinero >= planta.ValorSemilla)
            {
                Dinero -= planta.ValorSemilla;
                PlantasEnCampo.Add(planta); // ya instancia concreta
                return true;
            }
            return false;
        }

        internal void PasarTurno()
        {
            foreach (var planta in PlantasEnCampo)
            {
                planta.Envejecer();
            }
        }

        internal List<Planta> GetPlantasListasParaCosechar()
        {
            return PlantasEnCampo.FindAll(p => p.ListoParaCosechar);
        }

        internal void MostrarPlantas()
        {
            Console.WriteLine("\n--- Plantas en el campo ---");
            for (int i = 0; i < PlantasEnCampo.Count; i++)
            {
                Console.WriteLine(string.Format("{0}. {1}", i + 1, PlantasEnCampo[i].ObtenerDescripcion()));
            }
        }

        internal float VenderPlanta(Planta planta)
        {
            float ingreso = planta.Cosechar();
            PlantasEnCampo.Remove(planta);
            return ingreso;
        }

        private Planta GetPlantaPorNombre(string nombre)
        {
            switch (nombre.ToLower())
            {
                case "tomate":
                    return new Tomate();
                case "lechuga":
                    return new Lechuga();
                default:
                    return null;
            }
        }
    }
}