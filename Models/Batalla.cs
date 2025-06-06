using System.Text.RegularExpressions;
using System;
using Pokecity;
using Pokecity.Models;
namespace Pokecity.Models
{
    public class Batalla
    {
        public Entrenador Jugador { get; set; }
        public Pokemon PokemonEnemigo { get; set; }
        public bool BatallaEnCurso { get; set; }

        public Batalla(Entrenador jugador, Pokemon enemigo)
        {
            Jugador = jugador;
            PokemonEnemigo = enemigo;
            BatallaEnCurso = true;
        }

        public string Atacar(Ataque ataque)
        {
            PokemonEnemigo.VidaActual -= ataque.Danio;
            return $"{Jugador.PokemonActual.Nombre} uso {ataque.Nombre} y le hizo {ataque.Danio} de daño a {PokemonEnemigo.Nombre}. Vida restante del enemigo: {PokemonEnemigo.VidaActual}/{PokemonEnemigo.VidaMax}.";
        }

        public string UsarPocion()
        {
            if (Jugador.Pociones > 0)
            {
                int curacion = 20;
                Jugador.PokemonActual.VidaActual = Math.Min(Jugador.PokemonActual.VidaActual + curacion, Jugador.PokemonActual.VidaMax);
                Jugador.Pociones--;
                return $"{Jugador.Nombre} uso una pocion. {Jugador.PokemonActual.Nombre} ha recuperado {curacion} puntos de vida. Vida actual: {Jugador.PokemonActual.VidaActual}/{Jugador.PokemonActual.VidaMax}. Pociones restantes: {Jugador.Pociones}.";
            }
            return $"{Jugador.Nombre} no tiene pociones disponibles.";
        }

        public string UsarSuperPocion()
        {
            if (Jugador.SuperPociones > 0)
            {
                int curacion = 50;
                Jugador.PokemonActual.VidaActual = Math.Min(Jugador.PokemonActual.VidaActual + curacion, Jugador.PokemonActual.VidaMax);
                Jugador.SuperPociones--;
                return $"{Jugador.Nombre} uso una super pocion. {Jugador.PokemonActual.Nombre} ha recuperado {curacion} puntos de vida. Vida actual: {Jugador.PokemonActual.VidaActual}/{Jugador.PokemonActual.VidaMax}. Super pociones restantes: {Jugador.SuperPociones}.";
            }
            return $"{Jugador.Nombre} no tiene superpociones!";
        }
        public string CapturarPokemon()
        {
            if (Jugador.Pokebolas > 0)
            {
                Jugador.Pokebolas--;
                double probabilidad = (PokemonEnemigo.VidaActual / (double)PokemonEnemigo.VidaMax) * 100;
                if (new Random().Next(0, 100) > probabilidad)
                {
                    BatallaEnCurso = false;
                    return $"¡FELICIDADES! {Jugador.Nombre} ha capturado a {PokemonEnemigo.Nombre}!";
                }
                return $"{Jugador.Nombre} intento capturar a {PokemonEnemigo.Nombre}, pero fallo. Probabilidad de captura: {probabilidad}%. Pokebolas restantes: {Jugador.Pokebolas}.";
            }
            return $"{Jugador.Nombre} no tiene pokebolas disponibles para capturar a {PokemonEnemigo.Nombre}.";
        }
        public string IntentarHuir()
        {
            if (new Random().Next(0, 100)> 50)
            {
                BatallaEnCurso = false;
                return $"{Jugador.Nombre} ha huido de la batalla contra {PokemonEnemigo.Nombre}.";
            }
            return $"{Jugador.Nombre} no ha podido huir de la batalla contra {PokemonEnemigo.Nombre}. Inténtalo de nuevo.";
        }
        
        public string AtaqueEnemigo()
{
    if (PokemonEnemigo.EstaDebilitado()) return "";

    string mensajePocion = "";
    if (new Random().Next(0, 100) < 70)
    {
        mensajePocion = EnemigoUsaPocion();
    }
    else
    {
        mensajePocion = EnemigoUsaSuperPocion();
    }
    if (!string.IsNullOrEmpty(mensajePocion))
    {
        return mensajePocion;
    }

    var ataqueEnemigo = PokemonEnemigo.Ataques[new Random().Next(PokemonEnemigo.Ataques.Count)];
    Jugador.PokemonActual.VidaActual -= ataqueEnemigo.Danio;
    return $"{PokemonEnemigo.Nombre} usa {ataqueEnemigo.Nombre} y le hace {ataqueEnemigo.Danio} de daño a {Jugador.PokemonActual.Nombre}. Vida restante de {Jugador.PokemonActual.Nombre}: {Jugador.PokemonActual.VidaActual}/{Jugador.PokemonActual.VidaMax}.";
            

           
        }
        
        public bool VerificarFinBatalla()
        {
            
            if (Jugador.PokemonActual.EstaDebilitado())
            {
                BatallaEnCurso = false;
                return false;
            }
            if (PokemonEnemigo.EstaDebilitado())
            {
                BatallaEnCurso = false;
                
            }
            return false;
        
        }
        public string EnemigoUsaPocion()
        {
            if (PokemonEnemigo.VidaActual < PokemonEnemigo.VidaMax * 0.5 && 
                new Random().Next(0, 100) < 20) // 20% de probabilidad de usar poción
            {
                int curacion = 20;
                PokemonEnemigo.VidaActual = Math.Min(PokemonEnemigo.VidaActual + curacion, PokemonEnemigo.VidaMax);
                return $"{PokemonEnemigo.Nombre} ha usado una poción y ha recuperado {curacion} puntos de vida. Vida actual: {PokemonEnemigo.VidaActual}/{PokemonEnemigo.VidaMax}.";
            }
            return $"";
        }
        public string EnemigoUsaSuperPocion()
        {
            if (PokemonEnemigo.VidaActual < PokemonEnemigo.VidaMax * 0.3 && 
                new Random().Next(0, 100) < 10) // 10% de probabilidad de usar superpoción
            {
                int curacion = 50;
                PokemonEnemigo.VidaActual = Math.Min(PokemonEnemigo.VidaActual + curacion, PokemonEnemigo.VidaMax);
                return $"{PokemonEnemigo.Nombre} ha usado una superpoción y ha recuperado {curacion} puntos de vida. Vida actual: {PokemonEnemigo.VidaActual}/{PokemonEnemigo.VidaMax}.";
            }
            return $"";
        }
    }
}