namespace Part3_BuilderPattern.src;

public class InvoiceBuilder
{
    private int _invoiceId;
    private string? _customerName;
    private string? _customerEmail;
    private string? _customerPhone;
    private Address? _billingAddress;
    private Address? _shippingAddress;
    private OrderInfo? _orderInfo;

    public InvoiceBuilder SetInvoiceId(int invoiceId)
    {
        _invoiceId = invoiceId;
        return this;
    }

    public InvoiceBuilder SetCustomerName(string customerName)
    {
        _customerName = customerName;
        return this;
    }

    public InvoiceBuilder SetCustomerEmail(string customerEmail)
    {
        _customerEmail = customerEmail;
        return this;
    }

    public InvoiceBuilder SetCustomerPhone(string customerPhone)
    {
        _customerPhone = customerPhone;
        return this;
    }

    public InvoiceBuilder SetBillingAddress(AddressBuilder addressBuilder)
    {
        _billingAddress = addressBuilder.Build();
        return this;
    }

    public InvoiceBuilder SetShippingAddress(AddressBuilder addressBuilder)
    {
        _shippingAddress = addressBuilder.Build();
        return this;
    }

    public InvoiceBuilder SetOrder(OrderBuilder orderBuilder)
    {
        _orderInfo = orderBuilder.Build();
        return this;
    }

    public Invoice Build()
    {
        if (_invoiceId <= 0)
            throw new InvalidOperationException("Invoice ID is required.");

        if (string.IsNullOrWhiteSpace(_customerName))
            throw new InvalidOperationException("Customer name is required.");

        if (string.IsNullOrWhiteSpace(_customerEmail))
            throw new InvalidOperationException("Customer email is required.");

        if (_billingAddress == null)
            throw new InvalidOperationException("Billing address is required.");

        if (_shippingAddress == null)
            throw new InvalidOperationException("Shipping address is required.");

        if (_orderInfo == null)
            throw new InvalidOperationException("Order information is required.");

        return new Invoice(
            _invoiceId,
            _customerName,
            _customerEmail,
            _customerPhone ?? string.Empty,
            _billingAddress,
            _shippingAddress,
            _orderInfo);
    }
}