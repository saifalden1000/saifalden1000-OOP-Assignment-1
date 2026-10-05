namespace Part1_ProceduralToOOP.src;

public class Product
{
    public int Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    public int Stock { get; private set; }

    public Product(int id, string name, decimal price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public bool ReduceStock(int quantity)
    {
        if (quantity <= 0 || quantity > Stock)
        {
            return false;
        }

        Stock -= quantity;
        return true;
    }

    public override string ToString()
    {
        return $"{Id} - {Name} - Price: {Price:C} - Stock: {Stock}";
    }
}