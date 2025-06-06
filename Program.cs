using Pokecity.Controllers;
using Pokecity.Models;
using Pokecity.Views;
namespace Pokecity
{
    class Program
    {
        static void Main(string[] args)
        {
            var juego = new BatallaController();
            juego.IniciarBatalla();

            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}