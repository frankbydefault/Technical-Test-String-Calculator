open System

module Task7 = 
    let sum (nums: int array) : int = 
        nums |> Array.filter(fun x-> x <= 1000) |> Array.sum

    let lookForNegatives(nums:int array): int array=
        let negatives = Array.filter(fun x-> x < 0) nums
        
        if not (Array.isEmpty negatives) then
            let concatNegatives = negatives |> Array.map string |> String.concat ", "
            raise (System.Exception($"Exception: negatives not allowed {concatNegatives}"))
        else
            nums

    let stringToInt (nums: string array) : int array = 
        nums |> Array.map int

    let extractDelim (parts: string array): string * string =
        
        let delimiter = parts[0]
        let nums = parts[1]
        
        if not (delimiter.StartsWith("//")) then
            raise (System.Exception("Incorrect delimiter format, missing //."))
        
        if delimiter.Length < 3 then // if it only has // 
            raise (System.Exception("Incorrect delimiter format, missing //."))

        // we know that delimiter has // we remove it
        let auxDelimeter = delimiter.Substring(2)

        let finalDelimeter = 
            if auxDelimeter.StartsWith("[") && auxDelimeter.EndsWith("]") then
                auxDelimeter.Substring(1, auxDelimeter.Length - 2)
            else
                auxDelimeter

        (finalDelimeter, nums)

    let applyDelim (delimiter: string) (nums: string): string array =
        if String.IsNullOrWhiteSpace nums then
            raise (System.Exception("Number string empty"))
        else
            nums.Split(delimiter, StringSplitOptions.RemoveEmptyEntries) 
            
    let SumStringNums (str: string) : int =
        if String.IsNullOrWhiteSpace str || not(str.Contains "\n") then
            raise (System.Exception("No input defined or does not contain newline separation."))
        else
            let parts = str.Split "\n"

            let (delimiter, nums) = extractDelim parts
            applyDelim delimiter nums
            |> stringToInt
            |> lookForNegatives 
            |> sum

let tests = [| "//[***]\n1***2***3"; "//[;]\n1;2;3";"//[]\n123";"//[--]\n1--2---3"|]

Array.map (fun value ->
    let result = Task7.SumStringNums value
    printfn "%d" result
) tests
