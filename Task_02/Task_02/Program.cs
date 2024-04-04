using Task_02;

public class Program
{
    public static void Main(string[] args)
    {
        List<Ship> ships = new List<Ship>();
        List<Container> containers = new List<Container>();
        
        LiquidContainer Lcontainer = new LiquidContainer(100, 10, 10, 10, 500, true);
        GasContainer Gcontainer = new GasContainer(100, 50, 50, 50, 200, 300);
        RefrigeratedContainer Rcontainer = new RefrigeratedContainer(100, 10, 10, 10, 
            "Fruit", 5, 200);
        
        containers.Add(Lcontainer);
        containers.Add(Gcontainer);
        containers.Add(Rcontainer);

        Ship ship1 = new Ship(200, 50, 1000);
        Ship ship2 = new Ship(500, 20, 400);
        
        ships.Add(ship1);
        ships.Add(ship2);
        
        Controller controller = new Controller(ships, containers);
        controller.Run();
        // try
        // {
        //     //Testing...
        //     Container Lcontainer = new LiquidContainer(100, 10, 10, 10, 500, true);
        //     Container L2container = new LiquidContainer(100, 20, 20, 20, 500, false);
        //     Container Gcontainer = new GasContainer(100, 10, 10, 10, 300); 
        //     Container Rcontainer = new RefrigeratedContainer(100, 10, 10, 10, 
        //         "Fruit", 5, 200);
        //     
        //     RefrigeratedContainer reContainer = new RefrigeratedContainer(10, 5, 20, 5, 
        //         "Vegatable", 10, 250);
        //     
        //     reContainer.SetTemperature(12);
        //     reContainer.SetTemperature(8);
        //     
        //     Lcontainer.PrintInformation();
        //     L2container.PrintInformation();
        //     Rcontainer.PrintInformation();
        //     Gcontainer.PrintInformation();
        //
        //     Lcontainer.LoadCargo(150);
        //     L2container.LoadCargo(151);
        //     Lcontainer.PrintInformation();
        //     
        //     Ship ship = new Ship(100, 3, 1000);
        //     ship.LoadContainer(Lcontainer);
        //     ship.LoadContainer(Rcontainer);
        //     ship.LoadContainer(Gcontainer);
        //     ship.PrintInformation();
        //     
        //     ship.UnloadAllContainers();
        //     ship.PrintInformation();
        //
        //     Ship ship2 = new Ship(200, 5, 500);
        //     ship.LoadContainer(Gcontainer);
        //     ship.TransferContainer(ship2, Gcontainer);
        //     ship2.PrintInformation();
        // }
        // catch (OverfillException e)
        // {
        //    //Nothing here (I already defined this exception in the classes)
        // }
    }
}

