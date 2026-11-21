
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double totalCost = 0;

        foreach (Product product in _products)
        {
            totalCost += product.GetTotalCost();
        }

        double shippingCost;

        if (_customer.IsInUSA())
        {
            shippingCost = 5;
        }
        else
        {
            shippingCost = 35;
        }

        return totalCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "PACKING LABEL\n";

        foreach (Product product in _products)
        {
            label += $"Product: {product.GetName()}\n";
            label += $"Product ID: {product.GetProductId()}\n";
            label += "-------------------------\n";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return "SHIPPING LABEL\n" +
               $"Customer: {_customer.GetName()}\n" +
               _customer.GetAddress();
    }
}
