using Part1_ProceduralToOOP.src;

OrderSystem system = new();

SeedSampleData(system);
RunDemoScenario(system);

PrintCustomers(system);
PrintProducts(system);
PrintAllOrders(system);

Console.WriteLine();
Console.WriteLine($"Total Paid Sales: {system.GetTotalPaidSales():C}");

RunInteractiveMenu(system);


static void SeedSampleData(OrderSystem system)
{
    system.AddCustomer(new Customer(
        1, "Mona Ali", "mona@example.com", "Cairo", true));

    system.AddCustomer(new Customer(
        2, "Omar Hassan", "omar@example.com", "Alexandria", false));

    system.AddCustomer(new Customer(
        3, "Sara Nabil", "sara@example.com", "Giza", false));


    system.AddProduct(new Product(
        1, "USB Cable", 50m, 100));

    system.AddProduct(new Product(
        2, "Wireless Mouse", 250m, 40));

    system.AddProduct(new Product(
        3, "Mechanical Keyboard", 1200m, 15));

    system.AddProduct(new Product(
        4, "Laptop Stand", 400m, 25));
}


static void RunDemoScenario(OrderSystem system)
{
    Order? order1 = system.CreateOrder(
        1001, 1, new DateTime(2026, 9, 15));

    order1?.AddLine(system.FindProduct(1)!, 2);
    order1?.AddLine(system.FindProduct(2)!, 1);
    order1?.MarkAsPaid();


    Order? order2 = system.CreateOrder(
        1002, 2, new DateTime(2026, 9, 15));

    order2?.AddLine(system.FindProduct(3)!, 1);
    order2?.AddLine(system.FindProduct(4)!, 1);


    Order? order3 = system.CreateOrder(
        1003, 3, new DateTime(2026, 9, 15));

    order3?.AddLine(system.FindProduct(1)!, 5);
    order3?.MarkAsPaid();
}


static void PrintCustomers(OrderSystem system)
{
    Console.WriteLine("=== Customers ===");

    foreach (Customer customer in system.Customers)
    {
        Console.WriteLine(customer);
    }
}


static void PrintProducts(OrderSystem system)
{
    Console.WriteLine();
    Console.WriteLine("=== Products ===");

    foreach (Product product in system.Products)
    {
        Console.WriteLine(product);
    }
}


static void PrintAllOrders(OrderSystem system)
{
    Console.WriteLine();
    Console.WriteLine("=== Orders ===");

    foreach (Order order in system.Orders)
    {
        Console.WriteLine(order);

        foreach (OrderLine line in order.Lines)
        {
            Console.WriteLine($"   {line}");
        }

        Console.WriteLine();
    }
}


static void RunInteractiveMenu(OrderSystem system)
{
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("=== Order System ===");
        Console.WriteLine("1. View Customers");
        Console.WriteLine("2. View Products");
        Console.WriteLine("3. View All Orders");
        Console.WriteLine("4. View One Order");
        Console.WriteLine("5. Create Order");
        Console.WriteLine("6. Add Line To Order");
        Console.WriteLine("7. Pay Order");
        Console.WriteLine("8. View Paid Sales Total");
        Console.WriteLine("0. Exit");

        Console.Write("Choose an option: ");
        string? choice = Console.ReadLine();

        Console.WriteLine();

        switch (choice)
        {
            case "1":
                PrintCustomers(system);
                break;

            case "2":
                PrintProducts(system);
                break;

            case "3":
                PrintAllOrders(system);
                break;

            case "4":
                ViewOneOrder(system);
                break;

            case "5":
                CreateOrder(system);
                break;

            case "6":
                AddLineToOrder(system);
                break;

            case "7":
                PayOrder(system);
                break;

            case "8":
                Console.WriteLine(
                    $"Total Paid Sales: {system.GetTotalPaidSales():C}");
                break;

            case "0":
                return;

            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }
}


static void ViewOneOrder(OrderSystem system)
{
    Console.Write("Enter order ID: ");

    if (!int.TryParse(Console.ReadLine(), out int orderId))
    {
        Console.WriteLine("Invalid order ID.");
        return;
    }

    Order? order = system.FindOrder(orderId);

    if (order == null)
    {
        Console.WriteLine("Order not found.");
        return;
    }

    Console.WriteLine(order);

    foreach (OrderLine line in order.Lines)
    {
        Console.WriteLine($"   {line}");
    }
}


static void CreateOrder(OrderSystem system)
{
    Console.Write("Enter order ID: ");

    if (!int.TryParse(Console.ReadLine(), out int orderId))
    {
        Console.WriteLine("Invalid order ID.");
        return;
    }

    Console.Write("Enter customer ID: ");

    if (!int.TryParse(Console.ReadLine(), out int customerId))
    {
        Console.WriteLine("Invalid customer ID.");
        return;
    }

    Customer? customer = system.FindCustomer(customerId);

    if (customer == null)
    {
        Console.WriteLine("Customer not found.");
        return;
    }

    Console.Write("Enter order date (yyyy-MM-dd): ");

    if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
    {
        Console.WriteLine("Invalid date.");
        return;
    }

    Order? order = system.CreateOrder(orderId, customerId, date);

    if (order == null)
    {
        Console.WriteLine("Could not create order.");
        return;
    }

    Console.WriteLine("Order created successfully.");
}


static void AddLineToOrder(OrderSystem system)
{
    Console.Write("Enter order ID: ");

    if (!int.TryParse(Console.ReadLine(), out int orderId))
    {
        Console.WriteLine("Invalid order ID.");
        return;
    }

    Order? order = system.FindOrder(orderId);

    if (order == null)
    {
        Console.WriteLine("Order not found.");
        return;
    }

    Console.Write("Enter product ID: ");

    if (!int.TryParse(Console.ReadLine(), out int productId))
    {
        Console.WriteLine("Invalid product ID.");
        return;
    }

    Product? product = system.FindProduct(productId);

    if (product == null)
    {
        Console.WriteLine("Product not found.");
        return;
    }

    Console.Write("Enter quantity: ");

    if (!int.TryParse(Console.ReadLine(), out int quantity))
    {
        Console.WriteLine("Invalid quantity.");
        return;
    }

    if (order.AddLine(product, quantity))
    {
        Console.WriteLine("Product added to order.");
    }
    else
    {
        Console.WriteLine("Could not add product to order.");
    }
}


static void PayOrder(OrderSystem system)
{
    Console.Write("Enter order ID: ");

    if (!int.TryParse(Console.ReadLine(), out int orderId))
    {
        Console.WriteLine("Invalid order ID.");
        return;
    }

    Order? order = system.FindOrder(orderId);

    if (order == null)
    {
        Console.WriteLine("Order not found.");
        return;
    }

    if (order.MarkAsPaid())
    {
        Console.WriteLine("Order paid successfully.");
    }
    else
    {
        Console.WriteLine("Could not pay order.");
    }
}