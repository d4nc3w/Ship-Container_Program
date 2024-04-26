# Ship.Container_Program
Simple C# program that allows user for adding different type of containers with details as well as ships with possibility to load/unload containers on ships.

Classes and Interfaces

Container
An abstract class that serves as the base for different types of containers. It has properties such as mass, height, container weight, depth, capacity, and a serial number to uniquely identify each container. The class provides methods for loading and emptying cargo and printing information about the container.

Properties:

Mass: Represents the mass of the container.
Height: Represents the height of the container.
ContainerWeight: Represents the weight of the container itself.
Depth: Represents the depth of the container.
Capacity: Represents the maximum capacity of the container.
SerialNumber: A unique identifier for the container.
Methods:

EmptyCargo(): Sets the mass of the container to 0.
LoadCargo(float cargoMass): Loads cargo into the container and checks if the total mass does not exceed the capacity. Throws an OverfillException if capacity is exceeded.
PrintInformation(): Prints information about the container.
GasContainer
A class representing a container for gases. It extends the Container class and implements the IHazardNotifier interface.

Properties:

Pressure: Represents the pressure inside the gas container.
Methods:

EmptyCargo(): Reduces the mass of the container by 95%.
NotifyHazard(string message): Logs a message about a detected hazard in the container.
LiquidContainer
A class representing a container for liquids. It extends the Container class and implements the IHazardNotifier interface.

Properties:

IsHazardous: Indicates whether the liquid container contains hazardous materials.
Methods:

EmptyCargo(): Sets the mass of the container to 0.
LoadCargo(float cargoMass): Loads cargo into the container, considering the hazard level and capacity. Throws an OverfillException if capacity is exceeded.
NotifyHazard(string message): Logs a message about a detected hazard in the container.
RefrigeratedContainer
A class representing a refrigerated container for storing perishable goods. It extends the Container class.

Properties:

Type: Specifies the type of goods stored in the container.
Temperature: Specifies the desired temperature for storing the goods.
Methods:

EmptyCargo(): Sets the mass of the container to 0.
LoadCargo(float cargoMass): Loads cargo into the container and checks if the total mass does not exceed the capacity. Throws an OverfillException if capacity is exceeded.
SetTemperature(float temperature): Sets the temperature of the container and logs whether the set temperature is too high or too low.
Ship
A class representing a ship that can carry containers. It contains properties such as maximum speed, maximum number of containers, maximum capacity, and a list of containers on the ship.

Properties:

MaxSpeed: The maximum speed of the ship.
MaxNumOfContainers: The maximum number of containers the ship can carry.
MaxCapacity: The maximum weight the ship can carry.
Containers: A list of containers currently on the ship.
SerialNumber: A unique identifier for the ship.
Methods:

LoadContainer(Container container): Loads a container onto the ship if there is enough space and capacity. Throws an OverfillException if the ship cannot accommodate the container.
RemoveContainer(Container container): Removes a container from the ship.
UnloadAllContainers(): Unloads all containers from the ship.
ReplaceContainer(Container oldContainer, Container newContainer): Replaces an old container on the ship with a new container.
TransferContainer(Ship otherShip, Container container): Transfers a container from the ship to another ship.
PrintInformation(): Prints information about the ship and the containers on board.
Controller
A class that handles the main program flow, providing a menu for the user to manage ships and containers.

Properties:

List<Ship> ships: A list of ships managed by the controller.
List<Container> containers: A list of containers managed by the controller.
Methods:

Run(): Provides a menu-driven interface for the user to manage ships and containers. The user can add/remove ships and containers, place/remove containers on/from ships, modify containers, print information, transfer containers between ships, and replace containers on ships.
Exceptions

OverfillException
A custom exception class used to indicate when a container exceeds its capacity during loading. It takes a message as a parameter, which contains information about the specific error.
