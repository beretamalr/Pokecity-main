using System.ComponentModel.Design;
using Pokecity.Models;
namespace Pokecity.Controllers
{
    public class BatallaControllers
    {
        private Entrenador jugador;
        private Batalla batallaActual;
        private List<Pokemon> pokemonesDisponibles;

        public void BatallaController()
        {
            InicializarPokemones();
        }
        private void InicializarPokemones()
        {
            pokemonesDisponibles = new List<Pokemon>();
            //CREACION POKEMONES PRINCIPALES    
            var charmander = new Pokemon("Charmander", "Fuego", 100);
            charmander.AñadirAtaque(new Ataque("Lanzallamas", "Fuego", 25));
            charmander.AñadirAtaque(new Ataque("Arañazo", "Normal", 10));
            pokemonesDisponibles.Add(charmander);

            var squirtle = new Pokemon("Squirtle", "Agua", 100);
            squirtle.AñadirAtaque(new Ataque("Pistola Agua", "Agua", 25));
            squirtle.AñadirAtaque(new Ataque("Placaje", "Normal", 10));
            pokemonesDisponibles.Add(squirtle);

            var bulbasaur = new Pokemon("Bulbasaur", "Planta", 100);
            bulbasaur.AñadirAtaque(new Ataque("Látigo Cepa", "Planta", 25));
            bulbasaur.AñadirAtaque(new Ataque("Drenaje", "Planta", 10));
            pokemonesDisponibles.Add(bulbasaur);
        }
        public void IniciarBatalla()
        {
            MenuView.MostrarBienvenida();
            string nombreEntrenador = MenuView.SolicitarNombreEntrenador();
            string apodoEntrenador = MenuView.SolicitarApodo();
            jugador = new Entrenador(nombre, apodo);

            MenuView.MostrarPokemonDisponibles(pokemonesDisponibles);
            int eleccion = MenuView.SolicitarSeleccionPokemon();
            jugador.PokemonActual = pokemonesDisponibles[eleccion];

            // Crear un Pokémon enemigo aleatorio
            var enemigo = pokemonesDisponibles[new Random().Next(pokemonesDisponibles.Count)];
            while (enemigo.Nombre == jugador.PokemonActual.Nombre)
            {
                enemigo = pokemonesDisponibles[new Random().Next(0, pokemonesDisponibles.Count)];
            }
            batallaActual = new Batalla(jugador, enemigo);
            MenuView.MostrarInicioBatalla(jugador.Nombre, jugador.PokemonActual.Nombre, enemigo.Nombre);

            IniciarBatalla();
        }
        private void IniciarBatallaConEntrenador()

        {
            while (batallaActual.BatallaEnCurso)
            {
                BatallaView.MostrarEstadoBatalla(jugador.PokemonActual, batallaActual.PokemonEnemigo);

                int opcion = BatallaView.MostrarAccionesDisponibles(jugador);
                string mensaje = "";

                switch (opcion)
                {
                    case 1:
                        int ataqueSeleccionado = BatallaView.MostrarMenuAtaques(jugador.PokemonActual);
                        mensaje = batallaActual.Atacar(jugador.PokemonActual.Ataques[ataqueSeleccionado]);
                        break;
                    case 2:
                        mensaje = batallaActual.UsarPocion();
                        break;
                    case 3:
                        mensaje = batallaActual.UsarSuperPocion();
                        break;
                    case 4:
                        mensaje = batallaActual.CapturarPokemon();
                        break;
                    case 5:
                        mensaje = batallaActual.IntentarHuir();
                        break;
                }
                BatallaView.MostrarMensaje(mensaje);

                if (!batallaActual.BatallaEnCurso) break;

                if (!batallaActual.PokemonEnemigo.EstaDebilitado())
                {
                    string mensajeEnemigo = batallaActual.AtaqueEnemigo();
                    BatallaView.MostrarMensaje(mensajeEnemigo);
                }

                if (batallaActual.VerificarFinBatalla())
                {
                    bool victoria = batallaActual.PokemonEnemigo.EstaDebilitado();
                    BatallaView.MostrarResultadoBatalla(victoria);
                    break;
                }
            }
        }
    }
}