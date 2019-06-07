using Own.SmartphoneLib;
using System;

namespace Own.SmartphoneTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartphoneList spList = new SmartphoneList();
            Smartphone sp = new Smartphone
            {
                InternalId = 1,
                Manufacturer = "Apple",
                Model = "iPhone X",
                Price = 850.99
            };

            spList.Add(sp);


            sp = new Smartphone
            {
                InternalId = 2,
                Manufacturer = "Samsung",
                Model = "Galaxy S9",
                Price = 500.99
            };

            spList.Add(sp);


            foreach (Smartphone listSp in spList)
            {
                Console.WriteLine("ID: " + listSp.Id);
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
