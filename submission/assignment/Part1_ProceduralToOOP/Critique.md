# Part 1 - Procedural C++ Critique

## 1. Global State

The program stores almost all of its state in global variables, such as
customerCount, productCount, orderCount, and the arrays containing customers,
products, and orders.

This is a problem because any function in the program can directly modify this
state. There is no clear owner responsible for the data, and there is no
encapsulation.

As the program grows, it becomes difficult to understand which functions can
change a particular piece of data. An accidental modification could leave the
system in an invalid or inconsistent state.

A better design would make the state belong to objects such as Customer,
Product, Order, and OrderLine.

---

## 2. Parallel Arrays

Customer information is stored in several separate arrays:

- customerIds
- customerNames
- customerEmails
- customerCities
- customerIsVip

The same approach is used for products and orders.

This makes the program dependent on array indexes to keep related information
together. For example, the data at index 2 in all customer arrays must belong
to the same customer.

This is fragile because if one array is modified incorrectly, the information
can become mismatched. It also makes the code harder to understand because
there is no single object representing a Customer.

A Customer class could keep all customer information together.

---

## 3. Fixed-Size Arrays

The program uses fixed limits such as:

- MAX_CUSTOMERS = 50
- MAX_PRODUCTS = 50
- MAX_ORDERS = 100
- MAX_LINES_PER_ORDER = 20

This limits the system to a fixed number of customers, products, orders, and
order lines.

If the system exceeds one of these limits, it cannot accept additional data.
The program therefore has an artificial capacity restriction that is caused by
the implementation rather than the business requirements.

A better design would use collections such as List<T> in C# where appropriate.

---

## 4. Index-Based Relationships

Orders do not directly reference Customer or Product objects.

Instead, an order stores a customer index:

orderCustomerIndexes

and order lines store product indexes:

lineProductIndexes

This means the program depends on indexes remaining correct.

The relationship between an Order and its Customer or Products is therefore
indirect and difficult to understand.

With OOP, an Order could contain a reference to a Customer, while an
OrderLine could contain a reference to a Product.

---

## 5. Order Line Data Is Split Across Multiple Arrays

Order line information is stored using two separate two-dimensional arrays:

- lineProductIndexes
- lineQuantities

The product and quantity at the same position represent one order line.

This has the same synchronization problem as the other parallel arrays. The
program has no object representing an OrderLine.

Creating an OrderLine class would allow the product and quantity to belong
together naturally.

---

## 6. Functions Directly Manipulate Data Owned by Other Concepts

Functions such as addCustomer, addProduct, createOrder, and addLineToOrder
directly manipulate the global arrays.

The functions are therefore responsible for both performing operations and
knowing the internal storage details of the entire system.

This creates strong coupling between the functions and the data structures.

If the way customers or orders are stored changes, many functions would need
to be changed.

In an OOP design, each class should own its state and expose appropriate
behavior for working with that state.

---

## 7. Business Logic Is Mixed With Console/UI Logic

Several functions perform business operations while also printing error
messages directly to the console.

For example, addLineToOrder checks business rules such as stock availability
and quantity validity and then prints an error message if a rule is violated.

This mixes application logic with presentation logic.

If the system later needed a web API or GUI instead of a console application,
the business logic would be difficult to reuse because it is tied directly to
console output.

---

## 8. Weak Validation and Invalid State

Some important values are not properly validated when customers and products
are created.

For example, the program does not properly enforce rules such as:

- customer name must be non-empty
- email must be valid
- product price must be positive
- product stock must not be negative

This means invalid data can enter the system.

In an OOP design, the class responsible for the data should enforce the rules
that protect its own state.

---

## 9. Error Handling Uses Return Values and Console Messages

Functions such as createOrder return -1 when an operation fails, while other
functions simply print an error message and return.

This makes error handling inconsistent.

The caller must know the special meaning of values such as -1, and some
operations provide no clear indication of failure at all.

A cleaner design could use exceptions for invalid operations where appropriate
and keep error handling separate from the domain logic.

---

## 10. Customer-Specific Business Logic Is Outside the Customer

The VIP discount is calculated inside calculateOrderTotal:

if (customerIsVip[customerIndex])
total = total \* 0.90;

The function has to know how customer information is stored and how VIP status
is represented.

This means Customer behavior and customer-related rules are scattered outside
the Customer concept.

An object-oriented design gives each class responsibility for behavior that
belongs naturally to that object.

---

## 11. Order Behavior Is Scattered Across Free Functions

Operations related to an order are implemented as separate global functions:

- createOrder
- addLineToOrder
- calculateOrderTotal
- markOrderPaid
- printOrder

There is no Order object that owns the order's data and behavior.

This makes it harder to enforce rules consistently because any function that
can access the global state can potentially modify the order.

An Order class can encapsulate its state and expose only the operations that
are valid for an order.

---

## 12. Storage Details Are Exposed Everywhere

Many functions need to know implementation details such as array indexes,
counts, and maximum sizes.

For example, calculating an order total requires navigating from an order
index to a customer index and then through product indexes.

This makes the code harder to read and maintain because the business concepts
are hidden behind low-level storage details.

An object-oriented design can express the domain directly through objects and
relationships.

---

## 13. The Program Has Poor Separation of Responsibilities

The same file contains:

- Data storage
- Customer operations
- Product operations
- Order operations
- Payment logic
- Sales calculations
- Console printing
- Menu handling
- Demo/seed data

This makes the program harder to maintain and extend.

Separating responsibilities into classes and appropriate application-level
code would make the system easier to understand and modify.

---

## 14. String Is Used for the Order Date

The order date is stored as a string:

string orderDates[MAX_ORDERS];

Using a plain string means the program does not have a proper date type
enforcing valid date values.

For example, invalid date text could potentially be stored.

A C# implementation could use an appropriate date type such as DateTime.

---

## 15. The Design Does Not Protect Invariants

The procedural design has no object boundaries that protect the validity of
Customer, Product, Order, or OrderLine data.

The program relies on functions following the correct sequence and correctly
maintaining multiple global arrays.

As the application becomes larger, this makes invalid or inconsistent state
more likely.

Encapsulation would allow each object to control how its state is created and
modified.
