
module Task1 = 
    let sum (nums: int array) : int = 
        Array.sum nums

    let stringToInt (nums: string array) : int array = 
        nums |> Array.map int

    let splitString (str: string) : string array = 
        str.Split(',')

    let SumStringNums (str: string) : int =
        if str = null || str = "" then
            0 
        else
            str 
            |> splitString 
            |> stringToInt 
            |> sum