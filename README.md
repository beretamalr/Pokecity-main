DESCRIPCION

    Juego de batalla Pokemon por turnos 
    implementado en C# con arquitectura MVC
    (Modelo - Vista -Controlador).
    donde el jugador elige un pokemon inicial 
    y se enfrenta a un enemigo aleatorio.

CARACTERISTICAS

    Modelo Vista Controlador

        ·models = Logica de Pokemon, entrenador, ataques y batalla 
        ·Views = Interfaz de consola para menus y combate.
        ·controller = Gestiona el flujo del juego.

    Mecanicas del juego 
    
        ·Eleccion entre Charmander, Squirtle o bulbasaur.
        ·Combate por turnos con 4 opciones:
            -Atacar
            -Usar Pocion
            -Usar SuperPocion
            -Capturar Pokemon
            -Huir
        ·Enemigo usa pociones cuando su vida es baja.

    Balance

        ·Vida base: 100 HP para todos los Pokemon.
        ·Pociones (+20 HP) y superpociones (+50 HP)
        ·Probabilidades realistas para capturas y huida

REQUISITOS 
    -Visual Studio 2022 
    -Consola para ejecucion

COMO JUGAR 
    1. Ingresa tu nombre y apodo de entrenador.
    2. Eligue tu Pokemon ( Se mostrara la lista de pokemon)
    3. Enfrenta a tu pokemon enemigo:
        -Cada turno selecciona una accion del menu.
        -¡Derrota al enemigo o capturalo para ganar!

ESTRUCTURA PROYECTO 

    POKECITY/
    -----Models/        <> Clases de datos
    -----Views/         <> Interfaz
    -----Controllers/   <> Logica
    -----Program/       <> Punto de entrada (MAIN)
    -----README.md      <> Este archivo
