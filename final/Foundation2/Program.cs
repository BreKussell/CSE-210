using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductOrderingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Predefined list of products
            List<Product> availableProducts = new List<Product>
            {
                new Product("Laptop", 1, 999.99m, 1),
                new Product("Mouse", 2, 24.99m, 1),
                new Product("Keyboard", 3, 49.99m, 1),
                new Product("Monitor", 4, 149.99m, 1),
                new Product("USB Cable", 5, 5.99m, 1)
            };

            // Display available products
            Console.WriteLine("Available Products:");
            foreach (var product in availableProducts)
            {
                Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, Price: ${product.Price}");
            }

            // Create a new order
            Console.WriteLine("\nPlease enter the address details for the order.");
            Console.Write("Street: ");
            string street = Console.ReadLine();
            Console.Write("City: ");
            string city = Console.ReadLine();
            Console.Write("State: ");
            string state = Console.ReadLine();
            Console.Write("Country: ");
            string country = Console.ReadLine();

            Address address = new Address(street, city, state, country);
            Customer customer = new Customer("Customer Name", address); // Customer name is still hardcoded
            Order order = new Order(customer);

            // Ask the user to pick products by ID to add to the order
            Console.WriteLine("\nEnter the product IDs to add to your order (separated by commas, e.g., 1,3,5):");
            string[] productIds = Console.ReadLine().Split(',');
            foreach (var id in productIds)
            {
                int productId;
                if (int.TryParse(id.Trim(), out productId))
                {
                    var productToAdd = availableProducts.FirstOrDefault(p => p.ProductId == productId);
                    if (productToAdd != null)
                    {
                        order.AddProduct(productToAdd);
                        Console.WriteLine($"Added {productToAdd.Name} to your order.");
                    }
                    else
                    {
                        Console.WriteLine($"Product with ID {productId} not found.");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid ID: {id}");
                }
            }

            // Display order details
            Console.WriteLine("\nOrder Details:");
            Console.WriteLine("Total Cost: $" + order.GetTotalCost());
            Console.WriteLine("Packing Label:\n" + order.GetPackingLabel());
            Console.WriteLine("Shipping Label:\n" + order.GetShippingLabel());
        }
    }
}