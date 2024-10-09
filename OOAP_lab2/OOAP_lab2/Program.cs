class Program
{
    static void Main(string[] args)
    {
        // Введення вартості за кілограм солодощів
        double lollipopsPrice = 50.0;   // Ціна за 1 кг льодяників
        double chocolatePrice = 120.0;  // Ціна за 1 кг шоколаду
        double wafflesPrice = 80.0;     // Ціна за 1 кг вафель
        double drageePrice = 100.0;     // Ціна за 1 кг драже

        PackagingDirector director = new PackagingDirector();

        // Створення набору "Lasunka"
        IGiftSetBuilder lasunkaBuilder = new LasunkaBuilder();
        director.SetBuilder(lasunkaBuilder);
        director.BuildGiftSet(lollipopsPrice, chocolatePrice, wafflesPrice, drageePrice);
        GiftSet lasunka = director.GetGiftSet();
        lasunka.DisplayInfo();

        // Створення набору "Namynayko"
        IGiftSetBuilder namynaykoBuilder = new NamynaykoBuilder();
        director.SetBuilder(namynaykoBuilder);
        director.BuildGiftSet(lollipopsPrice, chocolatePrice, wafflesPrice, drageePrice);
        GiftSet namynayko = director.GetGiftSet();
        namynayko.DisplayInfo();

        // Створення набору "Pan Kotskyi"
        IGiftSetBuilder panKotskyiBuilder = new PanKotskyiBuilder();
        director.SetBuilder(panKotskyiBuilder);
        director.BuildGiftSet(lollipopsPrice, chocolatePrice, wafflesPrice, drageePrice);
        GiftSet panKotskyi = director.GetGiftSet();
        panKotskyi.DisplayInfo();

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("-------------------Lab2-2-------------------");
        Order order = new Order();

        // Вибираємо тип матеріалу (наприклад, плівка)
        IFacadeFactory factory = new FilmFacadeFactory();

        // Додаємо фасади до замовлення
        order.AddFacade(factory.CreateSolidFacade(2.5));   // Суцільний фасад площею 2.5 кв.м
        order.AddFacade(factory.CreateWindowedFacade(1.8)); // Вітрина площею 1.8 кв.м

        // Виведення інформації про замовлення
        order.DisplayOrderInfo();
    }
}
