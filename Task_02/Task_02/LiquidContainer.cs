namespace Task_02;

public class LiquidContainer : Container,IHazardNotifier
{
    private static int counter = 0;
    public bool IsHazardous;
    
    public LiquidContainer(float mass, float height, float containerWeight, float depth, float capacity, bool isHazardous) 
        : base(mass, height, containerWeight, depth, capacity)
    {
        SerialNumber = "KON-L-" + counter++;
        Capacity = capacity;
        IsHazardous = isHazardous;
    }
    
    public override void EmptyCargo()
    {
        Mass = 0;
    }
    
    public override void LoadCargo(float cargoMass)
    {
        if (IsHazardous)
        {
            float totalMass = Mass + cargoMass;
            if (totalMass > Capacity / 2)
            {
                throw new OverfillException("Liquid Container mass equal to: " + SerialNumber + " exceeds capacity");
            }

            Mass = totalMass;
        }
        else
        {
            float totalMass = Mass + cargoMass;
            if (totalMass > Capacity)
            {
                throw new OverfillException("Liquid Container mass equal to: " + SerialNumber + " exceeds capacity");
            }
        
            Mass = totalMass;
        }
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine("Hazard detected in Liquid Container: " + SerialNumber + " - " + message);
    }
}