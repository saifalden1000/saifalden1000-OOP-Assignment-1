using Part3_BuilderPattern.src;

AddressBuilder billingAddress = new AddressBuilder()
    .SetStreet("10 Main Street")
    .SetCity("Alexandria")
    .SetState("Alexandria")
    .SetZipCode("21500")
    .SetCountry("Egypt");

AddressBuilder shippingAddress = new AddressBuilder()
    .SetStreet("20 Sea Road")
    .SetCity("Alexandria")
    .SetState("Alexandria")
    .SetZipCode("21500")
    .SetCountry("Egypt");

OrderBuilder order = new OrderBuilder()
    .SetOrderDate(DateTime.Now)
    .SetPaymentMethod("Visa")
    .SetCurrency("EGP")
    .SetAmounts(5000m, 500m, 450m, 4950m);

Invoice invoice = new InvoiceBuilder()
    .SetInvoiceId(1001)
    .SetCustomerName("Ahmed Hassan")
    .SetCustomerEmail("ahmed@example.com")
    .SetCustomerPhone("01012345678")
    .SetBillingAddress(billingAddress)
    .SetShippingAddress(shippingAddress)
    .SetOrder(order)
    .Build();

Console.WriteLine($"Invoice ID: {invoice.InvoiceId}");
Console.WriteLine($"Customer: {invoice.CustomerName}");
Console.WriteLine($"Billing City: {invoice.BillingAddress.City}");
Console.WriteLine($"Shipping City: {invoice.ShippingAddress.City}");
Console.WriteLine($"Payment: {invoice.PaymentMethod}");
Console.WriteLine($"Total: {invoice.TotalAmount}");