namespace Task_02;

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