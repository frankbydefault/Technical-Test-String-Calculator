def sum_string_nums(string:str) -> int:
    if string is None or string.strip() == "":
        return 0
    
    nums = string.split(',')
    
    sum = 0
    for n in nums:
        sum+=int(n)
               
    return sum 
    
if __name__ == "__main__":
    
    tests = ["1,2,3,4,5,6,7", None, "", "   ", "10,400,70,4,-20"]
    for test in tests:
        print(sum_string_nums(test))
