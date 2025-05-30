namespace Pokecity.Views
{
    public static class MenuView
    {
        public static void MostrarBienvenida()
        {
            // Mostrar mensaje de bienvenida al jugador con Ascii art
            Console.Clear();
                // Mostrar mensaje de bienvenida al jugador con Ascii art
            Console.Clear();
            Console.WriteLine(@"
                                            _ ____  _                           _     _           
                                            (_) __ )(_) ___ _ ____   _____ _ __ (_) __| | ___  ___ 
                                            | |  _ \| |/ _ \ '_ \ \ / / _ \ '_ \| |/ _` |/ _ \/ __|
                                            | | |_) | |  __/ | | \ V /  __/ | | | | (_| | (_) \__ \
                                            |_|____/|_|\___|_| |_|\_/ \___|_| |_|_|\__,_|\___/|___/
                                            ");

        }
        public static string SolicitarNombreEntrenador()
        {
            // Solicitar al jugador que ingrese su nombre
            Console.Write("Ingresa tu nombre de entrenador: ");
            return Console.ReadLine();
        }
        public static string SolicitarApodo()
        {
            // Solicitar al jugador que ingrese el apodo del entrenador
            Console.Write("Ingresa el apodo para tu entrenador: ");
            return Console.ReadLine();
        }

        public static void MostrarPokemonDisponibles(List<Models.Pokemon> pokemones)
        {
            Console.WriteLine("Pokémon disponibles:");
            for (int i = 0; i < pokemones.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pokemones[i].Nombre} - Tipo: {pokemones[i].Tipo} - Vida: {pokemones[i].VidaMax}");
                Console.WriteLine("      Ataques:");
                foreach (var ataque in pokemones[i].Ataques)
                {
                    Console.WriteLine($"        - {ataque.Nombre} (Daño: {ataque.Danio})");
                }
            }
        }
        
        public static int SolicitarSeleccionPokemon()
        {
            Console.WriteLine("\n Elige tu Pokemon (1-3): ");
            int eleccion;
            while (!int.TryParse(Console.ReadLine(), out eleccion) || eleccion < 1 || eleccion > 3)
            {
                Console.Write("Dato inválido. Por favor, elige un número entre 1 y 3: ");
            }
            return eleccion - 1; // Restar 1 para que coincida con el índice de la lista
        }
        public static void MostrarInicioBatalla(string entrenador, string pokemonJugador, string pokemonEnemigo)
        {
            Console.WriteLine($"¡{entrenador} ha elegido a {pokemonJugador}!");
            Console.WriteLine($"¡Un {pokemonEnemigo} salvaje aparece!");
            Console.WriteLine("¡La batalla comienza!");
        }
            
    }
}