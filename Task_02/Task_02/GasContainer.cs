namespace Task_02;

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