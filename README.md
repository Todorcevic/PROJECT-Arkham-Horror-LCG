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

* Facilitar la testabilidad y escalabilidad aplicando una arquitectura con buenas practicas y patrones de diseño.

### Claves:

* Inyección de dependencias.

* Separacíon de la lógica con la vista.

---
## Detalles:

* Debido a que es un juego con reglas complejas es necesario diseñarlo para que cualquier modificación tenga el mínimo impacto con el resto de módulos,
ademas se debe aplicar el pricipio Open/Close en todo lo posible ya que las reglas se agregan y modifican constantemente.

* Evitar la herencia de MonoBehaviour para poder facilitar los test unitarios.

--
### Application Layer

* Una View es un GameObject en la escena que contiene los componentes que reflejarán cambios, ej:

[CardView](Assets/Scripts/Applicaction/Views/Cards/CardView.cs)

[ButtonView](Assets/Scripts/Applicaction/Views/Buttons/ButtonView.cs)

* Un Controller recibe la entrada del usuario y actuará llamando a un UseCase o a un Presenter, ej:

[CardSelectorController](Assets/Scripts/Applicaction/Views/Selectors/Card/CardSelectorController.cs) 

[CampaignController](Assets/Scripts/Applicaction/Views/Campaigns/CampaignController.cs)

* Un Presenter se encarga de controlar las Views segun los argumentos que haya recibido, normalmente por activación de un UseCase, ej:

[CardShowerPresenter](Assets/Scripts/Applicaction/Views/CardShower/CardShowerPresenter.cs)

[InvestigatorCardPresenter](Assets/Scripts/Applicaction/Views/Cards/Investigator/InvestigatorsCardPresenter.cs)

* Un Manager contiene una colección de las Views para poder suministrárselos a quien lo necesite, en su mayor parte a los Presenters, ej:

[CampaignsManager](Assets/Scripts/Applicaction/Views/Campaigns/CampaignsManager.cs)

[CardSelectorsManager](Assets/Scripts/Applicaction/Views/Selectors/Card/CardSelectorsManager.cs)

* Un UseCase es un Mediador que conecta la capa de dominio con la capa de presentación enviando a los Presenters los datos necesarios, ej:

[AddCardUseCase](Assets/Scripts/Applicaction/UseCases/AddCardUseCase.cs)

[StartGameUseCase](Assets/Scripts/Applicaction/UseCases/StartGameUseCase.cs)

* Un DTO es una estructura de datos utilizado para el envio de información, ej:

[CardRowDTO](Assets/Scripts/Applicaction/UseCases/DTO/CardRowDTO.cs) 

[CampaignDTO](Assets/Scripts/Applicaction/UseCases/DTO/CampaignDTO.cs)

--
### Domain Layer

* Las Entity, Agregates y ValueObjects representan el estado y las características de algo en el juego mediante valores primitivos, ej:

[Investigator](Assets/Scripts/Model/Entities/Investigator.cs) - Entity

[DeckBuildingRules](Assets/Scripts/Model/ObjectValue/DeckBuildingRules.cs) - ValueObject

* Un Repository es una coleccion de Entities con los metodos para acceder facilmente a la información. (Se utilizará tambien para persistir los datos), ej:

[CardRepository](Assets/Scripts/Model/Repositories/CardRepository.cs)

[UnlockCardsRepository](Assets/Scripts/Model/Repositories/UnlockCardsRepository.cs)

* Un Interactor contiene lógica que implica a varias entidades distintas, ej:

[CardVisibilityInteractor](Assets/Scripts/Model/Interactors/CardVisibilityInteractor.cs)

[InvestigatorSelectionInteractor](Assets/Scripts/Model/Interactors/InvestigatorSelectionInteractor.cs)

--
### Service Layer

* IDataPersistence es la abstraccion necesaria para almacenar y cargar lo datos. (Actualmente se hace en archivos JSON)

[IDataPersistence](Assets/Scripts/Services/Persistece/DataContext.cs)

* Un Factory se encarga de instanciar objetos ej:

[CardFactory](Assets/Scripts/Services/Factories/CardFactory.cs)

[Factory Genérico](Assets/Scripts/Services/Factories/NameConventionFactory.cs)

* Un Adapter es la abstraccion de algun servicio para evitar su acoplamiento, ej:

[JSONAdapter](Assets/Scripts/Services/Adapters/JsonNewtonsoftAdapter.cs)

[PlayerPrefAdapter](Assets/Scripts/Services/Adapters/PlayerPrefsAdapter.cs)


#### Notas:
* En una arquitectura limpia los UseCase suelen estar en la capa de dominio, pero debido a que existen un gran numero de elementos visuales que son afectados cuando hay un cambio en alguna Entity me ha parecido que no bastaria solo con invertir la dependencia ya que serían muchas las interfaces que tendria que consumir el modelo y seguiria quedando acoplado. Otra posibilidad sería que los Presenters se suscribieran a eventos de dominio, pero tendrían que conocer directamente al modelo para obtener la información que necesitan haciendo que estas clases sean mas confusas, ademas de que no controlariamos el orden de ejecucion. La opción de usar el patron Mediator y sacar los UseCase a la capa de aplicación me ha parecido lo mas correcto.

---
## Herramientas:
* [Zenject](https://github.com/modesttree/Zenject) imprescindible para inyectar las dependencias.

* [DOTween](http://dotween.demigiant.com/index.php) para implementar animaciones y contenido visual.

* [JsonDotNet](https://www.newtonsoft.com/json) para la persistencia de datos.

* [Odin Inspector](https://odininspector.com/) para crear herramientas que ayuden al diseño visual.

* [NSubstitute](https://nsubstitute.github.io/) para la creación de Mocks en los tests.

![Menu](https://www.rosalesnavas.com/images/portfolio/arkham/3.jpg)
