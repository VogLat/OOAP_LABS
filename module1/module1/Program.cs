using System;
namespace module1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating Ford Explorer
            VehicleBuilder builder = new FordExplorerBuilder();
            VehicleCreator creator = new VehicleCreator(builder);
            creator.CreateVehicle();
            Vehicle fordExplorer = creator.GetVehicle();
            fordExplorer.ShowInfo();  // Output: Brand: Ford, Model: Explorer, Engine: 3.5L V6, Transmission: Automatic

            // Creating Lincoln Aviator
            builder = new LincolnAviatorBuilder();
            creator = new VehicleCreator(builder);
            creator.CreateVehicle();
            Vehicle lincolnAviator = creator.GetVehicle();
            lincolnAviator.ShowInfo();  // Output: Brand: Lincoln, Model: Aviator, Engine: 3.0L V6 Twin Turbo, Transmission: Automatic
        }
    }
}