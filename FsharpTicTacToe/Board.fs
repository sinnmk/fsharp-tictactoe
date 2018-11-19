module Board

open System

    let initializeBoard = 
        let mutable board = [|" "; " "; " "; " "; " "; " "; " "; " "; " "|]
        board

    let shuffleNumber (num: Random) xs = xs |> Seq.sortBy (fun _ -> num.Next())

    let getComputerMove: int = 
        let mutable move = [1..9] |> shuffleNumber (Random ()) |> Seq.head
        move

    let modifyBoard (board: array<string>) move marker: array<string> = 
        let mutable board = board 
        board.[move-1] <- marker 
        board

    let isAvailablePosition (board: array<string>)move: bool= 
        let mutable b = board
        match b.[move-1] with
        |null -> true  
        |" " -> true
        |"X" -> false 
        |"O" -> false

    let isBoardTerminal (board: array<string>)= 
        let mutable boardToCheck = board
        let mutable i = 0
        let mutable count = 0
        for i = 0 to 8 do
            if boardToCheck.[i] = " " then  
                count <- count 
            else 
                count <- count + 1 
        i <- i + 1
        if count = board.Length then
            true
        else false

    let checkForWin (board: array<string>)  (marker: string): bool=
        let mutable result = false

        if board.[0] = marker && board.[1] = marker && board.[2] = marker then
            result <- true
            result
        else if board.[3] = marker && board.[4] = marker && board.[5] = marker then
            result <- true
            result
        else if board.[6] = marker && board.[7] = marker && board.[8] = marker then
            result <- true
            result
        else if board.[0] = marker && board.[3] = marker && board.[6] = marker then
            result <- true
            result
        else if board.[1] = marker && board.[4] = marker && board.[7] = marker then
            result <- true
            result
        else if board.[2] = marker && board.[5] = marker && board.[8] = marker then
            result <- true
            result
        else if board.[0] = marker && board.[4] = marker && board.[8] = marker then
            result <- true
            result
        else if board.[2] = marker && board.[4] = marker && board.[6] = marker then
            result <- true
            result
        else
            result

    let printBoard board  = 
        let mutable b = board
        let join s arr = sprintf "%s%s%s" s (String.concat s arr) s
        b 
        |> Seq.chunkBySize 3
        |> Seq.map (Seq.map (sprintf " %s ") >> join "|")
        |> Seq.map (fun s -> s + "\n")
        |> join "+===+===+===+\n"
        |> printfn "%s"
