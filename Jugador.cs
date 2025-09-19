using System;
using System.Collections.Generic;
using ProgramaciónSemana_3Ejercicio_1.Plantas;

namespace ProgramaciónSemana_3Ejercicio_1
{
    public class Jugador
    {
        public float Dinero { get; set; }
        public List<Planta> PlantasEnCampo { get; private set; }
        public List<string> SemillasDisponibles { get; private set; }

        public Jugador(float dineroInicial)
        {
            Dinero = dineroInicial;
            PlantasEnCampo = new List<Planta>();
            SemillasDisponibles = new List<string> { "Tomate", "Lechuga" };
        }

        public bool ComprarEspacio(int cantidad)
        {
            float precioTotal = cantidad * 10.0f;
            if (Dinero >= precioTotal)
            {
                Dinero -= precioTotal;
                return true;
            }
            return false;
        }

        public bool ComprarSemilla(string tipo)
        {
            Planta planta = GetPlantaPorNombre(tipo);
            if (planta == null) return false;

            if (Dinero >= planta.ValorSemilla)
            {
                Dinero -= planta.ValorSemilla;
                PlantasEnCampo.Add(new PlantaBase(tipo));
                return true;
            }
            return false;
        }

        public void PasarTurno()
        {
            foreach (var planta in PlantasEnCampo)
            {
                planta.Envejecer();
            }
        }

        public List<Planta> GetPlantasListasParaCosechar()
        {
            return PlantasEnCampo.FindAll(p => p.ListoParaCosechar);
        }

        public void MostrarPlantas()
        {
            Console.WriteLine("\n--- Plantas en el campo ---");
            for (int i = 0; i < PlantasEnCampo.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {PlantasEnCampo[i]}");
            }
        }

        public float VenderPlanta(Planta planta)
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

    internal class PlantaBase : Planta
    {
        public PlantaBase(string nombre) : base(nombre, 0, 0, 0, 0) { }
    }
}