using System.Security.AccessControl;

namespace Task_02;

public class Ship
{
    private static Random random = new Random();
    public float MaxSpeed { get; set; }
    public float MaxNumOfContainers { get; set; }
    public float MaxCapacity { get; set; }
    public List<Container> Containers { get; set; }
    public string SerialNumber { get; set; }
    
    public Ship(float maxSpeed, float maxNumOfContainers, float maxCapacity)
    {
        MaxSpeed = maxSpeed;
        MaxNumOfContainers = maxNumOfContainers;
        MaxCapacity = maxCapacity;
        Containers = new List<Container>();
        SerialNumber = "SHIP-"+ random.Next(1000, 9999) + "-PL" + random.Next(10,99);
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count < MaxNumOfContainers && (GetTotalWeight() + container.Mass) <= MaxCapacity)
        {
            Containers.Add(container);
        }
        else
        {
            throw new OverfillException("Cannot add container. Ship is full or weight limit exceeded.");
        }
    }
    
    public void RemoveContainer(Container container)
    {
        if (Containers.Contains(container))
        {
            Containers.Remove(container);
        }
        else 
        {
            throw new Exception("Container not found on the ship.");
        }
    }
    
    public void UnloadAllContainers()
    {
        List<Container> containersCopy = new List<Container>(Containers);
        foreach (var container in containersCopy)
        {
            container.EmptyCargo();
            RemoveContainer(container);
        }
    }

    private float GetTotalWeight()
    {
        float totalWeight = 0;
        foreach (var container in Containers)
        {
            totalWeight += container.Mass;
        }
        return totalWeight;
    }

    public void ReplaceContainer(Container oldContainer, Container newContainer)
    {
        if(Containers.Contains(oldContainer))
        {
            Containers.Remove(oldContainer);
            LoadContainer(newContainer);
            Console.WriteLine("Container: " + oldContainer + "has been replaces by Container: " + newContainer);
        }
        else
        {
            Console.WriteLine("Container not found on the ship. Please select other container");
        }
    }

    public void TransferContainer(Ship otherShip, Container container)
    {
        if(Containers.Contains(container))
        {
            otherShip.LoadContainer(container);
            RemoveContainer(container);
            Console.WriteLine("Container: " + container + "has been transfered to ship: " + otherShip);
        }
        else
        {
            Console.WriteLine("Given container" + container + "is not present on the ship");
        }
    }
    
    public void PrintInformation()
    {
        Console.WriteLine("Ship: " + SerialNumber + " has " + Containers.Count + " containers on board.");
        Console.WriteLine("Total weight of containers: " + GetTotalWeight());
    }
}
