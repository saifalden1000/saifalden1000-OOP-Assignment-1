namespace Part3_BuilderPattern.src;

public class OrderBuilder
{
    private DateTime _orderDate;
    private string? _paymentMethod;
    private string? _currency;
    private decimal _subTotal;
    private decimal _discountAmount;
    private decimal _taxAmount;
    private decimal _totalAmount;

    public OrderBuilder SetOrderDate(DateTime orderDate)
    {
        _orderDate = orderDate;
        return this;
    }

    public OrderBuilder SetPaymentMethod(string paymentMethod)
    {
        _paymentMethod = paymentMethod;
        return this;
    }

    public OrderBuilder SetCurrency(string currency)
    {
        _currency = currency;
        return this;
    }

    public OrderBuilder SetAmounts(
        decimal subTotal,
        decimal discountAmount,
        decimal taxAmount,
        decimal totalAmount)
    {
        _subTotal = subTotal;
        _discountAmount = discountAmount;
        _taxAmount = taxAmount;
        _totalAmount = totalAmount;

        return this;
    }

    public OrderInfo Build()
    {
        if (string.IsNullOrWhiteSpace(_paymentMethod))
        {
            throw new InvalidOperationException("Payment method is required.");
        }

        if (string.IsNullOrWhiteSpace(_currency))
        {
            throw new InvalidOperationException("Currency is required.");
        }

        return new OrderInfo(
            _orderDate,
            _paymentMethod,
            _currency,
            _subTotal,
            _discountAmount,
            _taxAmount,
            _totalAmount);
    }
}