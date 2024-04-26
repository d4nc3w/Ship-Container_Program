# Ship.Container_Program
Simple C# program that allows user for adding different type of containers with details as well as ships with possibility to load/unload containers on ships.

Classes and Interfaces

Container

    public abstract class Container
    { 
       public float Mass { get; set; }
       public float Height { get; set; }
       public float ContainerWeight { get; set; }
       public float Depth { get; set; }
       public string SerialNumber { get; set; }
       public float Capacity { get; set; }
       
       public Container(float mass, float height, float containerWeight, float depth, float capacity)
       {
           Mass = mass;
           Height = height;
           ContainerWeight = containerWeight;
           Depth = depth;
           Capacity = capacity;
       }
    
       public virtual void EmptyCargo()
       {
             Mass = 0;
       }
       
       public virtual void LoadCargo(float cargoMass)
       {
             float totalMass = Mass + cargoMass;
             if (totalMass > Capacity)
             {
                  throw new OverfillException("Total mass for Container: " + SerialNumber + "exceeds capacity");
             }
             Mass = totalMass;
       }
    
       public virtual void PrintInformation()
       {
           Console.WriteLine("Container: " + SerialNumber + " Mass: " + Mass + " Height: " + Height + " Container Weight: "
                             + ContainerWeight + " Depth: " + Depth + " Capacity: " + Capacity);
       }
    }

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

    public class GasContainer : Container,IHazardNotifier
    {
        private static int _counter = 0;
        
        public float Pressure { get; set; }
        
        public GasContainer(float mass, float height, float containerWeight, float depth, float capacity, float pressure) 
            : base(mass, height, containerWeight, depth, capacity)
        {
            SerialNumber = "KON-G-" + _counter++;
            Capacity = capacity;
        }
        
        public override void EmptyCargo()
        {
            float massReduction = Mass * 0.95f;
            Mass -= massReduction;
        }
    
        public void NotifyHazard(string message)
        {
            Console.WriteLine("Hazard detected in Gas Container: " + SerialNumber + " - " + message);
        }
    }

A class representing a container for gases. It extends the Container class and implements the IHazardNotifier interface.

Properties:

Pressure: Represents the pressure inside the gas container.
Methods:

EmptyCargo(): Reduces the mass of the container by 95%.
NotifyHazard(string message): Logs a message about a detected hazard in the container.

------------------------------
LiquidContainer
A class representing a container for liquids. It extends the Container class and implements the IHazardNotifier interface.

Properties:

IsHazardous: Indicates whether the liquid container contains hazardous materials.
Methods:

EmptyCargo(): Sets the mass of the container to 0.
LoadCargo(float cargoMass): Loads cargo into the container, considering the hazard level and capacity. Throws an OverfillException if capacity is exceeded.
NotifyHazard(string message): Logs a message about a detected hazard in the container.

-------------------------------------------------------
RefrigeratedContainer
A class representing a refrigerated container for storing perishable goods. It extends the Container class.

Properties:

Type: Specifies the type of goods stored in the container.
Temperature: Specifies the desired temperature for storing the goods.
Methods:

EmptyCargo(): Sets the mass of the container to 0.
LoadCargo(float cargoMass): Loads cargo into the container and checks if the total mass does not exceed the capacity. Throws an OverfillException if capacity is exceeded.
SetTemperature(float temperature): Sets the temperature of the container and logs whether the set temperature is too high or too low.

-----------------------------------
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

