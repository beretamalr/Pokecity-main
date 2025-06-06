namespace Pokecity.Models
{
    public class Entrenador
    {
        public string Nombre { get; set; }
        public string Apodo { get; set; }
        public Pokemon PokemonActual { get; set; }
        public int Pociones { get; set; }
        public int SuperPociones { get; set; }
        public int Pokebolas { get; set; }

        public Entrenador(string nombre, string apodo, int pociones, int superPociones, int pokebolas)
        {
            Nombre = nombre;
            Apodo = apodo;
            Pociones = pociones;
            SuperPociones = superPociones;
            Pokebolas = pokebolas;
            PokemonActual = null!;
        }
    }
}