# Nik
El siguiente repositorio consta de un proyecto de Unity que responde a varias preguntas que abarcan los siguientes temas: C#, multiplayer, mallas y DOTS. Plazo temporal: 1 semana.

1. Unity & C#
a) Crea una clase en C# para guardar la información de un sistema solar (nombre, ubicación y un listado de objetos celestiales que orbitan el sistema).
b) Considerando que las estrellas, los planetas y las lunas son objetos celestiales que tienen diferentes tamaños, nombres, ubicación, etc escriba las clases necesarias para modelar un sistema solar urinario (de una sola estrella).
c) Crea una clase mockup en C# que herede de la clase creada en el punto a) y que en su constructor llene el sistema con 1 estrella, 3 planetas y 2 lunas en el último planeta con las clases creadas en el punto b)
d) Escriba una función monobehaviour en C# que tome los objetos del mockup y los instancie como esferas en una escena en Unity.
2. Multiplayer
a) Usando Netcode for game objects (https://docs-multiplayer.unity3d.com/netcode/current/about/index.html), escriba un código en C# que permita a los jugadores conectarse y desconectarse de un servidor multijugador y aparecer en la escena creada en el punto anterior. El prefab del jugador debe contar con una cámara solamente.
b) Escriba un código en C# que permita a los jugadores mover su cámara usando WASD y el mouse y se sincronice entre los clientes.
3. DOTS
a) Escriba un código en C# para crear una entidad Fighter de DOTS y le agregue un componente de transformación y un identificador de owner.
b) Escriba un código en C# que le permita a cada jugador hacer click para instanciar un cubo que represente una entidad Fighter en la ubicación de la cámara, marcando a la entidad como owner al jugador que hizo click.
d) Escriba un código en C# que permita a las entidades interactuar con otras entidades de la escena utilizando DOTS job system. La entidad debe ser capaz de detectar las entidades de los otros jugadores y moverse en línea recta hacia la entidad “enemiga” (not owner) más cercana hasta colisionar (sin hacer clipping).
4. Meshes & Grids
a) En una escena nueva, escriba un código en C# que genere una grilla hexagonal en Unity. La grilla debe tener una cantidad configurable de filas y columnas, y cada hexágono debe tener una malla (mesh) generada proceduralmente. (https://catlikecoding.com/unity/tutorials/hex-map/)
b) Escriba un código en C# que al clickear cada hexágono/celda, esta celda cambie el color entre blanco, rojo, amarillo y azul con cada click.
c) Escriba un código en C# que permita a las celdas reconocer el color de sus vecinos y se marquen como celdas de transición (cuando lo consideren necesario) modificando su color a negro, violeta, naranja o verde para mezclar los colores de las celdas vecinas. 
Por ejemplo: 
Aquí las celdas violetas, negras, naranjas y verdes modificaron sus colores para mostrar que son celdas de transición. Negro indica que es un transicion entre tres de los colores primarios, mientras que el resto indican la transicion entre rojo, azul y amarillo individualmente.
