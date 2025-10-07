## Task 1: Simple Summation

#### Edge case: Empty string

First, I considered the base edge case, which is when the string is empty. I added it first because there is no point executing the rest of the code if the string contains nothing.

In the other case: the string has stuff.

Since the inputformat is separated by commas, I used the `split` method to create a list of the numbers. But the elements in the list are still type `str`, so I cast each character into an integer to sum them. After iterating through all elements in the list, I return the total sum.

## Task 2: Infinite Arithmetic

I got a bit a head in the last problem, since the task never mentioned the need of the input being a fixed size, I assumed it could be of any length. So I decided to iterate though all the string, like doing a `for each`.

This way you ensure that regardless of the size of the string it will go through all of it, which also makes the function less specific and more general use or reusable.