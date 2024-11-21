using System.Diagnostics;

class Program
{
    static void Main()
    {
        BuildingContainer container = new BuildingContainer();

        // Додавання будинків
        var apartment = new ApartmentBuilding(500, 5, "вул. Шевченка, 10", new List<string> { "Іваненко", "Петренко" });
        var cottage = new Cottage(120, 2, "вул. Лесі Українки, 3", "Сергій Коваль");

        container.AddBuilding(apartment);
        container.AddBuilding(cottage);

        // Перегляд будинків
        Console.WriteLine("Перегляд усіх будинків:");
        container.DisplayBuildings();

        // Корегування будинку
        var newCottage = new Cottage(150, 2, "вул. Лесі Українки, 3", "Олена Коваль");
        container.EditBuilding(1, newCottage);

        Console.WriteLine("Після коригування:");
        container.DisplayBuildings();


        Console.WriteLine("--------------------------------");
        int[] array = Enumerable.Range(1, 10000).Reverse().ToArray(); // Масив для сортування

        Thread bubbleThread = new Thread(() => SortAndLog("Bubble Sort", (int[])array.Clone(), SortingAlgorithms.BubbleSort));
        Thread shellThread = new Thread(() => SortAndLog("Shell Sort", (int[])array.Clone(), SortingAlgorithms.ShellSort));
        Thread quickThread = new Thread(() => SortAndLog("Quick Sort", (int[])array.Clone(),
            arr => SortingAlgorithms.QuickSort(arr, 0, arr.Length - 1)));

        bubbleThread.Start();
        shellThread.Start();
        quickThread.Start();

        bubbleThread.Join();
        shellThread.Join();
        quickThread.Join();

        Console.WriteLine("Сортування завершено. Результати записано у файл 'sorting_times.txt'.");
    }
    static void SortAndLog(string algorithmName, int[] array, Action<int[]> sortMethod)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        sortMethod(array);
        stopwatch.Stop();

        string message = $"{algorithmName} виконано за {stopwatch.ElapsedMilliseconds} мс";
        FileLogger.Instance.Log(message);
    }
}