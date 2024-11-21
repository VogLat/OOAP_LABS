// Клас ItemInBOX для опису товару в кошику
public class ItemInBOX
{
    public string Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public ItemInBOX(string id, int quantity, decimal price)
    {
        Id = id;
        Quantity = quantity;
        Price = price;
    }

    // Метод для розрахунку загальної вартості товару в кошику
    public decimal GetTotalPrice()
    {
        return Quantity * Price;
    }
}

// Інтерфейс IPriceCalculator для обчислення ціни товару та доставки
public interface IPriceCalculator
{
    decimal GetUnitPrice(ItemInBOX item);  // Отримання ціни одиниці товару
    decimal GetDeliveryPrice(decimal orderTotal);  // Отримання ціни доставки
}

// Реалізація IPriceCalculator
public class PriceCalculator : IPriceCalculator
{
    public decimal GetUnitPrice(ItemInBOX item)
    {
        // Тут можна додати специфічні логіки для визначення ціни одиниці товару
        return item.Price;
    }

    public decimal GetDeliveryPrice(decimal orderTotal)
    {
        // Приклад: доставка безкоштовна, якщо загальна сума більше 1000
        return orderTotal > 1000 ? 0 : 50;
    }
}

// Абстракція для калькулятора замовлень
public abstract class OrderCalculator
{
    protected IPriceCalculator _priceCalculator;

    public OrderCalculator(IPriceCalculator priceCalculator)
    {
        _priceCalculator = priceCalculator;
    }

    // Метод для додавання товару до кошика
    public abstract void AddItem(ItemInBOX item);

    // Метод для отримання загальної ціни замовлення
    public abstract decimal GetTotalOrderPrice();
}

// Реалізація калькулятора замовлень
public class SimpleOrderCalculator : OrderCalculator
{
    private List<ItemInBOX> _items = new List<ItemInBOX>();

    public SimpleOrderCalculator(IPriceCalculator priceCalculator) : base(priceCalculator)
    {
    }

    public override void AddItem(ItemInBOX item)
    {
        _items.Add(item);
    }

    public override decimal GetTotalOrderPrice()
    {
        decimal totalPrice = 0;

        // Обчислення ціни за всіма товарами в кошику
        foreach (var item in _items)
        {
            totalPrice += _priceCalculator.GetUnitPrice(item) * item.Quantity;
        }

        // Додавання ціни доставки
        totalPrice += _priceCalculator.GetDeliveryPrice(totalPrice);

        return totalPrice;
    }
}
