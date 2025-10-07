## Task 1: Simple Summation

#### Edge case: Empty string

First, I considered the base edge case, which is when the string is empty. I added it first because there is no point executing the rest of the code if the string contains nothing.

In the other case: the string has stuff.

Since the inputformat is separated by commas, I used the `split` method to create a list of the numbers. But the elements in the list are still type `str`, so I cast each character into an integer to sum them. After iterating through all elements in the list, I return the total sum.

## Task 2: Infinite Arithmetic

I got a bit a head in the last problem, since the task never mentioned the need of the input being a fixed size, I assumed it could be of any length. So I decided to iterate though all the string, like doing a `for each`.

This way you ensure that regardless of the size of the string it will go through all of it, which also makes the function less specific and more general use or reusable.

## Task 3: Breaking Newlines

For the third task, regex would have been useful, but since that is not the goal, I decided to replace all newlines with commas. The other approach I considered was checking just for numbers within the string, at first glance it looked as a simple and more general solution to the problem. 

```python
sum = 0
    for n in nums:
        if n.isdigit():
            sum+=int(n)
               
    return sum 
```

But i realised that it fails to recognize more than one digit or negative numbers. Since it just evaluates one character in the string, and for those two cases handleing more than one character is needed. To handle numbers bigger tahn 10 I would have to implement a two pointer solution or something that can get all consecutive numbers. Because of this, I dicarded it, since at this point it was easier using `replace()` even though it makes the solution more specific.


## Task 4: Custom Delimeters

Firsly there is one new edge case: the delimiter can be an empty string `""`, in this case I don't `split("")` since is going to throw an error, because an empty separator is not allowed. So in this case I `return 0` because if there is no separator, then I cannot tell if is a single digit or multiple digits or if is negative. So, I added the mandatory condition that a separator needs to be specified.

Example:
`"//\n123-790"`

How do I tell if `123` is `1`, `2` and `3` or if `123`. Same with `-7` or `-790`. Too much edge cases, and it over complicated the solution, so for my *mental peace* I just don't accept empty delimeter.


## Task 5: Negative Rebellion

The last exceptions were direct, but for "Not negative values allowed" exception has more layers to it. The challenging part is composing the error message, since it had to list all negative numbers from the input string. Initially, I considered simply checking if the string contained any `'-'` characters and stopping at the first negative, but then I realized two things: one that the string can be separated by `-` and also I needed to collect all negative numbers to output them in the the error message.

I had to store the negative numbers, so I created an empty list on which it adds the negative numbers as it finds them. So, for the validation I checked if the array was empty, if not I printed the error message and added the array as a string. If it was empty then there where no negative numbers found.

Since I was aading an exception, then I also modified my other edge cases to have an exception instead of returning 0. So is more descriptive of what is actually happening and why is failing.