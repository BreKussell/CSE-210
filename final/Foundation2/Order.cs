using System.Collections.Generic;
using System.Text;
using ProductOrderingSystem;

public class Order
{
    private List<Product> Products = new List<Product>();
    private Customer Customer;
    private const decimal ShippingCostUSA = 5m;
    private const decimal ShippingCostInternational = 35m;

    public Order(Customer customer)
    {
        Customer = customer;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal total = Customer.LivesInUSA() ? ShippingCostUSA : ShippingCostInternational;
        foreach (var product in Products)
        {
            total += product.GetTotalCost();
        }
        return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();
        foreach (var product in Products)
        {
            label.AppendLine($"Product: {product.Name}, ID: {product.ProductId}");
        }
        return label.ToString();
    }

    public string GetShippingLabel()
    {
        return $"{Customer.Name}\n{Customer.Address}";
    }
}