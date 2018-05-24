# Mock Up Calculator - For Demonstration Only

A personal project in an attempt to replicate Microsoft Windows 10 [_built-in calculator_][microsoft calculator support].

The project currently supports:

  * Standard Calculator (supports nested expressions)
  * Scientific Calculator (advanced arithmetic operations)
  * Currency Converter (**_pulling live exchange rate_** from web APIs such as [fixer.io])
  
The source code is unit-tested using MSTest and [Moq]. Each integrated component is also integration-tested. For more information on the overall design and technical details of the project, please refer to the [wiki][wiki page] page for better clarification.

## Why replicate a Calculator?

The main purpose of this project is to enhance the author's overall skill of:

  * software design (not UX design)
  * applying design patterns (if applicable)
  * applying **SOLID** principles (when applicable)
  * software testing
  * software documentation
  
Through replicating, the author can fully concentrate on overall requirement, design and implementation of a practical software. 

## What are some planned improvements?

The application lacks the ability to handle big numbers. The author will seek to add big number support and deal with related performance issues due to big number handling.

## License

Copyright (c) 2018 Yi Zhang

The project is intended for personal use only and therefore a license is not provided. Should the owner of original software ([windows 10 built-in calculator][microsoft calculator support]) request author to take down the project due to replicated UI, please [open an issue][issue page] in this repository or contact the author at scaccterran@gmail.com, and the author will take down the replicated portions immediately.

[microsoft calculator support]: https://support.microsoft.com/en-ca/help/4026389/windows-calculator-in-windows-10 "Link to official page"
[wiki page]: https://github.com/YiZhang-Paul/Mock_Up_Calculator/wiki "Wiki"
[issue page]: https://github.com/YiZhang-Paul/Mock_Up_Calculator/issues "Open Issue"
[fixer.io]: https://fixer.io/ "fixer"
[Moq]: https://github.com/moq/moq4
