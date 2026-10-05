namespace Part3_BuilderPattern.src;

public class Invoice
{
    public int InvoiceId { get; }
    public string CustomerName { get; }
    public string CustomerEmail { get; }
    public string CustomerPhone { get; }

    public Address BillingAddress { get; }
    public Address ShippingAddress { get; }

    public DateTime OrderDate { get; }
    public string PaymentMethod { get; }
    public string Currency { get; }
    public decimal SubTotal { get; }
    public decimal DiscountAmount { get; }
    public decimal TaxAmount { get; }
    public decimal TotalAmount { get; }

    internal Invoice(
        int invoiceId,
        string customerName,
        string customerEmail,
        string customerPhone,
        Address billingAddress,
        Address shippingAddress,
        OrderInfo orderInfo)
    {
        InvoiceId = invoiceId;
        CustomerName = customerName;
        CustomerEmail = customerEmail;
        CustomerPhone = customerPhone;
        BillingAddress = billingAddress;
        ShippingAddress = shippingAddress;
        OrderDate = orderInfo.OrderDate;
        PaymentMethod = orderInfo.PaymentMethod;
        Currency = orderInfo.Currency;
        SubTotal = orderInfo.SubTotal;
        DiscountAmount = orderInfo.DiscountAmount;
        TaxAmount = orderInfo.TaxAmount;
        TotalAmount = orderInfo.TotalAmount;
    }
}