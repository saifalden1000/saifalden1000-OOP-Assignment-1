using System;
using System.Collections.Generic;
using System.Linq;

namespace Part1_ProceduralToOOP.src;

public class OrderSystem
{
    private readonly List<Customer> _customers = new();
    private readonly List<Product> _products = new();
    private readonly List<Order> _orders = new();

    public IReadOnlyList<Customer> Customers => _customers;
    public IReadOnlyList<Product> Products => _products;
    public IReadOnlyList<Order> Orders => _orders;

    public bool AddCustomer(Customer customer)
    {
        if (_customers.Any(c => c.Id == customer.Id))
        {
            return false;
        }

        _customers.Add(customer);
        return true;
    }

    public bool AddProduct(Product product)
    {
        if (_products.Any(p => p.Id == product.Id))
        {
            return false;
        }

        _products.Add(product);
        return true;
    }

    public Order? CreateOrder(int orderId, int customerId, DateTime date)
    {
        if (_orders.Any(o => o.Id == orderId))
        {
            return null;
        }

        Customer? customer = _customers.FirstOrDefault(c => c.Id == customerId);

        if (customer == null)
        {
            return null;
        }

        Order order = new Order(orderId, customer, date);
        _orders.Add(order);

        return order;
    }

    public Customer? FindCustomer(int id)
    {
        return _customers.FirstOrDefault(c => c.Id == id);
    }

    public Product? FindProduct(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public Order? FindOrder(int id)
    {
        return _orders.FirstOrDefault(o => o.Id == id);
    }

    public decimal GetTotalPaidSales()
    {
        return _orders
            .Where(o => o.IsPaid)
            .Sum(o => o.CalculateTotal());
    }
}