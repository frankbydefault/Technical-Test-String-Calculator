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

Basically I mantained the structure but made a modification to the `splitString` function. I hard coded an array of the input separators, then applied them into the `split()` method. Made me really happy to see that in F# the `split` can handle multiple separators in one go, it works more like a "filter everything that is in this list" and it saves me extra lines of code. I don't know why Pyhton `split` doen't allow this, makes so much sence.

Some extra logic I had to add was a way to remove empty strings, since I also added a new edge case: What if we have consecutive separators, like `"1,,2"`. The `split` would produce a list `['1', '', '2']` and the sum will fail.

Also kodified the base edge case. Is pretty common to have a methods like .isEmpty() already built in, so I searched for something like that. This got me in a rabbit hole on understanding `null` and `None`. Since F# can use some stuff from C#, then many things get mixed. In F# there is only `None` but `null` is supported as is used in C#. Any way I changed my aproach of `if str = null || str = "" then` to a more simpler and readable `if String.IsNullOrWhiteSpace str`.

**Note:** In the documentation there is an example with `split()` to handle empty or white spaces like `let subs = s.Split(separators, StringSplitOptions.RemoveEmptyEntries)` but I couldn't manage to make it work, so I just made a filter manually using a anonymous function.

## Task 4: Custom Delimeters

This task made me re-structure some of my code. Firstly, I had to add more instructions, so more functions:

1.Get the input string  
2. Check if it’s empty  
3. Divide the string into two parts using `\n`  
4. Extract the delimiter from the first part — **this made a domino effect**
5. Apply the delimiter to the second part  
6. Convert the resulting array into integers  
7. Sum the numbers 


So, in step 4, I had to check if the delimiter was empty and return 0 if it wasn't valid. Until task 3, I had thought of my code as a pipeline; the output of one function goes to the next, and so on. The problem is that if I start checking the edge cases inside my pipeline functions, I have to return two types of values: the intended and the exception (Until now is just 0). It will not stop the code but will transfer that return value of 0 to the next function, causing many errors and a headache. So I decided to handle all the edge cases inside my "main" function `SumStringNums`.

## Some more edge cases
Another thing I realized from the analysis of **Step 4** is that until now, I have only been partially checking the format of my input string. Since it is a pipeline, I actually need to be 100% sure it has the correct format. Any value that differs can explode the flow of data, so what goes in has to be exactly what is expected so nothing goes wrong. So I added more checks:

1. See if the input string has the newline separator \n.
2. See if the part that has the delimiter has the slashes //. This is because if I do not check that is has `//` then something like `"    "` would pass the next edge case.
3. See if the delimiter part has more than two characters. If it is only //, then there are two characters, and thus no delimiter is defined.
4. See if the numbers part has content; if it has less tah one character 1, it is considered empty.

```
1. "//;1;3;4;" 
2. "   " -> if len > 2 -> True
3. "//" -> if len > 2 -> Flase
4. "//;\n"
```

## Task 5: Custom Delimeters

In contrast to my code in python, on which I check for the negative numbers within the same loop where I sum, here I made a new function `lookForNegatives` where I apply the `findAll` with a lambda function to find all numbers less than 0. Then I use the same logic as my python code, to see if the array is empty or not. If has values, then raise the Exception, if not return the array `nums` intact. For the Exception message I had to convert the array elements into strings and then concatenate them so I could add them into the message.

In last task I mentioned that I was controlling all the edge cases in my "main" function `SumStringNums` since my error notification was returning 0, so that messed up with my data pipeline I had defined. But now I shifted that approach to handle the Exceptions inside each function, so I have everything contained in the things that they relate to. Adding the Exception also help me stop my script from executing further, as explaided I had to make my logic in my final function so the program could finish and return 0 if there was an edge case met. Now with exceptions I can stop the program and return inmediatelly the error anywhere, so it makes sense to just manage the exception inside their respective functions.

### Exceptions that I added
1. I added Expections to `applyDelim`, because if I whant to split a string, then I need that string to not be empty.
2. In `extractDelim` I added a new condition to check if starts with `//` since I was only checking the length and if there is no `//` then it could mess up the extraction of the delimiter, since I'm choosing everything after the second character in the string `[2..]`.
3. In `SumStringNums` insted of returning 0 I change it to rise an exception.

