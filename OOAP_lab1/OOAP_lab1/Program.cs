namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a proxy for the book collection
            IBookCollection bookCollectionProxy = new BookCollectionProxy();

            // Add books
            bookCollectionProxy.AddBook(new Book("Book One", "Author A"));
            bookCollectionProxy.AddBook(new Book("Book Two", "Author B"));

            // Search by author
            Book foundBook = bookCollectionProxy.SearchBookByAuthor("Author A");
            if (foundBook != null)
            {
                Console.WriteLine("Book found: " + foundBook);
            }
            else
            {
                Console.WriteLine("Book not found");
            }

            // Remove a book
            bookCollectionProxy.RemoveBook(foundBook);
            Book book1 = new Book("asdadas", "fsgfd");
            bookCollectionProxy.RemoveBook(book1);

            // Display all books
            var allBooks = bookCollectionProxy.GetAllBooks();
            Console.WriteLine("All Books in Collection:");
            foreach (var book in allBooks)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------Lab1.2----------------------------");

            List<string> utilities = new List<string> { "Gas", "Electricity", "Water" };

            // Створюємо інформацію про технічні характеристики будівлі
            BuildingTechnicalInfo technicalInfo = new BuildingTechnicalInfo(5, 1500.0, utilities);

            // Створюємо інформацію про власника будівлі
            BuildingOwnerInfo ownerInfo = new BuildingOwnerInfo("ACME Corp.", "123 Main St.");

            // Створюємо об'єкт Building, який делегує свої обов'язки
            Building building = new Building(technicalInfo, ownerInfo);

            // Виводимо технічні характеристики будівлі
            building.ShowTechnicalInfo();

            // Виводимо інформацію про власника
            building.ShowOwnerInfo();
        }
    }
}