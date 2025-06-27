//AGREGAR TIPO NATURALEZA A POKEMON Y CALCULOS DE DAÑO
namespace Pokecity.Models
{
    public class Pocion
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int VidaRestaurada { get; set; }

        public Pocion(string nombre, int cantidad, int vidaRestaurada)
        {
            Nombre = nombre;
            Cantidad = cantidad;
            VidaRestaurada = vidaRestaurada;
        }
    }
}