namespace Part1_ProceduralToOOP.src;

public class OrderLine
{
    public Product Product { get; }
    public int Quantity { get; }

    public OrderLine(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public decimal GetTotal()
    {
        return Product.Price * Quantity;
    }

    public override string ToString()
    {
        return $"{Product.Name} x {Quantity} = {GetTotal():C}";
    }
}