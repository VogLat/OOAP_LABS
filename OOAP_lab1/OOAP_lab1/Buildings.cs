using System;
using System.Collections.Generic;

//A class that contains the technical characteristics of the building
class BuildingTechnicalInfo
{
    public int Floors { get; set; }
    public double Area { get; set; }
    public List<string> Utilities { get; set; }

    public BuildingTechnicalInfo(int floors, double area, List<string> utilities)
    {
        Floors = floors;
        Area = area;
        Utilities = utilities;
    }

    // Метод для відображення технічної інформації
    public void ShowTechnicalDetails()
    {
        Console.WriteLine($"Building has {Floors} floors, an area of {Area} sq.m");
        Console.WriteLine("Connected utilities: " + (Utilities.Count > 0 ? string.Join(", ", Utilities) : "None"));
    }
}

// A class that contains the information about the owner of the building
class BuildingOwnerInfo
{
    public string EnterpriseName { get; set; }
    public string Address { get; set; }

    public BuildingOwnerInfo(string enterpriseName, string address)
    {
        EnterpriseName = enterpriseName;
        Address = address;
    }

    public void ShowOwnerDetails()
    {
        Console.WriteLine($"Owner: {EnterpriseName}, Address: {Address}");
    }
}


//A class Buiding that delegates responsibilities to other classes
class Building
{
    private BuildingTechnicalInfo _technicalInfo;
    private BuildingOwnerInfo _ownerInfo;

    public Building(BuildingTechnicalInfo technicalInfo, BuildingOwnerInfo ownerInfo)
    {
        _technicalInfo = technicalInfo;
        _ownerInfo = ownerInfo;
    }

    public void ShowTechnicalInfo()
    {
        _technicalInfo.ShowTechnicalDetails();
    }

    public void ShowOwnerInfo()
    {
        _ownerInfo.ShowOwnerDetails();
    }
}