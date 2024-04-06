using System;

namespace ProductOrderingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the address details for the order.");

            Console.Write("Street: ");
            string street = Console.ReadLine();

            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.Write("State: ");
            string state = Console.ReadLine();

            Console.Write("Country: ");
            string country = Console.ReadLine();

            Address address = new Address(street, city, state, country);
            Customer customer = new Customer("Customer Name", address); // Assuming customer name for simplicity; you could also prompt for this

            Order order = new Order(customer);
            
            // Example adding products (you might want to loop and ask for user input here too)
            order.AddProduct(new Product("Laptop", 1, 999.99m, 1));
            order.AddProduct(new Product("Mouse", 2, 24.99m, 2));

            Console.WriteLine("\nOrder Details:");
            Console.WriteLine("Total Cost: $" + order.GetTotalCost());
            Console.WriteLine("Packing Label:\n" + order.GetPackingLabel());
            Console.WriteLine("Shipping Label:\n" + order.GetShippingLabel());
        }
    }
}