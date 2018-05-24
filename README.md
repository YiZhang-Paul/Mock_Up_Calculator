# Mock Up Calculator - For Demonstration Only

A personal project in an attempt to replicate Microsoft Windows 10 [_built-in calculator_][microsoft calculator support].

The project currently supports:

  1. Standard Calculator (supports nested expressions)
  2. Scientific Calculator (advanced arithmetic operations)
  3. Currency Converter (**_pulling live exchange rate_** from web APIs such as [fixer.io])
  
The source code is unit-tested using MSTest and [Moq]. Each integrated component is also integration-tested.

### Why replicate a Calculator?

The main purpose of this project is to enhance the author's overall skill of:

  * software design (not UX design)
  * applying design patterns (if applicable)
  * applying of **SOLID** principles (when applicable)
  * software testing
  * software documentation
  
Through replicating, the author can fully concentrate on overall requirement, design and implementation of a practical software. 

### What are some planned improvements?

The application lacks the ability to handle big numbers. The author will seek to add big number support and deal with related performance issues due to big number handling.

[microsoft calculator support]: https://support.microsoft.com/en-ca/help/4026389/windows-calculator-in-windows-10
[fixer.io]: https://fixer.io/ "fixer"
[Moq]: https://github.com/moq/moq4
