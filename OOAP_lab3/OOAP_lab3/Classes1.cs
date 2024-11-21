using System;
using System.Collections.Generic;

public abstract class Building : ICloneable
{
    public double Area { get; set; }
    public int Floors { get; set; }
    public string Address { get; set; }

    public Building(double area, int floors, string address)
    {
        Area = area;
        Floors = floors;
        Address = address;
    }

    // Метод для копіювання об'єкта (Прототип)
    public abstract object Clone();

    // Абстрактний метод для відображення інформації
    public abstract void DisplayInfo();
}

public class ApartmentBuilding : Building
{
    public List<string> ApartmentOwners { get; set; }

    public ApartmentBuilding(double area, int floors, string address, List<string> owners)
        : base(area, floors, address)
    {
        ApartmentOwners = new List<string>(owners);
    }

    public override object Clone()
    {
        // Глибока копія списку власників
        return new ApartmentBuilding(Area, Floors, Address, new List<string>(ApartmentOwners));
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Багатоквартирний будинок: {Address}, {Floors} поверх(и), площа: {Area} м²");
        Console.WriteLine("Власники квартир:");
        foreach (var owner in ApartmentOwners)
        {
            Console.WriteLine($"- {owner}");
        }
    }
}

public class Cottage : Building
{
    public string Owner { get; set; }

    public Cottage(double area, int floors, string address, string owner)
        : base(area, floors, address)
    {
        Owner = owner;
    }

    public override object Clone()
    {
        return new Cottage(Area, Floors, Address, Owner);
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Котедж: {Address}, {Floors} поверх(и), площа: {Area} м², Власник: {Owner}");
    }
}

public class BuildingContainer
{
    private List<Building> buildings = new List<Building>();

    public void AddBuilding(Building building)
    {
        buildings.Add(building.Clone() as Building); // Клонування через Прототип
    }

    public void DisplayBuildings()
    {
        if (buildings.Count == 0)
        {
            Console.WriteLine("Будинки відсутні.");
            return;
        }

        foreach (var building in buildings)
        {
            building.DisplayInfo();
            Console.WriteLine();
        }
    }

    public void EditBuilding(int index, Building newBuilding)
    {
        if (index < 0 || index >= buildings.Count)
        {
            Console.WriteLine("Неправильний індекс.");
            return;
        }

        buildings[index] = newBuilding.Clone() as Building;
        Console.WriteLine("Інформацію оновлено.");
    }
}


