# Task 3.1

## 1. Why is a 20-parameter constructor a problem?

It is hard to read and easy to pass values in the wrong order, especially when parameters have the same type. It also becomes harder to maintain when new properties are added.

## 2. Is it only because the constructor is long?

No. The class also contains different types of information that could be separated, such as address and payment information.

# Task 3.3

## Why is the composed builder better?

### Single Responsibility

Each builder has one job, such as handling addresses or order information.

### Independent Validation

Each builder can validate its own data.

### Reuse

The same AddressBuilder can be used for billing and shipping.

### Readability

The code is easier to understand because related properties are grouped together.