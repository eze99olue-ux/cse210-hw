
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create the first customer's address
        Address address1 = new Address(
            "123 Main Street",
            "New York",
            "New York",
            "USA"
        );

        // Create the first customer
        Customer customer1 = new Customer(
            "John Smith",
            address1
        );

        // Create the first order
        Order order1 = new Order(customer1);

        // Create products for the first order
        Product product1 = new Product(
            "Wireless Headphones",
            "P101",
            45.00,
            2
        );

        Product product2 = new Product(
            "Bluetooth Speaker",
            "P102",
            60.00,
            1
        );

        Product product3 = new Product(
            "Phone Charger",
            "P103",
            15.00,
            3
        );

        // Add products to the first order
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);


        // Create the second customer's address
        Address address2 = new Address(
            "25 Oxford Street",
            "London",
            "Greater London",
            "United Kingdom"
        );

        // Create the second customer
        Customer customer2 = new Customer(
            "Mary Johnson",
            address2
        );

        // Create the second order
        Order order2 = new Order(customer2);

        // Create products for the second order
        Product product4 = new Product(
            "Laptop",
            "P201",
            750.00,
            1
        );

        Product product5 = new Product(
            "Wireless Mouse",
            "P202",
            25.00,
            2
        );

        // Add products to the second order
        order2.AddProduct(product4);
        order2.AddProduct(product5);


        // Store all orders in a list
        List<Order> orders = new List<Order>
        {
            order1,
            order2
        };

        // Display information for each order
        int orderNumber = 1;

        foreach (Order order in orders)
        {
            Console.WriteLine("====================================");
            Console.WriteLine($"ORDER {orderNumber}");
            Console.WriteLine("====================================");

            Console.WriteLine();
            Console.WriteLine(order.GetPackingLabel());

            Console.WriteLine();
            Console.WriteLine(order.GetShippingLabel());

            Console.WriteLine();
            Console.WriteLine(
                $"Total Order Cost: ${order.GetTotalCost():F2}"
            );

            Console.WriteLine();

            orderNumber++;
        }
    }
}
