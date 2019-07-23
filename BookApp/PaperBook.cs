using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp
{
    public class PaperBook : Book
    {
        //Data Members
        public double shippingWeight { get; set; }

        public double handlingCost { get; set; }

        //Constructor Functions
        public PaperBook(string ISBN) : base(ISBN)
        {
            shippingWeight = 0;
            handlingCost = 0;
        }

        public PaperBook(string ISBN, string author, double basePrice, double countryTax, double shippingWeight, double handlingCost) : base(ISBN, author, basePrice, countryTax)
        {
            this.shippingWeight = shippingWeight;
            this.handlingCost = handlingCost;
        }

        public PaperBook() : base()
        {
            shippingWeight = 0;
            handlingCost = 0;
        }

        //Member Functions
        //All of these member functions override the ones decalred in the parent class as they are specific to this class

        public override void DisplayDetails()
        {
            Console.WriteLine("\t{0}  {1,10 } {2,10} {3,10} {4,10} {5,10}", ISBN, author, basePrice.ToString("F2"), countryTax.ToString("F2"), shippingWeight.ToString("F2"), handlingCost.ToString("F2"));
        }

        public override void Print()
        {
            Console.WriteLine("\n\tISBN\t\t" + this.ISBN);
            Console.WriteLine("\tAuthor\t\t" + this.author);
            Console.WriteLine("\tBase Price\t" + this.basePrice);
            Console.WriteLine("\tCountry Tax\t" + this.countryTax);
            Console.WriteLine("\tShipping Weight\t" + this.shippingWeight);
            Console.WriteLine("\tHandling Costs\t" + this.handlingCost);
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

            Console.WriteLine("Please enter the shipping weight");
            double sw = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter the handling costs");
            double hc = Convert.ToDouble(Console.ReadLine());

            this.ISBN = isbn;
            this.author = auth;
            this.basePrice = bp;
            this.countryTax = ct;
            this.shippingWeight = sw;
            this.handlingCost = hc;

        }

        public override double CalculateCost()
        {
            return this.basePrice + (this.basePrice * (countryTax / 100)) + this.handlingCost + this.shippingWeight;
        }
    }
}
