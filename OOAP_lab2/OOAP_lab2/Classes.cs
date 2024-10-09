public class GiftSet
{
    public string Name { get; set; }
    public double LollipopsWeight { get; set; }
    public double ChocolateWeight { get; set; }
    public double WafflesWeight { get; set; }
    public double DrageeWeight { get; set; }
    public double TotalPrice { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Gift Set: {Name}");
        Console.WriteLine($"Lollipops Weight: {LollipopsWeight} kg");
        Console.WriteLine($"Chocolate Weight: {ChocolateWeight} kg");
        Console.WriteLine($"Waffles Weight: {WafflesWeight} kg");
        Console.WriteLine($"Dragee Weight: {DrageeWeight} kg");
        Console.WriteLine($"Total Price: {TotalPrice} UAH");
    }
}

public interface IGiftSetBuilder
{
    void SetName();
    void SetLollipopsWeight();
    void SetChocolateWeight();
    void SetWafflesWeight();
    void SetDrageeWeight();
    void SetTotalPrice(double lollipopsPrice, double chocolatePrice, double wafflesPrice, double drageePrice);
    GiftSet GetGiftSet();
}
public class LasunkaBuilder : IGiftSetBuilder
{
    private GiftSet _giftSet = new GiftSet();

    public void SetName() => _giftSet.Name = "Lasunka";
    public void SetLollipopsWeight() => _giftSet.LollipopsWeight = 0.5;
    public void SetChocolateWeight() => _giftSet.ChocolateWeight = 0.3;
    public void SetWafflesWeight() => _giftSet.WafflesWeight = 0.2;
    public void SetDrageeWeight() => _giftSet.DrageeWeight = 0.1;
    public void SetTotalPrice(double lollipopsPrice, double chocolatePrice, double wafflesPrice, double drageePrice)
    {
        _giftSet.TotalPrice = (_giftSet.LollipopsWeight * lollipopsPrice) +
                              (_giftSet.ChocolateWeight * chocolatePrice) +
                              (_giftSet.WafflesWeight * wafflesPrice) +
                              (_giftSet.DrageeWeight * drageePrice);
    }
    public GiftSet GetGiftSet() => _giftSet;
}

public class NamynaykoBuilder : IGiftSetBuilder
{
    private GiftSet _giftSet = new GiftSet();

    public void SetName() => _giftSet.Name = "Namynayko";
    public void SetLollipopsWeight() => _giftSet.LollipopsWeight = 0.4;
    public void SetChocolateWeight() => _giftSet.ChocolateWeight = 0.4;
    public void SetWafflesWeight() => _giftSet.WafflesWeight = 0.1;
    public void SetDrageeWeight() => _giftSet.DrageeWeight = 0.2;
    public void SetTotalPrice(double lollipopsPrice, double chocolatePrice, double wafflesPrice, double drageePrice)
    {
        _giftSet.TotalPrice = (_giftSet.LollipopsWeight * lollipopsPrice) +
                              (_giftSet.ChocolateWeight * chocolatePrice) +
                              (_giftSet.WafflesWeight * wafflesPrice) +
                              (_giftSet.DrageeWeight * drageePrice);
    }
    public GiftSet GetGiftSet() => _giftSet;
}

public class PanKotskyiBuilder : IGiftSetBuilder
{
    private GiftSet _giftSet = new GiftSet();

    public void SetName() => _giftSet.Name = "Pan Kotskyi";
    public void SetLollipopsWeight() => _giftSet.LollipopsWeight = 0.3;
    public void SetChocolateWeight() => _giftSet.ChocolateWeight = 0.5;
    public void SetWafflesWeight() => _giftSet.WafflesWeight = 0.2;
    public void SetDrageeWeight() => _giftSet.DrageeWeight = 0.3;
    public void SetTotalPrice(double lollipopsPrice, double chocolatePrice, double wafflesPrice, double drageePrice)
    {
        _giftSet.TotalPrice = (_giftSet.LollipopsWeight * lollipopsPrice) +
                              (_giftSet.ChocolateWeight * chocolatePrice) +
                              (_giftSet.WafflesWeight * wafflesPrice) +
                              (_giftSet.DrageeWeight * drageePrice);
    }
    public GiftSet GetGiftSet() => _giftSet;
}

public class PackagingDirector
{
    private IGiftSetBuilder _builder;

    public void SetBuilder(IGiftSetBuilder builder)
    {
        _builder = builder;
    }

    public void BuildGiftSet(double lollipopsPrice, double chocolatePrice, double wafflesPrice, double drageePrice)
    {
        _builder.SetName();
        _builder.SetLollipopsWeight();
        _builder.SetChocolateWeight();
        _builder.SetWafflesWeight();
        _builder.SetDrageeWeight();
        _builder.SetTotalPrice(lollipopsPrice, chocolatePrice, wafflesPrice, drageePrice);
    }

    public GiftSet GetGiftSet()
    {
        return _builder.GetGiftSet();
    }
}
