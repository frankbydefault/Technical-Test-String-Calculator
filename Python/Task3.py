def sum_string_nums(string:str) -> int:
    if string is None or string.strip() == "":
        return 0

    string = string.replace('\n', ',')
    nums = string.split(',')
    
    sum = 0
    for n in nums:
        sum+=int(n)
               
    return sum 
    

if __name__ == "__main__":
    tests = ["1\n2,3,4,5\n6,7", None, "", "   ","10\n400,70\n4\n-20"]
    for test in tests:
        print(sum_string_nums(test))
