using System;
using System.Collections.Generic;



// Основний клас для виконання програми
class Program
{
    static void Main(string[] args)
    {
        IPriceCalculator priceCalculator = new PriceCalculator();
        OrderCalculator orderCalculator = new SimpleOrderCalculator(priceCalculator);

        // Додавання товарів до кошика
        orderCalculator.AddItem(new ItemInBOX("Item1", 2, 100)); // 2 одиниці по 100
        orderCalculator.AddItem(new ItemInBOX("Item2", 3, 250));
        //orderCalculator.AddItem(new ItemInBOX("Item2", 1, 250));// 1 одиниця по 250

        // Отримання загальної вартості замовлення
        decimal totalPrice = orderCalculator.GetTotalOrderPrice();
        Console.WriteLine("Total Order Price: " + totalPrice); // Виведе загальну ціну

        Console.WriteLine("-----------------------------------");


        Console.WriteLine("Testing Old Alarm:");
        AlarmC oldAlarm = new AlarmClock(new OldAlarm());
        oldAlarm.Start();
        oldAlarm.Stop();

        Console.WriteLine("\nTesting Modern Alarm:");
        AlarmC modernAlarm = new AlarmClock(new ModernAlarm());
        modernAlarm.Start();
        modernAlarm.Stop();
    }
}
