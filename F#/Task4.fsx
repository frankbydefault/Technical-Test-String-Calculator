open System

module Task4 = 
    let sum (nums: int array) : int = 
        Array.sum nums

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
                |> sum

let tests = [| "//;\n2;3"; "//\n" ; "\n123"|]

Array.map (fun value ->
    let result = Task4.SumStringNums value
    printfn "%d" result
) tests