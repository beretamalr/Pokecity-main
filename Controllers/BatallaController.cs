using Pokecity.Models;
using Pokecity.Views;
using System;
using System.Collections.Generic;

namespace Pokecity.Controllers
{
    public class BatallaController
    {
        private Entrenador jugador = null!;
private Batalla batallaActual = null!;
private List<Pokemon> pokemonesDisponibles = new List<Pokemon>();

        public BatallaController()
        {
            InicializarPokemones();
        }

        private void InicializarPokemones()
        {
            pokemonesDisponibles = new List<Pokemon>();

            var charmander = new Pokemon("Charmander", "Fuego", 100, new List<Ataque>());
            charmander.AgregarAtaque(new Ataque("Lanzallamas", "Fuego", 25));
            charmander.AgregarAtaque(new Ataque("Arañazo", "Normal", 10));
            pokemonesDisponibles.Add(charmander);

            var squirtle = new Pokemon("Squirtle", "Agua", 100, new List<Ataque>());
            squirtle.AgregarAtaque(new Ataque("Pistola Agua", "Agua", 25));
            squirtle.AgregarAtaque(new Ataque("Placaje", "Normal", 10));
            pokemonesDisponibles.Add(squirtle);

            var bulbasaur = new Pokemon("Bulbasaur", "Planta", 100, new List<Ataque>());
            bulbasaur.AgregarAtaque(new Ataque("Látigo Cepa", "Planta", 25));
            bulbasaur.AgregarAtaque(new Ataque("Drenaje", "Planta", 10));
            pokemonesDisponibles.Add(bulbasaur);
        }

        public void IniciarBatalla()
        {
            MenuView.MostrarBienvenida();
            string nombreEntrenador = MenuView.SolicitarNombreEntrenador();
            string apodoEntrenador = MenuView.SolicitarApodo();
            jugador = new Entrenador(nombreEntrenador, apodoEntrenador, 3, 1, 5);

            MenuView.MostrarPokemonDisponibles(pokemonesDisponibles);
            int eleccion = MenuView.SolicitarSeleccionPokemon();
            jugador.PokemonActual = pokemonesDisponibles[eleccion];

            // Crear un Pokémon enemigo aleatorio distinto al del jugador
            var enemigo = pokemonesDisponibles[new Random().Next(pokemonesDisponibles.Count)];
            while (enemigo.Nombre == jugador.PokemonActual.Nombre)
            {
                enemigo = pokemonesDisponibles[new Random().Next(0, pokemonesDisponibles.Count)];
            }
            batallaActual = new Batalla(jugador, enemigo);
            MenuView.MostrarInicioBatalla(jugador.Nombre, jugador.PokemonActual.Nombre, enemigo.Nombre);

            IniciarBatallaConEntrenador();
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