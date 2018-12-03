using Own.SmartphoneLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Own.SmartphoneTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartphoneList spList = new SmartphoneList();
            Smartphone sp = new Smartphone();

            sp.InternalId = 1;
            sp.Manufacturer = "Apple";
            sp.Model = "iPhone X";
            sp.Price = 850.99;

            spList.Add(sp);


            sp = new Smartphone();

            sp.InternalId = 2;
            sp.Manufacturer = "Samsung";
            sp.Model = "Galaxy S9";
            sp.Price = 500.99;

            spList.Add(sp);


            foreach (Smartphone listSp in spList)
            {
                Console.WriteLine("Internal ID: " + listSp.InternalId);
                Console.WriteLine("Manufacturer: " + listSp.Manufacturer);
                Console.WriteLine("Model: " + listSp.Model);
                Console.WriteLine("Price: " + listSp.Price);
                Console.WriteLine("- - -");
            }


            Smartphone found = spList.GetByInternalId(1);
            Console.WriteLine("Found: " + found.Model);

            Smartphone cheapest = spList.GetCheapest();
            Console.WriteLine("Cheapest: " + cheapest.Model);


            spList.SetDiscount(5);

            foreach (Smartphone listSp in spList)
            {
                Console.WriteLine(listSp.Model + " - new price: " + listSp.Price);
            }
        }
    }
}