## Task 6: Ignoring Giants

For this task I had to just make a minor adjustment. I modified my `sum` function to filter out the numbers bigger than 1000. Similar to my Python code, it worked the same way as in Task 5, where I handled this logic within the summation loop.

### Some realizations not related to the actual objective of the task
One thing I realized is the use of `Filter` and `FindAll` methods of Array. When I *get all* the negatives I use `FindAll` and when I need to *get rid* of bigger numbers I used `Filter`. At the time I didn't realized that They are pretty similar: 

To find the negatives uding `Filter` is the same condition $x < 0$:
```F#
 Array.filter(fun x-> x < 0)
```

And to get rid of the big numbers, I just have to `FindAll` the smaller numbers:
```F#
 Array.FindAll(nums,fun x-> x < 1000)
```

I decided to replace my earlier usage of `FindAll(nums, fun x-> x < 0)` with `Array.filter(fun x-> x < 0)` to keep consistency and within F#. Since `FindAll` is part of .NET system and not native to F# so the return of the methd gets wrapped for it to be used in F#. If I can stay within F#’s own standard functions, I prefer to do so. There are some exception like my edge conditions where I see inf the string is null or are white spaces `String.IsNullOrWhiteSpace`, which is a method from .net, but I find it reasonable to use it here because it helps readability and it lets me check multiple conditions in one.


## Figuring Out structure and execution of project

All my tasks are currently in .fsx files. From what I understand, .fsx files are primarily intended for testing and small things, while .fs files are meant for production code or projects. So thats why I chose `.fsx` in this case.

Initially, I was testing my code using fsi, and when a task was finished, I would "move it to production" by calling it from `Program.fs`. After completing a few tasks, this approach became tedious, since I had to constantly modify `Program.fs` to run different scripts, which was a pain and many times I forgot to updated it.

I decided to stick with fsi for now because it is much easier. Otherwise, I would need to convert my `.fsx` files to `.fs` and manage them from `Program.fs`. Due to time constraints, I instead added a tests array with some input values, and then mapped through the array, applying SumStringNums to each item and printing the results.


## Task 7: Flexible Delimeters

This task was only centered arround my `extractDelim` function, as the name says, here is where I extract the delimeter.

I made a lot of changes to the function. I made some quality changes to make the code easier to read. Because previosly, I was receiving an array and accessing its elements by index, so I assigned each element with a name, so it’s easier to follow what each one represents.

Next, I corrected a mistake I made in Tasks 6. I had used `if delimiter.Length < 2` to check if the delimiter was empty. But in the case that we have only `//` this condition would pass, even though dere is no delimiter. So, corrected it to be `if delimiter.Length < 3`.

Something that I got reminded of, is that `let` inside `if` statements do not exist outside their block as happens in C# or java because of scopes {}.  had assumed that scopes in F# were mostly function level but no. F# is pretty much Python looks but C# rules. I'm so used to having `{}` define scopes, that I mindlessly tried to handle the as I would do in python and assumed it would work:

```F#
if auxDelimeter.StartsWith("[") && auxDelimeter.EndsWith("]") then
            let finalDelimeter = auxDelimeter.Substring(1, auxDelimeter.Length - 2)
        else
            auxDelimeter
```
Got the error `finalDelimeter` didn’t exist outside this scope. I figured that since `let finalDelimeter` is basically a function, then I define is as the result of the condition and it worked.

```F#
let finalDelimeter = 
        if auxDelimeter.StartsWith("[") && auxDelimeter.EndsWith("]") then
            auxDelimeter.Substring(1, auxDelimeter.Length - 2)
        else
            auxDelimeter
```

My final change was making `extractDelim` return a tuple of strings ,instead of a string array. This so I can treat them separately with their own name. As I do in my python code where I do:

```python
delimeter , nums = string.split('\n')
```

Because of this change, I also modified the input of `applyDelim`(the next function in the pipeline) so that it receives two separate strings instead of the array.