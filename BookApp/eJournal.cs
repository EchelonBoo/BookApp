using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp
{
    class EJournal : Book//, Idownloadable
    {
        // Data Members
        public string DownloadURL { get; set; }

        public int WeekNum { get; set; }

        //Constructor Functions
        public EJournal() : base()
        {
            DownloadURL = "";
            WeekNum = 0;
        }

        public EJournal(string ISBN) : base(ISBN)
        {
            DownloadURL = "";
            WeekNum = 0;
        }

        public EJournal(string ISBN, string author, double basePrice, double countryTax, string DownloadURL, int WeekNum) : base(ISBN, author, basePrice, countryTax)
        {
            this.DownloadURL = DownloadURL;
            this.WeekNum = WeekNum;
        }

        //Member Functions
        //All of these member functions override the ones decalred in the parent class as they are specific to this class

        public override double CalculateCost()
        {
            return this.basePrice + (this.basePrice * 0.2) + (this.basePrice * (this.countryTax / 100));
        }

        public override void DisplayDetails()
        {
            Console.WriteLine("\t{0}  {1,10 } {2,10} {3,10} {4,10} {5,10}", ISBN, author, basePrice.ToString("F2"), countryTax.ToString("F2"), DownloadURL, WeekNum.ToString("F2"));
        }

        public override void Print()
        {
            Console.WriteLine("\n\tISBN\t\t" + this.ISBN);
            Console.WriteLine("\tAuthor\t\t" + this.author);
            Console.WriteLine("\tBase Price\t" + this.basePrice);
            Console.WriteLine("\tCountry Tax\t" + this.countryTax);
            Console.WriteLine("\tDownloadable URL\t" + this.DownloadURL);
            Console.WriteLine("\tWeek Number\t" + this.WeekNum);
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
            string dwnu = Console.ReadLine();

            Console.WriteLine("Please enter the week number");
            int wn = Convert.ToInt16(Console.ReadLine());

            this.ISBN = isbn;
            this.author = auth;
            this.basePrice = bp;
            this.countryTax = ct;
            this.DownloadURL = dwnu;
            this.WeekNum = wn;

        }

        /*public string printURL()
        {
            return this.DownloadURL;
        }*/
    }

}
