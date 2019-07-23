using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Book> books = new List<Book>(); //Creates list data structure to hold books

            Console.WriteLine("**Book Shop**");

            int option;
            do
            {
                Console.WriteLine();
                Console.WriteLine("1.   Add Book");
                Console.WriteLine("2.   Display Books");
                Console.WriteLine("3.   Search by ISBN");
                Console.WriteLine("4.   Update Book Details by ISBN");
                Console.WriteLine("5.   Delete Book");
                Console.WriteLine("6.   Sort by ISBN");
                Console.WriteLine("7.   Sort by Author");
                Console.WriteLine("8.   Display by Cost");
                Console.WriteLine("9.   Management Report");
                Console.WriteLine("10.  Display Idownloadable");
                Console.WriteLine("11.  Exit");
                Console.WriteLine();

                Console.WriteLine("Please choose an option from the menu:");
                option = Convert.ToInt32(Console.ReadLine());

                Console.Write("You Chose Option: ");
                Console.WriteLine(option);

                switch (option)
                {
                    case 1:
                        {
                            addBooks(books);
                            break;
                        }
                    case 2:
                        {
                            displayBooks(books);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter an ISBN:");
                            string input = Console.ReadLine();

                            Book searchISBN = books.Where(s => s.ISBN == input).FirstOrDefault();
                            searchISBN.DisplayDetails();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter an ISBN:");
                            string input = Console.ReadLine();

                            Book searchISBN = books.Where(s => s.ISBN == input).FirstOrDefault();
                            searchISBN.getUserInput();
                            break;
                        }
                    case 5:
                        {
                            deleteBook(books);
                            break;
                        }
                    case 6:
                        {
                            var listByISBN = books.OrderBy(o => o.ISBN).ToList();
                            foreach (Book b1 in listByISBN)
                            {
                                b1.DisplayDetails();
                            }
                            break;
                        }
                    case 7:
                        {
                            var listByAuthor = books.OrderBy(o => o.author).ToList();
                            foreach (Book b1 in listByAuthor)
                            {
                                b1.DisplayDetails();
                            }
                            break;
                        }
                    case 8:
                        {
                            var listByCost = books.OrderBy(o => o.basePrice).ToList();
                            foreach (Book b1 in listByCost)
                            {
                                b1.DisplayDetails();
                            }
                            break;
                        }
                    case 9:
                        {
                            managementReport(books);
                            break;
                        }
                    case 10:
                        {
                            displayIdownloadable(books);
                            break;
                        }
                    case 11:
                        {
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Option not chosen, please choose an option.");
                            break;
                        }
                }

            } while (option != 11);

        }

        // This function is hard codes books onto the system to speed up the testing process
        public static void addBooks(List<Book> books)
        {
            EJournal ej1 = new EJournal("7", "David", 8, 5.5, "ejournal.ie", 78);
            EJournal ej2 = new EJournal("8", "James", 6, 8.65, "ejournal.ie", 108);
            EJournal ej3 = new EJournal("9", "Andy", 5.95, 6.4, "ejournal.ie", 29);

            books.Add(ej1);
            books.Add(ej2);
            books.Add(ej3);

            Ebook eb1 = new Ebook("2", "John", 10, 3.5, "ebook.com", 4);
            Ebook eb2 = new Ebook("1", "Mary", 11, 3.5, "ebook.com", 5);
            Ebook eb3 = new Ebook("3", "Dylan", 12, 3.5, "ebook.com", 6);


            books.Add(eb1);
            books.Add(eb2);
            books.Add(eb3);


            PaperBook pb1 = new PaperBook("4", "Sarah", 5, 3.5, 8.9, 4.5);
            PaperBook pb2 = new PaperBook("5", "Mike", 8.99, 3.5, 6, 8.9);
            PaperBook pb3 = new PaperBook("6", "Sarah", 7.5, 3.5, 7, 6.5);


            books.Add(pb1);
            books.Add(pb2);
            books.Add(pb3);
        }

        //This function displays all the books and their details
        public static void displayBooks(List<Book> books)
        {
            foreach (Book b in books)
            {
                b.DisplayDetails();
            }
        }

        //This function allows the user to enter an ISBN and then searches through the list to check if there is a book with a matching ISBN and then displays  that books details
        public static void searchByISBN(List<Book> books)
        {
            Console.WriteLine("Enter the ISBN:");
            string isbn = Console.ReadLine();

            foreach (Book b in books)
            {
                if (b.ISBN.Equals(isbn))
                {
                    Console.WriteLine("Book Found");
                    b.Print();
                }
            }
        }

        //This function is used to find a books based on ISBN
        public static Book findBook(List<Book> books, string isbn)
        {
            Book x = null;
            foreach (Book b in books)
            {
                if (b.ISBN.Equals(isbn))
                {
                    return b;
                }
            }
            return x;
        }
        //This function allows the user to enter an ISBN and finds the book that matches it and then calls the function getUserInput from the parent class which allows the user to enter new details for that book
        public static void updateByISBN(List<Book> books)
        {
            Console.WriteLine("Enter the ISBN:");
            string isbn = Console.ReadLine();

            foreach (Book b in books)
            {
                if (b.ISBN.Equals(isbn))
                {
                    Console.WriteLine("Book Found");
                    b.getUserInput();
                }
            }
        }

        //This function calls the findbooks function to locate the book and then deletes the selected book
        public static void deleteBook(List<Book> books)
        {
            Console.WriteLine("Enter the ISBN:");
            string isbn = Console.ReadLine();

            Book x = findBook(books, isbn);
            if (x != null)
            {
                books.Remove(x);
            }
            else
            {
                Console.WriteLine("Book not found");
            }
        }

        //This function calls SortISBN from the parent class which uses the comparer function to compare ISBN's and then calls the sort() function to sort them into order from smallest to largest
        public static void sortISBN(List<Book> books)
        {
            books.Sort(new SortISBN());
            foreach (Book b in books)
            {
                Console.WriteLine("\t\t{0}\t{1}", b.ISBN, b.author);
            }

        }

        //This function calls sortAuthor from the parent class which uses the comparer function to compare the books authors and then calls the Sort() function to sort them into alpahbetical order
        public static void sortAuthor(List<Book> books)
        {
            books.Sort(new Sortauthor());
            foreach (Book b in books)
            {
                Console.WriteLine("\t\t{0}\t{1}", b.author, b.ISBN);
            }

        }

        //This function display the books in the list based on their price from cheapest to most expensive
        public static void displayCost(List<Book> books)
        {
            books.Sort();
            foreach (Book b in books)
            {

                Console.WriteLine("\t\t{0}\t{1}   \t{2}", b.ISBN, b.GetType(), b.CalculateCost().ToString("F2"));
            }
        }

        //This function displays the percentage of each book type that is in the system
        public static void managementReport(List<Book> books)
        {
            decimal Paperbook = 0;
            decimal Ebook = 0;
            decimal Ejournal = 0;

            // Determines how many of each type there are in the list
            foreach (Book b in books)
            {
                if (b is PaperBook)
                {

                    Paperbook++;
                }
                else if (b is Ebook)
                {
                    Ebook++;
                }
                else if (b is EJournal)
                {
                    Ejournal++;
                }

            }

            //Calculates percentage of each book
            decimal total = Ebook + Paperbook + Ejournal;

            Ebook = (Ebook / total) * 100;
            Paperbook = (Paperbook / total) * 100;
            Ejournal = (Ejournal / total) * 100;

            Console.WriteLine("\t\t{0}% of Ebooks \n\t\t{1}% of Paper Books\n\t\t{2}% of eJournals\n", Ebook.ToString("F2"), Paperbook.ToString("F2"), Ejournal.ToString("F2"));
        }

        //This function should display all the books that use the Idownloadable interface
        public static void displayIdownloadable(List<Book> books)
        {
            foreach (Book e in books)
            {
                if (e is Idownloadable)
                {
                    Ebook ej = (Ebook)e;
                    Console.WriteLine(ej.printURL());
                }
            }
        }
    }
}
