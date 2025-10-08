open System

module Task3 = 
    let sum (nums: int array) : int = 
        Array.sum nums

    let stringToInt (nums: string array) : int array = 
        nums |> Array.map int

    let splitString (str: string) : string array = 
        let separators = [| ','; '\n' |]
        str.Split(separators)
        |> Array.filter (fun i-> not (i.Trim() = "")) // Filter out all values that are empty

    let SumStringNums (str: string) : int =
        if String.IsNullOrWhiteSpace(str) then
            0 
        else
            str 
            |> splitString 
            |> stringToInt 
            |> sum

let tests = [| "1\n2,3"; "80\n4\n5" ; "\n"|]

Array.map (fun value ->
    let result = Task3.SumStringNums value
    printfn "%d" result
) tests