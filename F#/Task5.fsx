open System

module Task5 = 
    let sum (nums: int array) : int = 
        Array.sum nums

    let lookForNegatives(nums:int array): int array=
        let negatives = Array.FindAll(nums, fun x-> x < 0)
        
        if not (Array.isEmpty negatives) then
            let concatNegatives = negatives |> Array.map string |> String.concat ", "
            raise (System.Exception($"Exception: negatives not allowed {concatNegatives}"))
        else
            nums

    let stringToInt (nums: string array) : int array = 
        nums |> Array.map int

    let extractDelim (parts: string array): string array =
        if not (parts[0].StartsWith("//")) || parts[0].Length < 3 then // if less tha three then there is onlly //
            raise (System.Exception("Incorrect delimiter format, missing // or no delimeter especified."))
        
        else
        parts.[0] <- parts.[0].[2..]
        parts

    let applyDelim (parts: string array): string array =
        if String.IsNullOrWhiteSpace parts[1] then
            raise (System.Exception("Number string empty"))
        else
            parts[1].Split parts[0]
            |> Array.filter (fun i-> not (i.Trim() = ""))

    let SumStringNums (str: string) : int =
        if String.IsNullOrWhiteSpace str || not(str.Contains "\n") then
            raise (System.Exception("No input defined or does not contain newline separation."))
        else
            let parts = str.Split "\n"

            parts
            |> extractDelim 
            |> applyDelim
            |> stringToInt
            |> lookForNegatives 
            |> sum

let tests = [| "//;\n2;-3"; "//\n" ; "\n123"|]

Array.map (fun value ->
    let result = Task5.SumStringNums value
    printfn "%d" result
) tests
