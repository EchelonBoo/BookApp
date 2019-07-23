using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp
{
    public class Ebook : Book, Idownloadable
    {
        //Data members
        public string downloadURL { get; set; }
        public double sizeMB { get; set; }

        //Constructor Functions
        public Ebook(string ISBN) : base(ISBN)
        {
            downloadURL = "";
            sizeMB = 0;
        }

        public Ebook(string ISBN, string author, double basePrice, double countryTax, string downloadURL, double sizeMB) : base(ISBN, author, basePrice, countryTax)
        {
            this.downloadURL = downloadURL;
            this.sizeMB = sizeMB;
        }

        public Ebook() : base()
        {
            downloadURL = "";
            sizeMB = 0;
        }


        //Member Functions
        //All of these member functions override the ones decalred in the parent class as they are specific to this class

        public override void DisplayDetails()
        {
            Console.WriteLine("\t{0}  {1,10} {2,10} {3,10} {4,10} {5,10}", ISBN, author, basePrice.ToString("F2"), countryTax.ToString("F2"), downloadURL, sizeMB.ToString("F2"));
        }

        public override void Print()
        {
            Console.WriteLine("\n\tISBN\t\t" + this.ISBN);
            Console.WriteLine("\tAuthor\t\t" + this.author);
            Console.WriteLine("\tBase Price\t" + this.basePrice);
            Console.WriteLine("\tCountry Tax\t" + this.countryTax);
            Console.WriteLine("\tDowload URL\t" + this.downloadURL);
            Console.WriteLine("\tSize in MBs\t" + this.sizeMB);
            Console.WriteLine();
        }

        public override void getUserInput()
        {
            Console.WriteLine("Please enter a book ISBN:");
            string isbn = Console.ReadLine();

            Console.WriteLine("Please enter the author:");
            string auth = Console.ReadLine();

            Console.WriteLine("Please enter the baseprice");
            double bp = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter the country tax");
            double ct = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter the download URL");
            string dl = Console.ReadLine();

            Console.WriteLine("Please enter the size in MBs");
            double mb = Convert.ToDouble(Console.ReadLine());

            this.ISBN = isbn;
            this.author = auth;
            this.basePrice = bp;
            this.countryTax = ct;
            this.downloadURL = dl;
            this.sizeMB = mb;
        }

        public override double CalculateCost()
        {
            return this.basePrice + (this.basePrice * countryTax / 100);
        }

        public string printURL()
        {
            return this.downloadURL;
        }
    }
}
