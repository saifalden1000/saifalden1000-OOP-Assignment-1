namespace Part1_ProceduralToOOP.src;

public class Order
{
    private readonly List<OrderLine> _lines = new();

    public int Id { get; }
    public Customer Customer { get; }
    public DateTime Date { get; }
    public bool IsPaid { get; private set; }

    public IReadOnlyList<OrderLine> Lines => _lines;

    public Order(int id, Customer customer, DateTime date)
    {
        Id = id;
        Customer = customer;
        Date = date;
        IsPaid = false;
    }

    public bool AddLine(Product product, int quantity)
    {
        if (IsPaid || quantity <= 0)
        {
            return false;
        }

        if (!product.ReduceStock(quantity))
        {
            return false;
        }

        _lines.Add(new OrderLine(product, quantity));
        return true;
    }

    public decimal CalculateTotal()
    {
        decimal total = _lines.Sum(line => line.GetTotal());

        if (Customer.IsVip)
        {
            total *= 0.90m;
        }

        return total;
    }

    public bool MarkAsPaid()
    {
        if (IsPaid || _lines.Count == 0)
        {
            return false;
        }

        IsPaid = true;
        return true;
    }

    public override string ToString()
    {
        string status = IsPaid ? "Paid" : "Unpaid";

        return $"Order {Id} | Customer: {Customer.Name} | " +
               $"Date: {Date:yyyy-MM-dd} | Status: {status} | " +
               $"Total: {CalculateTotal():C}";
    }
}