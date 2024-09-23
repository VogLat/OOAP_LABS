namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            IBookCollection bookCollectionProxy = new BookCollectionProxy();

            bookCollectionProxy.AddBook(new Book("Book One", "Author A"));
            bookCollectionProxy.AddBook(new Book("Book Two", "Author B"));
            bookCollectionProxy.AddBook(new Book("Book Three", "Author B"));

           
            List<Book> booksByAuthor = bookCollectionProxy.SearchBooksByAuthor("Author B");

            if (booksByAuthor.Count > 0)
            {
                Console.WriteLine("Books by Author B:");
                foreach (var book in booksByAuthor)
                {
                    Console.WriteLine(book.Title); 
                }
            }
            else
            {
                Console.WriteLine("No books found by this author.");
            }
            Book bookToRemove = new Book("Book Three", "Author B");

            bookCollectionProxy.RemoveBook(bookToRemove);
            Book book1 = new Book("asdadas", "fsgfd");
            bookCollectionProxy.RemoveBook(book1);

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

            BuildingTechnicalInfo technicalInfo = new BuildingTechnicalInfo(5, 1500.0, utilities);

            BuildingOwnerInfo ownerInfo = new BuildingOwnerInfo("ACME Corp.", "123 Main St.");

            Building building = new Building(technicalInfo, ownerInfo);

            building.ShowTechnicalInfo();

            building.ShowOwnerInfo();
        }
    }
}