-----------------------------------
Controller

    public class Controller
    {
        List<Ship> ships;
        List<Container> containers;
    
        public Controller(List<Ship> ships, List<Container> containers)
        {
            this.ships = ships;
            this.containers = containers;
        }
    
        public void Run()
        {
            int choice = 0;
            while (choice != 11)
            {
                Console.WriteLine("List of container ships: ");
                if (ships.Count == 0)
                {
                    Console.WriteLine("None");
                }
                else
                {
                    foreach (var ship in ships)
                    {
                        Console.Write(ship.SerialNumber + " ");
                    }
                }
                
                Console.WriteLine();
                Console.WriteLine("List of containers: ");
                if (containers.Count == 0)
                {
                    Console.WriteLine("None");
                }
                else
                {
                    foreach (var container in containers)
                    {
                        Console.Write(container.SerialNumber + " ");
                    }
                }
    
                Console.WriteLine();
                Console.WriteLine("------Choose your option------");
                Console.WriteLine("(1) \t Add a container ship");
                Console.WriteLine("(2) \t Remove a container ship");
                Console.WriteLine("(3) \t Add a container");
                Console.WriteLine("(4) \t Remove a container");
                Console.WriteLine("(5) \t Place the container on the ship");
                Console.WriteLine("(6) \t Remove the container from the ship");
                Console.WriteLine("(7) \t Modify specific container");
                Console.WriteLine("(8) \t Print information about the ship or container");
                Console.WriteLine("(9) \t Transfer container from one ship to another");
                Console.WriteLine("(10) \t Replace container on the ship");
                Console.WriteLine("(11) \t Exit the program");
                Console.WriteLine("-------------------------------");
    
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    AddShip();
                }
                else if (choice == 2)
                {
                    RemoveShip();
                }
                else if (choice == 3)
                {
                    AddContainer();
                }
                else if (choice == 4)
                {
                    RemoveContainer();
                }
                else if (choice == 5)
                {
                    PlaceContainerOnShip();
                }
                else if (choice == 6)
                {
                    RemoveContainerFromShip();
                }
                else if (choice == 7)
                {
                    ModifyContainer();
                }
                else if (choice == 8)
                {
                    PrintInfo();
                }
                else if (choice == 9)
                {
                    TransferContainer();
                }
                else if (choice == 10)
                {
                    ReplaceContainer();
                }
                else if (choice == 11)
                {
                    Console.WriteLine("Exiting the program...");
                    break;
                }
    
                Console.WriteLine();
            }
        }
    
        void AddShip()
        {
            Console.WriteLine("Please insert necessary data for the ship: ");
            Console.WriteLine("Max speed: ");
            float speed = float.Parse(Console.ReadLine());
            Console.WriteLine("Maximal number of containers: ");
            float maxNumOfContainers = float.Parse(Console.ReadLine());
            Console.WriteLine("Maximal capacity: ");
            float maxCapacity = float.Parse(Console.ReadLine());
    
            Ship ship = new(speed, maxNumOfContainers, maxCapacity);
            ships.Add(ship);
            Console.WriteLine("New ship has been added.");
        }
    
        void RemoveShip()
        {
            Console.WriteLine("Choose the ship to remove: ");
            for (int i = 0; i < ships.Count; i++)
            {
                Console.WriteLine("(" + (i + 1) + ") " + " " + ships[i].SerialNumber);
            }
    
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice <= ships.Count)
            {
                ships.RemoveAt(choice - 1);
                Console.WriteLine("Ship has been removed.");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    
        void AddContainer()
        {
            Console.WriteLine("Specify the type of container: ");
            Console.WriteLine("(1) Liquid");
            Console.WriteLine("(2) Gas");
            Console.WriteLine("(3) Refrigerated");
            int type = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter necessary data for the container: ");
            Console.WriteLine("Mass: ");
            float mass = float.Parse(Console.ReadLine());
            Console.WriteLine("Height: ");
            float height = float.Parse(Console.ReadLine());
            Console.WriteLine("Container weight: ");
            float containerWeight = float.Parse(Console.ReadLine());
            Console.WriteLine("Depth: ");
            float depth = float.Parse(Console.ReadLine());
            Console.WriteLine("Capacity: ");
            float capacity = float.Parse(Console.ReadLine());
    
            if (type == 1)
            {
                Console.WriteLine("Is the container hazardous? (y/n): ");
                string isHazard = Console.ReadLine();
                if (isHazard == "y")
                {
                    LiquidContainer LContainer = new(mass, height, containerWeight, depth, capacity, true);
                    containers.Add(LContainer);
                }
                else if (isHazard == "n")
                {
                    LiquidContainer LContainer = new(mass, height, containerWeight, depth, capacity, false);
                    containers.Add(LContainer);
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
            else if (type == 2)
            {
                Console.WriteLine("Pressure: ");
                float pressure = float.Parse(Console.ReadLine());
                
                GasContainer GContainer = new (mass, height, containerWeight, depth, capacity, pressure);
                containers.Add(GContainer);
            }
            else if (type == 3)
            {
                Console.WriteLine("Specify the type: ");
                string typeOfContainer = Console.ReadLine();
                Console.WriteLine("Insert preferable temperature: ");
                float temperature = float.Parse(Console.ReadLine());
                RefrigeratedContainer RContainer = new RefrigeratedContainer
                    (mass, height, containerWeight, depth, typeOfContainer, temperature, capacity);
                containers.Add(RContainer);
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
    
            Console.WriteLine("New container has been added.");
        }
    
        void RemoveContainer()
        {
            Console.WriteLine("Choose the container to remove: ");
            for (int i = 0; i < containers.Count; i++)
            {
                Console.WriteLine("(" + (i + 1) + ") " + " " + containers[i].SerialNumber);
            }
    
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice <= containers.Count)
            {
                containers.RemoveAt(choice - 1);
                Console.WriteLine("Container has been removed.");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    
        void PlaceContainerOnShip()
        {
            Console.WriteLine("Choose the ship you want to load: ");
            for (int i = 0; i < ships.Count; i++)
            {
                Console.WriteLine("(" + (i + 1) + ") " + " " + ships[i].SerialNumber);
            }
    
            int shipChoice = Convert.ToInt32(Console.ReadLine());
            if (shipChoice <= ships.Count)
            {
                Ship ship = ships[shipChoice - 1];
                Console.WriteLine("Choose the container that you want to place on the ship: ");
                for (int i = 0; i < containers.Count; i++)
                {
                    Console.WriteLine("(" + (i + 1) + ") " + " " + containers[i].SerialNumber);
                }
    
                int containerChoice = Convert.ToInt32(Console.ReadLine());
                if (containerChoice <= containers.Count)
                {
                    Container container = containers[containerChoice - 1];
                    try
                    {
                        ship.LoadContainer(container);
                        containers.Remove(container);
                        Console.WriteLine("The container has been load into the ship.");
                    }
                    catch (OverfillException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice for a container.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice for a ship.");
            }
        }
    
        void RemoveContainerFromShip()
        {
            Console.WriteLine("Choose the ship you want to unload: ");
            for (int i = 0; i < ships.Count; i++)
            {
                Console.WriteLine("(" + (i + 1) + ") " + " " + ships[i].SerialNumber);
            }
    
            int shipChoice = Convert.ToInt32(Console.ReadLine());
            if (shipChoice <= ships.Count)
            {
                Ship ship = ships[shipChoice - 1];
                Console.WriteLine("Choose the container that you want to remove from the ship: ");
                for (int i = 0; i < ship.Containers.Count; i++)
                {
                    Console.WriteLine("(" + (i + 1) + ") "  + containers[i].SerialNumber);
                }
    
                int containerChoice = Convert.ToInt32(Console.ReadLine());
                if (containerChoice <= ship.Containers.Count)
                {
                    Container container = ship.Containers[containerChoice - 1];
                    ship.RemoveContainer(container);
                    containers.Add(container);
                    Console.WriteLine("Container has been unloaded from the ship.");
                }
                else
                {
                    Console.WriteLine("Invalid choice for a container.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice for a ship.");
            }
        }
    
        void ModifyContainer()
        {
            Console.WriteLine("Select container you want to modify: ");
            for (int i = 0; i < containers.Count; i++)
            {
                Console.WriteLine("(" + (i + 1) + ") "  + containers[i].SerialNumber);
            }
    
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice <= containers.Count())
            {
                Container container = containers[choice - 1];
                Console.WriteLine("Choose property to modify:");
                Console.WriteLine("(1) Mass");
                Console.WriteLine("(2) Height");
                Console.WriteLine("(3) Container Weight");
                Console.WriteLine("(4) Depth");
                Console.WriteLine("(5) Capacity");
    
                if (container is GasContainer)
                {
                    Console.WriteLine("(6) Pressure");
                    int modification = Convert.ToInt32(Console.ReadLine());
                    if (modification == 1)
                    {
                        Console.WriteLine("Enter new mass: ");
                        float newMass = float.Parse(Console.ReadLine());
                        container.Mass = newMass;
                    }
                    else if (modification == 2)
                    {
                        Console.WriteLine("Enter new height: ");
                        float newHeight = float.Parse(Console.ReadLine());
                        container.Height = newHeight;
                    }
                    else if (modification == 3)
                    {
                        Console.WriteLine("Enter new container weight: ");
                        float newContainerWeight = float.Parse(Console.ReadLine());
                        container.ContainerWeight = newContainerWeight;
                    }
                    else if (modification == 4)
                    {
                        Console.WriteLine("Enter new depth: ");
                        float newDepth = float.Parse(Console.ReadLine());
                        container.Depth = newDepth;
                    }
                    else if (modification == 5)
                    {
                        Console.WriteLine("Enter new capacity: ");
                        float newCapacity = float.Parse(Console.ReadLine());
                        container.Capacity = newCapacity;
                    }
                    else if (modification == 6)
                    {
                        Console.WriteLine("Enter new pressure: ");
                        float pressure = float.Parse(Console.ReadLine());
                        ((GasContainer)container).Pressure = pressure;
                    }
                }
                else if (container is LiquidContainer)
                {
                    Console.WriteLine("(6) Is Hazardous");
    
                    int modification = Convert.ToInt32(Console.ReadLine());
                    if (modification == 1)
                    {
                        Console.WriteLine("Enter new mass: ");
                        float newMass = float.Parse(Console.ReadLine());
                        container.Mass = newMass;
                    }
                    else if (modification == 2)
                    {
                        Console.WriteLine("Enter new height: ");
                        float newHeight = float.Parse(Console.ReadLine());
                        container.Height = newHeight;
                    }
                    else if (modification == 3)
                    {
                        Console.WriteLine("Enter new container weight: ");
                        float newContainerWeight = float.Parse(Console.ReadLine());
                        container.ContainerWeight = newContainerWeight;
                    }
                    else if (modification == 4)
                    {
                        Console.WriteLine("Enter new depth: ");
                        float newDepth = float.Parse(Console.ReadLine());
                        container.Depth = newDepth;
                    }
                    else if (modification == 5)
                    {
                        Console.WriteLine("Enter new capacity: ");
                        float newCapacity = float.Parse(Console.ReadLine());
                        container.Capacity = newCapacity;
                    }
                    else if (modification == 6)
                    {
                        Console.WriteLine("Is the container hazardous? (y/n): ");
                        string isHazard = Console.ReadLine();
                        if (isHazard == "y")
                        {
                            ((LiquidContainer)container).IsHazardous = true;
                        }
                        else if (isHazard == "n")
                        {
                            ((LiquidContainer)container).IsHazardous = false;
                        }
                    }
                }
                else if (container is RefrigeratedContainer)
                {
                    Console.WriteLine("(6) Type");
                    Console.WriteLine("(7) Temperature");
                    int modification = Convert.ToInt32(Console.ReadLine());
                    if (modification == 1)
                    {
                        Console.WriteLine("Enter new mass: ");
                        float newMass = float.Parse(Console.ReadLine());
                        container.Mass = newMass;
                    }
                    else if (modification == 2)
                    {
                        Console.WriteLine("Enter new height: ");
                        float newHeight = float.Parse(Console.ReadLine());
                        container.Height = newHeight;
                    }
                    else if (modification == 3)
                    {
                        Console.WriteLine("Enter new container weight: ");
                        float newContainerWeight = float.Parse(Console.ReadLine());
                        container.ContainerWeight = newContainerWeight;
                    }
                    else if (modification == 4)
                    {
                        Console.WriteLine("Enter new depth: ");
                        float newDepth = float.Parse(Console.ReadLine());
                        container.Depth = newDepth;
                    }
                    else if (modification == 5)
                    {
                        Console.WriteLine("Enter new capacity: ");
                        float newCapacity = float.Parse(Console.ReadLine());
                        container.Capacity = newCapacity;
                    }
                    else if (modification == 6)
                    {
                        Console.WriteLine("Enter new type: ");
                        string newType = Console.ReadLine();
                        ((RefrigeratedContainer)container).Type = newType;
                    }
                    else if (modification == 7)
                    {
                        Console.WriteLine("Enter new temperature: ");
                        float newTemperature = float.Parse(Console.ReadLine());
                        ((RefrigeratedContainer)container).SetTemperature(newTemperature);
                    }
                }
            }
        }
    
        void PrintInfo()
        {
            Console.WriteLine("Choose what to print information about: ");
            Console.WriteLine("(1) Ship");
            Console.WriteLine("(2) Container");
            int choice = Convert.ToInt32(Console.ReadLine());
    
            if (choice == 1)
            {
                Console.WriteLine("Select ship to display info: ");
                for (int i = 0; i < ships.Count; i++)
                {
                    Console.WriteLine("(" + (i + 1) + ") "  + ships[i].SerialNumber);
                }
                int chosenShip = Convert.ToInt32(Console.ReadLine());
                if (chosenShip <= ships.Count) 
                {
                    Ship ship = ships[chosenShip - 1];
                    Console.WriteLine("Ship: " + ship.SerialNumber + " MaxSpeed: " + ship.MaxSpeed + " MaxNumOfContainers: " 
                                      + ship.MaxNumOfContainers + " MaxCapacity: " + ship.MaxCapacity);
                    Console.WriteLine("Containers on board:");
                    if (ship.Containers.Count > 0)
                    {
                        foreach (var container in ship.Containers)
                        {
                            Console.WriteLine("Container: " + container.SerialNumber + " Mass: " + container.Mass + " Height: " 
                                              + container.Height + " Weight: " + container.ContainerWeight 
                                              + " Depth: " + container.Depth + " Capacity: " + container.Capacity);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No containers on board");
                    }
                }
            }
            else if (choice == 2)
            {
                Console.WriteLine("Select container to display info: ");
                for (int i = 0; i < containers.Count; i++)
                {
                    Console.WriteLine("(" + (i + 1) + ") "  + containers[i].SerialNumber);
                }
                int chosenContainer = Convert.ToInt32(Console.ReadLine());
                if (chosenContainer < containers.Count)
                {
                    Container container = containers[chosenContainer - 1];
                    Console.WriteLine("Container: " + container.SerialNumber + " Mass: " + container.Mass + " Height: " 
                                      + container.Height + " Weight: " + container.ContainerWeight 
                                      + " Depth: " + container.Depth + " Capacity: " + container.Capacity);
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    
        void TransferContainer()
        {
            if (ships.Count >= 2)
            {
                Console.WriteLine("Select ship to transfer container from: ");
                for (int i = 0; i < ships.Count; i++)
                {
                    Console.WriteLine("(" + (i + 1) + ") "  + ships[i].SerialNumber);
                }
                int shipFrom = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine("Select ship to transfer container to: ");
                for (int i = 0; i < ships.Count; i++)
                {
                    Console.WriteLine("(" + (i + 1) + ") "  + ships[i].SerialNumber);
                }
                int shipTo = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine("Select container you want to transfer: ");
                if (ships[shipFrom - 1].Containers.Count > 0)
                {
                    for (int i = 0; i < ships[shipFrom - 1].Containers.Count; i++)
                    {
                        Console.WriteLine("(" + (i + 1) + ") " + ships[shipFrom - 1].Containers[i].SerialNumber);
                    }
    
                    int containerChoice = Convert.ToInt32(Console.ReadLine());
    
                    if (containerChoice <= ships[shipFrom - 1].Containers.Count)
                    {
                        Container container = ships[shipFrom - 1].Containers[containerChoice - 1];
                        ships[shipFrom - 1].RemoveContainer(container);
                        ships[shipTo - 1].LoadContainer(container);
                        Console.WriteLine("Container has been transfered.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice for a container or not enough containers on the ship");
                }
            }
            else
            {
                Console.WriteLine("Not enough ships to proceed.");
            }
        }
    
        void ReplaceContainer()
        {
            if (ships.Count >= 1)
            {
                Console.WriteLine("Select ship to replace container inside: ");
                for (int i = 0; i < ships.Count; i++)
                {
                    Console.WriteLine("(" + (i + 1) + ") "  + ships[i].SerialNumber);
                }
                int shipChoice = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine("Select container you want to replace: ");
                for (int i = 0; i < ships[shipChoice - 1].Containers.Count; i++)
                {
                    Console.WriteLine("(" + (i + 1) + ") "  + ships[shipChoice - 1].Containers[i].SerialNumber);
                }
                int containerChoice = Convert.ToInt32(Console.ReadLine());  
                
                Console.WriteLine("Select container you want to replace with: ");
                for (int i = 0; i < containers.Count; i++)
                {
                    Console.WriteLine("(" + (i + 1) + ") "  + containers[i].SerialNumber);
                }
                int newContainer = Convert.ToInt32(Console.ReadLine());
                
                if (containerChoice <= ships[shipChoice - 1].Containers.Count && newContainer <= containers.Count)
                {
                    Container oldContainer = ships[shipChoice - 1].Containers[containerChoice - 1];
                    Container container = containers[newContainer - 1];
                    ships[shipChoice - 1].ReplaceContainer(oldContainer, container);
                }
                else
                {
                    Console.WriteLine("Invalid choice for a container.");
                }
            }
            else
            {
                Console.WriteLine("Not enough ships to proceed.");
            }
        }
    }

A class that handles the main program flow, providing a menu for the user to manage ships and containers.

Properties:

List<Ship> ships: A list of ships managed by the controller.
List<Container> containers: A list of containers managed by the controller.
Methods:

Run(): Provides a menu-driven interface for the user to manage ships and containers. The user can add/remove ships and containers, place/remove containers on/from ships, modify containers, print information, transfer containers between ships, and replace containers on ships.

-----------------------------------
OverfillException
A custom exception class used to indicate when a container exceeds its capacity during loading. It takes a message as a parameter, which contains information about the specific error.
