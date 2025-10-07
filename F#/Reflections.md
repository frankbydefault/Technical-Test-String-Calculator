# Reflection using F#

## Task 1: Simple Summation


### Just configuration
Followed the getting started doc and also installed Ionide in VScode.

Initially, I tested my functions in `Task.fsx` using FSI. Later, tried using `Program.fs` as intended, but i had to wrap my functions into a module so I could import them properly. I also realized that F# not only process code secuntially, but files too. Solved this, modifiying `F#.fsproj` and loading `Task1.fsx` before `Program.fs`.

### The code

At first F# is not very readable even tho in the documentation it says so. I see that it uses a lot of symbols instead of words, so is hard to read it as a sentence at first.

Comming from solving the problem in python I already knew the steps I had to do. I satrted trying to make a function, but it turned to be a bit more challenging. Variables were all unmutable unless specified and pretty much each line of code would be a return value. So making it all into one function was hard to manage and read. I figured making multiple functions, each handlening one step, it would be easier for me to follow and read. Since I'm more familiar on a function returning a value that a line of code returning a value.

The steps, each being a function:

1. Divide the string given into an array/list ($f_1$)
2. Converts the values of the array into int ($f_2$)
3. Sum each element of the array ($f_3$)

Then I had to pack all my steps in one function to execute them in order. For this I used `|>` to queue functions like making a pipeline:
`func1 |> func2 |> func3`.  I read `|>` as **"Goes to"**, since is like "this data goes to this function" it was pretty similar to making RAGS in airflow and so I just treated my code as a data pipeline.

**Note:** Even if F# autodetects the types of data, I still especified my input and output data. Actually Ionide extension in vscode helped me a lot with the input and output data types, that's why I specified them in the functions, and I think is good to do so you don't end up passing stuff that it shouldn't.

## Task 2: Infinite Arithmetic

I didn't add any modifications from Task 1. Since the solution already handles any string size.

## Task 3: Breaking Newlines

Basically I mantained the structure but made a modification to the `splitString` function. I hard coded an array of the input separators, then applied them into the `split()` method. Made me really happy to see that in F# the `split` can handle multiple separators in one go, it works more like a "filter everithing that is in this list" and it saves me extra lines of code. I don't know why Pyhton `split` doen't allow this, makes so much sence.

Some extra logic I had to add was a way to remove empty strings, since I also added a new edge case: What if we have consecutive separators, like `"1,,2"`. The `split` would produce a list `['1', '', '2']` and the sum will fail.

**Note:** In the documentation there is an example with `split()` to handle empty or white spaces like `let subs = s.Split(separators, StringSplitOptions.RemoveEmptyEntries)` but I couldn't manage to make it work, so I just made a filter manually using a anonymous function.

