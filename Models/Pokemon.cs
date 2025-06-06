namespace Pokecity.Models
{
    public class Pokemon
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int VidaMax { get; set; }
        public int VidaActual { get; set; }
        public List<Ataque> Ataques { get; set; }

        public Pokemon(string nombre, string tipo, int vidaMax, List<Ataque> ataques)
        {
            Nombre = nombre;
            Tipo = tipo;
            VidaMax = vidaMax;
            VidaActual = vidaMax;
            Ataques = ataques ?? new List<Ataque>();
        }

        public void AgregarAtaque(Ataque ataque)
        {
            Ataques.Add(ataque);
        }

        public bool EstaDebilitado()
        {
            return VidaActual <= 0;
        }
    }

    
}