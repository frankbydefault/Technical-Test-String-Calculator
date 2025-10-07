open System

module Task1 = 
    let sum (nums: int array) : int = 
        Array.sum nums

    let stringToInt (nums: string array) : int array = 
        nums |> Array.map int

    let splitString (str: string) : string array = 
        let separators = [| ','; '\n' |]
        str.Split(separators)
        |> Array.filter (fun i-> not (i.Trim() = "")) // Filter out all values that are empty

    let SumStringNums (str: string) : int =
        if str = null || str = "" then
            0 
        else
            str 
            |> splitString 
            |> stringToInt 
            |> sum


Task1.SumStringNums "1, ,2\n3"  