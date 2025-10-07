def sum_string_nums(string:str) -> int:
    if string is None or string.strip() == "":
        return 0

    delimeter , nums = string.split('\n')
    delimeter = delimeter.strip('//') # get the value that is not //
    
    # if empty delimeter
    if not delimeter: 
        return 0
        
    nums = nums.split(delimeter)
        
    sum = 0
    for n in nums:
        sum+=int(n)
               
    return sum 
    

if __name__ == "__main__":
    tests = ["//;\n1;2", "//\n1256", "// \n1 2"]
    for test in tests:
        print(sum_string_nums(test))
