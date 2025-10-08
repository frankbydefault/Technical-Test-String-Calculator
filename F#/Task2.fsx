open System

module Task2 = 
    let sum (nums: int array) : int = 
        Array.sum nums

    let stringToInt (nums: string array) : int array = 
        nums |> Array.map int

    let splitString (str: string) : string array = 
        str.Split(',')
    
    let SumStringNums (str: string) : int =
        if String.IsNullOrWhiteSpace(str) then
            0 
        else
            str 
            |> splitString 
            |> stringToInt 
            |> sum

let tests = [| "1,2,3"; "80,4,5"|]

Array.map (fun value ->
    let result = Task2.SumStringNums value
    printfn "%d" result
) tests