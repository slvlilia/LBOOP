using System;
using System.Collections.Generic;
using System.Linq;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public string ISBN { get; set; }

    public Book(string title, string author, int year, string isbn)
    {
        Title = title;
        Author = author;
        Year = year;
        ISBN = isbn;
    }

    public override string ToString()
    {
        return $"{Title} ({Author}, {Year}, ISBN: {ISBN})";
    }
}

class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        books.Remove(book);
    }

    public List<Book> SearchByAuthor(string author)
    {
        return books.Where(book => book.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Book> SearchByTitle(string title)
    {
        return books.Where(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public void ListAllBooks()
    {
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Додати книгу");
            Console.WriteLine("2. Видалити книгу");
            Console.WriteLine("3. Пошук за автором");
            Console.WriteLine("4. Пошук за назвою");
            Console.WriteLine("5. Список всiх книг");
            Console.WriteLine("6. Вийти");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Назва книги: ");
                    string title = Console.ReadLine();
                    Console.Write("Автор: ");
                    string author = Console.ReadLine();
                    Console.Write("Рiк видання: ");
                    int year = int.Parse(Console.ReadLine());
                    Console.Write("ISBN: ");
                    string isbn = Console.ReadLine();
                    Book newBook = new Book(title, author, year, isbn);
                    library.AddBook(newBook);
                    Console.WriteLine("Книга додана до бiблiотеки.");
                    break;

                case "2":
                    Console.Write("Назва книги, яку треба видалити: ");
                    string bookTitleToRemove = Console.ReadLine();
                    Console.Write("Автор книги: ");
                    string bookAuthorToRemove = Console.ReadLine();
                    var booksToRemove = library.SearchByTitle(bookTitleToRemove)
                        .Where(book => book.Author.Equals(bookAuthorToRemove, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    if (booksToRemove.Count > 0)
                    {
                        foreach (var book in booksToRemove)
                        {
                            library.RemoveBook(book);
                            Console.WriteLine("Книга видалена з бiблiотеки.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Книга не знайдена у бiблiотецi.");
                    }
                    break;

                case "3":
                    Console.Write("Введiть iм'я автора: ");
                    string authorToSearch = Console.ReadLine();
                    var authorBooks = library.SearchByAuthor(authorToSearch);
                    if (authorBooks.Count > 0)
                    {
                        Console.WriteLine("Знайденi книги:");
                        foreach (var book in authorBooks)
                        {
                            Console.WriteLine(book);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Книги даного автора не знайдено.");
                    }
                    break;

                case "4":
                    Console.Write("Введiть назву книги: ");
                    string titleToSearch = Console.ReadLine();
                    var titleBooks = library.SearchByTitle(titleToSearch);
                    if (titleBooks.Count > 0)
                    {
                        Console.WriteLine("Знайденi книги:");
                        foreach (var book in titleBooks)
                        {
                            Console.WriteLine(book);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Книги з даною назвою не знайдено.");
                    }
                    break;

                case "5":
                    Console.WriteLine("Список всiх книг у бiблiотецi:");
                    library.ListAllBooks();
                    break;

                case "6":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Невiрний вибiр. Виберiть опцiю з меню.");
                    break;
            }
        }
    }
}
