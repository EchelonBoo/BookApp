using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp
{
    public abstract class Book : IComparable
    {
        //Data Members
        public string ISBN { get; set; }

        public string author { get; set; }

        public double basePrice { get; set; }

        public double countryTax { get; set; }

        //Constuctor functions
        public Book()
        {
            ISBN = "";
            author = "";
            basePrice = 0;
            countryTax = 0;
        }

        public Book(string ISBN, string author, double basePrice, double countryTax)
        {
            this.ISBN = ISBN;
            this.author = author;
            this.basePrice = basePrice;
            this.countryTax = countryTax;
        }

        public Book(string ISBN)
        {
            this.ISBN = ISBN;
        }

        //Member Functions
        // All the public abstract void functions are overriden in the child classes

        public abstract void Print();

        public abstract void getUserInput();

        public abstract void DisplayDetails();

        public abstract double CalculateCost();

        public int CompareTo(Object obj) // Compare function used for Sort by Cost
        {
            if (obj is Book)
            {
                Book b = obj as Book;
                return (Convert.ToInt16(this.CalculateCost())) - (Convert.ToInt16(b.CalculateCost()));
            }
            else
            {
                throw new ArgumentException("Object to compare is not a Book object");
            }

        }

        //The public virtual void functions are fully inherited by all child classes
        public virtual void DisplaySortISBN()
        {
            Console.WriteLine(this.ISBN);
            Console.WriteLine(this.author);
        }
    }
    //Comparer Functions - used for comparing and sorting by ISBN and author
    class SortISBN : Comparer<Book>
    {
        public override int Compare(Book b1, Book b2)
        {
            return String.Compare(b1.ISBN, b2.ISBN);
        }

    }

    class Sortauthor : Comparer<Book>
    {
        public override int Compare(Book b1, Book b2)
        {
            return String.Compare(b1.author, b2.author);
        }

    }
}

