def sum_string_nums(string:str) -> int:
    if string is None or string.strip() == "":
        raise Exception(f"Exception: invalid input value, expected non empty String.")
    
    delimeter , nums = string.split('\n')
    delimeter = delimeter.strip('//')
    
    if not delimeter: 
        raise Exception(f"Exception: There is no delimiter defined.")
        
    nums = nums.split(delimeter)

    negative_nums=[]
    sum = 0
    for n in nums:
        n = int(n) 
        if n < 0:
            negative_nums.append(str(n))
        
        elif n <= 1000:
            sum+=n
                
    if negative_nums:
        raise Exception(f"Exception: negatives not allowed {','.join(negative_nums)}")
    else:
        return sum 
    
if __name__ == "__main__":        
    tests = ["//;\n1;2000", "//*\n500*200*-1001"]
    for test in tests:
        print(sum_string_nums(test))