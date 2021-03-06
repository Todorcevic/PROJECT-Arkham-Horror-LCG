# PROJECT Arkham Horror - Menu

![PROJECT Arkham Horror](https://www.rosalesnavas.com/images/logo_with_text_black.png)
---
Este proyecto está basado en el juego de cartas LCG Arkham Horror de Fantasy Flight Games.
El objetivo es conseguir una version profesional del juego aplicando una arquitectura limpia y principios SOLID.

* [La versión jugable del prototipo](https://github.com/Todorcevic/Project-ARKHAM-HORROR)
 
* [Muestra de una partida completa al prototipo](https://www.youtube.com/watch?v=pvBs5DNNExE)

* [La página del proyecto](https://www.rosalesnavas.com/arkham)

* La información e imágenes de las cartas han sido obtenidas de: https://arkhamdb.com/
 
 ![GamePlay](https://www.rosalesnavas.com/images/portfolio/arkham/2.jpg)
---

## Detalles de la arquitectura:

### Objetivos:

* Buscar la máxima testabilidad y escalabilidad.

### Claves:

* Inversión de dependencias.

* Inyección de dependencias.

* Segregación de Interfaces.

* Eventos de dominio.

---
## Flujo de la aplicación:

					 Entities --> Interactors
						  |	   		   |
Views-->Controllers-->EventsData-->Presenters-->Views
									       |
									    Managers

---
## Detalles:

* Debido a que es un juego con reglas complejas es necesario diseñarlo para que cualquier modificación tenga el mínimo impacto con el resto de módulos,
ademas se debe aplicar el pricipio Open/Close en todo lo posible ya que las reglas se agregan y modifican constantemente.

* Solo las Views y los Managers heredarán de MonoBehaviour para así poder facilitar los test unitarios.

* Una View es un unico elemento visual: un boton, una carta, etc.

* Un Manager contiene una colección de abstracciones de las Views para poder suministrarselos a quien lo necesite, en su mayor parte a los Presenters.

* Cuando el usuario interactua con una View, esta lanza un evento al que está suscrito el Controller destinado a esa View, el requisito para estas Views
es que implimenten IViewInteractable, que es la interface que utiliza el Controller para suscribirse y manejar la parte visual.

* El Controller cuando reciba una notificación actuará llamando a EventData para modificar alguna Entity, o ejecutando directamente un metodo de algún Presenter si no fuera necesario modificar ninguna Entity.

* Un EventData modifica alguna Entity y lanza una notificación por evento, que será recibida por los Presenters que estén suscrito (puede ser 1 o varios presenters).

* Una Entity representa el estado y las caracteristicas de algo en el juego mediante valores primitivos y serializables.

* Cuando un Presenter recibe una notificación de EventData o una llamada de Controller, consulta con los Interactors para obtener los datos necesarios y 
actua en concecuencia con una Interface que es implementada por una determinada View. 

* Los Interactors contienen la logica del juego, obtieniendo los datos de las Entities y suminitrando información al Presenter según este último la pida. La comunicación Presenter - Interactor tiene las dependencias invertidas para que la logica no se vea afectada si algún componente visual cambia o se agregan nuevos.

* Los Managers suministran al Presenter una o varias instancias de las Interfaces que implementa la View.

* La View contiene los componentes visuales cuyos metodos serán implementados en interfaces para invertir la dependencia que existe entre Presenter-View.

* Los Services proporcionan ayuda o efectua una tarea especifica, por ejemplo: CardFactory, DoubleClickDetector, etc. Suele ser inyectado el modulo que lo necesite.

---
## Herramientas:
* [Zenject](https://github.com/modesttree/Zenject) imprescindible para injetar las dependencias.

* [DOTween](http://dotween.demigiant.com/index.php) para implementar animaciones y contenido visual.

* [JsonDotNet](https://www.newtonsoft.com/json) para la persistencia de datos. Se implementa con un Adapter por si fuera necesario cambiarlo a otro sistema de almacenamiento como una base de datos.

* [Odin Inspector](https://odininspector.com/) para crear herramientas que ayuden al diseño visual.

* [NSubstitute](https://nsubstitute.github.io/) para la creacion de Mocks en los tests.

![Menu](https://www.rosalesnavas.com/images/portfolio/arkham/3.jpg)
