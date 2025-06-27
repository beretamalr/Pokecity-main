using Pokecity.Models;
using System.Threading;
using System;
using AnsiConsole = Spectre.Console;

namespace Pokecity.Views
{
    public static class BatallaView
    {
        public static void MostrarEstadoBatalla(Pokemon jugador, Pokemon enemigo)
        {
            Console.WriteLine("\n--- Estado de la Batalla ---");
            Console.WriteLine($"Tu Pokémon: {jugador.Nombre} | Vida: {jugador.VidaActual}/{jugador.VidaMax}");
            Console.WriteLine($"Enemigo: {enemigo.Nombre} | Vida: {enemigo.VidaActual}/{enemigo.VidaMax}");
            Console.WriteLine("----------------------------\n");


        }

        public static int MostrarAccionesDisponibles(Entrenador jugador)
        {
            Console.WriteLine("Acciones disponibles:");
            Console.WriteLine($"1. Atacar");
            Console.WriteLine($"2. Usar Pocion ({jugador.Pociones} disponibles)");
            Console.WriteLine($"3. Usar Super Pocion ({jugador.SuperPociones} disponibles)");
            Console.WriteLine($"4. Capturar Pokémon ({jugador.Pokebolas} disponibles)");
            Console.WriteLine("5. Huir");
            Console.Write("Elige una acción (1-5): ");

            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 5)
            {
                Console.Write("Opción inválida. Por favor, elige una acción (1-5): ");
            }
            return opcion;
        }

        public static int MostrarMenuAtaques(Pokemon pokemon)
        {
            Console.WriteLine("\nElige un ataque:");
            for (int i = 0; i < pokemon.Ataques.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pokemon.Ataques[i].Nombre} (Daño: {pokemon.Ataques[i].Danio})");
            }
            Console.Write("Selecciona un ataque: ");
            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > pokemon.Ataques.Count)
            {
                Console.Write("Opción inválida. Selecciona un ataque: ");
            }
            return opcion - 1;
        }

        public static void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        public static void MostrarResultadoBatalla(bool victoria)
        {
            Console.WriteLine("\n--- Resultado de la Batalla ---");
            if (victoria)
                Console.WriteLine(@"
 _   _    _     _____   ____    _    _   _    _    ____   ___    _   __  
| | | |  / \   |__  /  / ___|  / \  | \ | |  / \  |  _ \ / _ \  | |  \ \ 
| |_| | / _ \    / /  | |  _  / _ \ |  \| | / _ \ | | | | | | | | | (_) |
|  _  |/ ___ \  / /_  | |_| |/ ___ \| |\  |/ ___ \| |_| | |_| | |_|  _| |
|_| |_/_/   \_\/____|  \____/_/   \_\_| \_/_/   \_\____/ \___/  (_) (_) |
                                                                     /_/ ");
            else
                Console.WriteLine(@"
 _   _    _     _____  ____  _____ ____  ____ ___ ____   ___    _      __
| | | |  / \   |__  / |  _ \| ____|  _ \|  _ \_ _|  _ \ / _ \  | |  _ / /
| |_| | / _ \    / /  | |_) |  _| | |_) | | | | || | | | | | | | | (_) | 
|  _  |/ ___ \  / /_  |  __/| |___|  _ <| |_| | || |_| | |_| | |_|  _| | 
|_| |_/_/   \_\/____| |_|   |_____|_| \_\____/___|____/ \___/  (_) (_) | 
                                                                      \_\");
            Console.WriteLine("-------------------------------\n");
        }
/*       public void cargaataque()
        {
            Thread ataqueThread = new Thread(() =>
            {
                string[] carga = { "", "", "", };
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"\r Cargando ataque... {carga[i % 3]}");
                    Thread.Sleep(200);

                }
                Console.WriteLine($"\r {jugador.Nombre} uso {ataque}        ");
            }
        }*/
    }
}