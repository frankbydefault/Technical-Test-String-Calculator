open System

module Task5 = 
    let sum (nums: int array) : int = 
        Array.sum nums

    let hasNegatives(nums:int array): int array=
        let negatives = Array.FindAll(nums, fun x-> x < 0)
        
        if not (Array.isEmpty negatives) then
            let concatNegatives = negatives |> Array.map string |> String.concat ", "
            raise (System.Exception($"Exception: negatives not allowed {concatNegatives}"))
        
        nums

    let stringToInt (nums: string array) : int array = 
        nums |> Array.map int

    let extractDelim (str: string array): string array =
        str.[0] <- str.[0].[2..]
        str

    let applyDelim (parts: string array): string array =
        parts[1].Split parts[0]
        |> Array.filter (fun i-> not (i.Trim() = ""))

    let SumStringNums (str: string) : int =
        if String.IsNullOrWhiteSpace str || not(str.Contains "\n") then
            0
        else
            let parts = str.Split "\n"

            if parts.[0].Length < 2 || parts[1].Length < 1 then // to see if the delimeter part is empty or only composed by //
                0
            else
                parts
                |> extractDelim 
                |> applyDelim
                |> stringToInt
                |> hasNegatives 
                |> sum

Task5.SumStringNums "//;\n1;-2;-3;-7"