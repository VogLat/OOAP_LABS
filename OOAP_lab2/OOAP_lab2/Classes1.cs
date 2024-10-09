public interface IFacade
{
    string GetFacadeType(); // Тип фасаду: суцільний або вітрина
    double GetArea();       // Площа фасаду в кв. метрах
    double GetPricePerSquareMeter(); // Ціна за кв. метр
    double CalculatePrice();         // Вартість фасаду
}

public class SolidFacade : IFacade
{
    private double _area;
    private double _pricePerSquareMeter;

    public SolidFacade(double area, double pricePerSquareMeter)
    {
        _area = area;
        _pricePerSquareMeter = pricePerSquareMeter;
    }

    public string GetFacadeType() => "Solid Facade";

    public double GetArea() => _area;

    public double GetPricePerSquareMeter() => _pricePerSquareMeter;

    public double CalculatePrice() => _area * _pricePerSquareMeter;
}

public class WindowedFacade : IFacade
{
    private double _area;
    private double _pricePerSquareMeter;

    public WindowedFacade(double area, double pricePerSquareMeter)
    {
        _area = area;
        _pricePerSquareMeter = pricePerSquareMeter;
    }

    public string GetFacadeType() => "Windowed Facade";

    public double GetArea() => _area;

    public double GetPricePerSquareMeter() => _pricePerSquareMeter;

    public double CalculatePrice() => _area * _pricePerSquareMeter;
}

public interface IFacadeFactory
{
    IFacade CreateSolidFacade(double area);
    IFacade CreateWindowedFacade(double area);
}

public class FilmFacadeFactory : IFacadeFactory
{
    private double _pricePerSquareMeter = 100.0; // Ціна за кв. метр для плівки

    public IFacade CreateSolidFacade(double area)
    {
        return new SolidFacade(area, _pricePerSquareMeter);
    }

    public IFacade CreateWindowedFacade(double area)
    {
        return new WindowedFacade(area, _pricePerSquareMeter);
    }
}

public class PaintedFacadeFactory : IFacadeFactory
{
    private double _pricePerSquareMeter = 150.0; // Ціна за кв. метр для фарби

    public IFacade CreateSolidFacade(double area)
    {
        return new SolidFacade(area, _pricePerSquareMeter);
    }

    public IFacade CreateWindowedFacade(double area)
    {
        return new WindowedFacade(area, _pricePerSquareMeter);
    }
}

public class PlasticFacadeFactory : IFacadeFactory
{
    private double _pricePerSquareMeter = 200.0; // Ціна за кв. метр для пластику

    public IFacade CreateSolidFacade(double area)
    {
        return new SolidFacade(area, _pricePerSquareMeter);
    }

    public IFacade CreateWindowedFacade(double area)
    {
        return new WindowedFacade(area, _pricePerSquareMeter);
    }
}

public class Order
{
    private List<IFacade> _facades = new List<IFacade>();

    public void AddFacade(IFacade facade)
    {
        _facades.Add(facade);
    }

    public double CalculateTotalPrice()
    {
        return _facades.Sum(f => f.CalculatePrice());
    }

    public void DisplayOrderInfo()
    {
        foreach (var facade in _facades)
        {
            Console.WriteLine($"{facade.GetFacadeType()} - Area: {facade.GetArea()} sq.m, Price: {facade.CalculatePrice()} UAH");
        }
        Console.WriteLine($"Total Price: {CalculateTotalPrice()} UAH");
    }
}
