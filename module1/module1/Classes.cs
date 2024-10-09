using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module1
{ 
    //Our product
    public class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public string Transmission { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Brand: {Brand}, Model: {Model}, Engine: {Engine}, Transmission: {Transmission}");
        }
    }

    // Abstract class Builder
    public abstract class VehicleBuilder
    {
        protected Vehicle _vehicle;

        public void CreateVehicle()
        {
            _vehicle = new Vehicle();
        }

        public Vehicle GetVehicle()
        {
            return _vehicle;
        }

        public abstract void SetBrand();
        public abstract void SetModel();
        public abstract void SetEngine();
        public abstract void SetTransmission();
    }

    // Concrete builder FordExplorer
    public class FordExplorerBuilder : VehicleBuilder
    {
        public override void SetBrand()
        {
            _vehicle.Brand = "Ford";
        }

        public override void SetModel()
        {
            _vehicle.Model = "Explorer";
        }

        public override void SetEngine()
        {
            _vehicle.Engine = "3.5L V6";
        }

        public override void SetTransmission()
        {
            _vehicle.Transmission = "Automatic";
        }
    }

    // Concrete builder LincolnAviator
    public class LincolnAviatorBuilder : VehicleBuilder
    {
        public override void SetBrand()
        {
            _vehicle.Brand = "Lincoln";
        }

        public override void SetModel()
        {
            _vehicle.Model = "Aviator";
        }

        public override void SetEngine()
        {
            _vehicle.Engine = "3.0L V6 Twin Turbo";
        }

        public override void SetTransmission()
        {
            _vehicle.Transmission = "Automatic";
        }
    }

    // Class Director
    public class VehicleCreator
    {
        private VehicleBuilder _builder;

        public VehicleCreator(VehicleBuilder builder)
        {
            _builder = builder;
        }

        public void CreateVehicle()
        {
            _builder.CreateVehicle();
            _builder.SetBrand();
            _builder.SetModel();
            _builder.SetEngine();
            _builder.SetTransmission();
        }

        public Vehicle GetVehicle()
        {
            return _builder.GetVehicle();
        }
    }
}
