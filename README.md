# Project ARKHAM HORROR

![Project ARKHAM HORROR](https://www.rosalesnavas.com/images/logo_with_text_black.png)
---
Este proyecto está basado en el juego de cartas LCG Arkham Horror de Fantasy Flight Games.
El objetivo es conseguir una version profesional del juego aplicando una arquitectura por capas y principios SOLID.

* [La versión jugable del prototipo](https://github.com/Todorcevic/Project-ARKHAM-HORROR)
 
* [Muestra de una partida completa al prototipo](https://www.youtube.com/watch?v=pvBs5DNNExE)

* [La página del proyecto](https://www.rosalesnavas.com/arkham)

* La información e imágenes de las cartas han sido obtenidas de: https://arkhamdb.com/
---
 ![GamePlay](https://www.rosalesnavas.com/images/ProjectArkhamHorrorGithub.jpg)
---

## Detalles de la arquitectura:

### Objetivos:

* Facilitar la testabilidad y escalabilidad aplicando una arquitectura limpia con buenas practicas y patrones de diseño.

### Claves:

* Inyección de dependencias.

* Separacíon de la lógica con la vista.

---
## Detalles:

* Debido a que es un juego con reglas complejas es necesario diseñarlo para que cualquier modificación tenga el mínimo impacto con el resto de módulos,
ademas se debe aplicar el pricipio Open/Close en todo lo posible ya que las reglas se agregan y modifican constantemente.

* Evitar la herencia de MonoBehaviour para poder facilitar los test unitarios.

Application Layer

* Una View es un GameObject en la escena que contiene los componentes que reflejarán cambios:
[CardView](Assets/Scripts/Applicaction/Views/Cards/CardView.cs)
[ButtonView](Assets/Scripts/Applicaction/Views/Buttons/ButtonView.cs)

* Un Controller recibe la entrada del usuario y actuará llamando a un UseCase o a un Presenter

* Un Presenter se encarga de controlar las Views segun los argumentos que haya recibido, normalmente por activación de un UseCase.

* Un Manager contiene una colección de las Views para poder suministrárselos a quien lo necesite, en su mayor parte a los Presenters.

* Un UseCase es un Mediator que conecta la capa de dominio con la capa de presentación y suministra a los Presenters los datos necesarios.

* Un DTO es una estructura de datos utilizado para el envio de información.

Domain Layer

* Las Entity, Agregates y ValueObjects representan el estado y las características de algo en el juego mediante valores primitivos.

* Un Repository es una coleccion de Entities con los metodos para acceder facilmente a la información. (Se utilizará tambien para persistir los datos).

* Un Interactor contiene lógica que implica a varias entidades distintas.

Service Layer

* IDataPersistence es la abstraccion necesaria para almacenar y cargar lo datos. (Actualmente se hace en archivos JSON)

* Un Factory se encarga de instanciar objetos.

* Un Adapter es la abstraccion de algun servicio para evitar su acoplamiento.


Notas:
* En una arquitectura limpia los UseCase suelen estar en la capa de dominio, pero debido a que existen un gran numero de elementos visuales que son afectados cuando hay un cambio en alguna Entity me ha parecido que no bastaria solo con invertir la dependencia ya que serían muchas las interfaces que dependerían el modelo que este seguiria quedando acoplado. Otra posibilidad sería que los Presenters se suscribieran a eventos de dominio, pero tendrían que conocer directamente al modelo para obtener la información que necesitan haciendo que estas clases sean mas confusas, ademas de que no controlariamos el orden de ejecucion. La opción de usar el patron Mediator como UseCase em ha parecido lo mas correcto.

---
## Herramientas:
* [Zenject](https://github.com/modesttree/Zenject) imprescindible para inyectar las dependencias.

* [DOTween](http://dotween.demigiant.com/index.php) para implementar animaciones y contenido visual.

* [JsonDotNet](https://www.newtonsoft.com/json) para la persistencia de datos.

* [Odin Inspector](https://odininspector.com/) para crear herramientas que ayuden al diseño visual.

* [NSubstitute](https://nsubstitute.github.io/) para la creación de Mocks en los tests.

![Menu](https://www.rosalesnavas.com/images/portfolio/arkham/3.jpg)
