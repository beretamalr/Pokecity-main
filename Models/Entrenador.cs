using Pokecity.Models;
namespace Pokecity
{
    public class Entrenador
    {
        public string Nombre { get; set; }
        public string Apodo { get; set; }
        public Pokemon PokemonActual { get; set; }
        public int Pociones { get; set; }
        public int SuperPociones { get; set; }
        public int Pokebolas { get; set; }

        public Entrenador(string nombre, string apodo)
        {
            Nombre = nombre;
            Apodo = apodo;
            Pociones = 3;
            SuperPociones = 1;
            Pokebolas = 5;
        }
    }
}