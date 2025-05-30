using System.Linq.Expressions;
using System.Reflection;
namespace Pokecity.Views
{
    public static class BatallaView
    {
        public static void MostrarEstadoBatalla(Models.Pokemon pokemonJugador, Models.Pokemon pokemonEnemigo)
        {
            Console.Clear();
            Console.WriteLine("Estado de la Batalla:");
            Console.WriteLine($"Pokémon : {pokemonJugador.Nombre} (Vida: {pokemonJugador.VidaActual}/{pokemonJugador.VidaMax})");
            Console.WriteLine($"Pokémon Enemigo: {pokemonEnemigo.Nombre} (Vida: {pokemonEnemigo.VidaActual}/{pokemonEnemigo.VidaMax})");
            Console.WriteLine();
        }
        public static void MostrarAccionesDisponibles()
        {
            Console.WriteLine("Acciones disponibles:");
            Console.WriteLine("1. Atacar");
            Console.WriteLine("2. Usar Pocion (" + entrenador.Pociones + " disponibles)");
            Console.WriteLine("3. Usar Super Pocion (" + entrenador.SuperPociones + " disponibles)");
            Console.WriteLine("4. Capturar Pokémon (" + entrenador.Pokebolas + " disponibles)");
            Console.WriteLine("5. Huir");
            Console.Write("Elige una acción (1-5): ");

            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion || opcion < 1 || opcion > 5))
            {
                Console.Write("Opción inválida. Por favor, elige una acción (1-5): ");
            }
            return opcion;
        }
        public static int MostrarMenuAtaques(Models.Pokemon pokemon)
        {
            Console.WriteLine("\n Elige un ataque:");
            for (int i = 0; i < pokemon.Ataques.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pokemon.Ataques[i].Nombre} (Daño: {pokemon.Ataques[i].Danio})");
            }
            int opcionAtaque;
            while (!int.TryParse(Console.ReadLine(), out opcionAtaque) || opcionAtaque < 1 || opcionAtaque > pokemon.Ataques.Count)
            {
                Console.Write("Opción inválida. Por favor, elige un ataque (1-" + pokemon.Ataques.Count + "): ");
            }
            return opcionAtaque - 1; // Restar 1 para que coincida con el índice de la lista
        }
        public static void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
        public static void MostrarResultadoBatalla(bool victoria)
        {
            Console.WriteLine("Resultado de la Batalla:");
            Console.WriteLine(victoria ? @"
 _   _    _     _____   ____    _    _   _    _    ____   ___    _   __  
| | | |  / \   |__  /  / ___|  / \  | \ | |  / \  |  _ \ / _ \  | |  \ \ 
| |_| | / _ \    / /  | |  _  / _ \ |  \| | / _ \ | | | | | | | | | (_) |
|  _  |/ ___ \  / /_  | |_| |/ ___ \| |\  |/ ___ \| |_| | |_| | |_|  _| |
|_| |_/_/   \_\/____|  \____/_/   \_\_| \_/_/   \_\____/ \___/  (_) (_) |
                                                                     /_/ " :
                                                                     @"
 _   _    _     _____  ____  _____ ____  ____ ___ ____   ___    _      __
| | | |  / \   |__  / |  _ \| ____|  _ \|  _ \_ _|  _ \ / _ \  | |  _ / /
| |_| | / _ \    / /  | |_) |  _| | |_) | | | | || | | | | | | | | (_) | 
|  _  |/ ___ \  / /_  |  __/| |___|  _ <| |_| | || |_| | |_| | |_|  _| | 
|_| |_/_/   \_\/____| |_|   |_____|_| \_\____/___|____/ \___/  (_) (_) | 
                                                                      \_\");
        }
    }
}