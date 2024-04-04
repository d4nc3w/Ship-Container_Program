namespace Task_02;

public class RefrigeratedContainer : Container
{
    private static int counter = 0;
    public string Type { get; set; }
    public float Temperature { get; set; }
    
    public RefrigeratedContainer(float mass, float height, float containerWeight, float depth, string type, float temperature,
        float capacity)
    :base(mass, height, containerWeight, depth, capacity)
    {
        SerialNumber = "KON-C-" + counter++;
        Capacity = capacity;
        Type = type;
        Temperature = temperature;
    }

    public override void EmptyCargo()
    {
        Mass = 0;
    }

    public override void LoadCargo(float cargoMass)
    {
        float totalMass = Mass + cargoMass;
        if (totalMass > Capacity)
        {
            throw new OverfillException("Total mass for Refrigerated Container: " + SerialNumber + " exceeds capacity");
        }
        Mass = totalMass;
    }
    
    public void SetTemperature(float temperature)
    {
        
        if (temperature < Temperature)
        {
            Console.WriteLine("Temperature in Refrigerated Container is too low");
        }
        else if (temperature > Temperature)
        {
            Console.WriteLine("Temperature in Refrigerated Container is too high");
        }
        else
        {
            Console.WriteLine("Temperature has been set to: " + temperature + " in: " + SerialNumber);
        }
    }
}