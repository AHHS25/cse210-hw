using System;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            // --------- First Order (Customer in USA) ----------
            Address address1 = new Address(
                "123 Main Street",
                "Phoenix",
                "AZ",
                "USA");

            Customer customer1 = new Customer("John Smith", address1);

            Order order1 = new Order(customer1);
            order1.AddProduct(new Product("Wireless Mouse", "WM123", 15.99, 2));
            order1.AddProduct(new Product("Mechanical Keyboard", "MK456", 49.99, 1));
            order1.AddProduct(new Product("USB-C Cable", "UC789", 5.50, 3));

            // --------- Second Order (Customer outside USA) ----------
            Address address2 = new Address(
                "Av. Insurgentes Sur 100",
                "Ciudad de México",
                "CDMX",
                "Mexico");

            Customer customer2 = new Customer("Alan Hernandez", address2);

            Order order2 = new Order(customer2);
            order2.AddProduct(new Product("Laptop Stand", "LS111", 29.99, 1));
            order2.AddProduct(new Product("Webcam", "WC222", 39.99, 1));

            // --------- Display results for each order ----------
            Console.WriteLine("========== ORDER 1 ==========");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order1.GetPackingLabel());

            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order1.GetShippingLabel());

            Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}");
            Console.WriteLine();

            Console.WriteLine("========== ORDER 2 ==========");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order2.GetPackingLabel());

            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order2.GetShippingLabel());

            Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}");
            Console.WriteLine();

            Console.WriteLine("End of program. Press any key to close...");
            Console.ReadKey();
        }
    }
}
