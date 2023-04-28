# Nik
El siguiente repositorio consta de un proyecto de Unity que responde a varias preguntas que abarcan los siguientes temas: C#, multiplayer, mallas y DOTS. Plazo temporal: 1 semana.
Aclaración: Puede que no compile correctamente el proyecto debido a unos problemas con los paquetes de Netcode y DOTS.

1. Unity & C#

- Crea una clase en C# para guardar la información de un sistema solar (nombre, ubicación y un listado de objetos celestiales que orbitan el sistema).
- Considerando que las estrellas, los planetas y las lunas son objetos celestiales que tienen diferentes tamaños, nombres, ubicación, etc escriba las clases necesarias para modelar un sistema solar urinario (de una sola estrella).
- Crea una clase mockup en C# que herede de la clase creada en el punto a) y que en su constructor llene el sistema con 1 estrella, 3 planetas y 2 lunas en el último planeta con las clases creadas en el punto b)
- Escriba una función monobehaviour en C# que tome los objetos del mockup y los instancie como esferas en una escena en Unity.

2. Multiplayer
- Usando Netcode for game objects (https://docs-multiplayer.unity3d.com/netcode/current/about/index.html), escriba un código en C# que permita a los jugadores conectarse y desconectarse de un servidor multijugador y aparecer en la escena creada en el punto anterior. El prefab del jugador debe contar con una cámara solamente.
- Escriba un código en C# que permita a los jugadores mover su cámara usando WASD y el mouse y se sincronice entre los clientes.
3. DOTS
- Escriba un código en C# para crear una entidad Fighter de DOTS y le agregue un componente de transformación y un identificador de owner.
- Escriba un código en C# que le permita a cada jugador hacer click para instanciar un cubo que represente una entidad Fighter en la ubicación de la cámara, marcando a la entidad como owner al jugador que hizo click.
- Escriba un código en C# que permita a las entidades interactuar con otras entidades de la escena utilizando DOTS job system. La entidad debe ser capaz de detectar las entidades de los otros jugadores y moverse en línea recta hacia la entidad “enemiga” (not owner) más cercana hasta colisionar (sin hacer clipping).
4. Meshes & Grids
- En una escena nueva, escriba un código en C# que genere una grilla hexagonal en Unity. La grilla debe tener una cantidad configurable de filas y columnas, y cada hexágono debe tener una malla (mesh) generada proceduralmente. (https://catlikecoding.com/unity/tutorials/hex-map/)
- Escriba un código en C# que al clickear cada hexágono/celda, esta celda cambie el color entre blanco, rojo, amarillo y azul con cada click.
- Escriba un código en C# que permita a las celdas reconocer el color de sus vecinos y se marquen como celdas de transición (cuando lo consideren necesario) modificando su color a negro, violeta, naranja o verde para mezclar los colores de las celdas vecinas.
