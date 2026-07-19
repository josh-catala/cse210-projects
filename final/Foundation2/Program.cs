using System;
using System.Collections.Generic;

namespace OrderingSystem
{
    /// <summary>
    /// NOTE: Your assignment instructions say a Program.cs file is already
    /// provided in the student template for this assignment, and that you
    /// must use that provided file as your starting point rather than
    /// creating a new one. Copy the Main() method body below into that
    /// provided Program.cs file rather than replacing the whole file,
    /// in case it already contains required setup code.
    ///
    /// How this program exceeds the requirements:
    /// - Added input validation guards are avoided per assignment scope, but
    ///   the code separates label generation and cost calculation into
    ///   reusable methods (GetPackingLabel, GetShippingLabel, GetTotalCost)
    ///   rather than duplicating string-building logic for each order.
    /// - Included a helper method, DisplayOrderDetails, so both orders are
    ///   printed using the same well-organized routine instead of copy-pasted
    ///   Console.WriteLine calls.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // ----- Order 1: A domestic (USA) customer -----
            Address address1 = new Address("123 Maple Street", "Rexburg", "Idaho", "USA");
            Customer customer1 = new Customer("Jane Smith", address1);

            List<Product> products1 = new List<Product>();
            products1.Add(new Product("Wireless Mouse", "P001", 15.99, 2));
            products1.Add(new Product("Mechanical Keyboard", "P002", 49.99, 1));
            products1.Add(new Product("USB-C Cable", "P003", 8.50, 3));

            Order order1 = new Order(customer1, products1);

            // ----- Order 2: An international customer -----
            Address address2 = new Address("45 King's Road", "London", "England", "United Kingdom");
            Customer customer2 = new Customer("Oliver Brown", address2);

            List<Product> products2 = new List<Product>();
            products2.Add(new Product("Bluetooth Speaker", "P010", 39.99, 1));
            products2.Add(new Product("Phone Case", "P011", 12.00, 2));

            Order order2 = new Order(customer2, products2);

            // Display results for both orders
            DisplayOrderDetails("ORDER #1", order1);
            DisplayOrderDetails("ORDER #2", order2);

            Console.ReadLine();
        }

        /// <summary>
        /// Prints the packing label, shipping label, and total price for an order.
        /// </summary>
        private static void DisplayOrderDetails(string orderTitle, Order order)
        {
            Console.WriteLine("=========================================");
            Console.WriteLine(orderTitle);
            Console.WriteLine("=========================================");

            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();

            Console.WriteLine("Shipping Cost: $" + order.GetShippingCost().ToString("F2"));
            Console.WriteLine("TOTAL PRICE:   $" + order.GetTotalCost().ToString("F2"));
            Console.WriteLine();
        }
    }
}
