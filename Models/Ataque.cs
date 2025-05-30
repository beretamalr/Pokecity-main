namespace Pokecity
{
    public class Ataque
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int Danio { get; set; }

        public Ataque(string nombre, string tipo, int danio)
        {
            Nombre = nombre;
            Tipo = tipo;
            Danio = danio;
        }
    }
}