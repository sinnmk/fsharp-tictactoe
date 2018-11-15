module Board
    type cells = A1 | A2 | A3 | B1 | B2 | B3 | C1 | C2 | C3
    type markers = X | O | Empty

    let createBoard =
        let board = [|" ";" ";" ";" ";" ";" ";" ";" ";" "|]
        board

    let printBoard board = 
        let join s arr = sprintf "%s%s%s" s (String.concat s arr) s
        board 
        |> Seq.chunkBySize 3
        |> Seq.map (Seq.map (sprintf " %s ") >> join "|")
        |> Seq.map (fun s -> s + "\n")
        |> join ".===.===.===.\n"
        |> printfn "%s"

    let modifyBoard (board: array<string>) move marker: array<string> = 
        board.[move-1] <- marker 
        board

    let isAvailablePosition move (board: array<string>): bool= 
        match board.[move-1] with
        |" " -> true
        |"X" -> false 
        |"O" -> false

    let isBoardTerminal (board: array<string>) = 
        let boardToCheck = board
        if boardToCheck.[0] = " " 
            || boardToCheck.[1] = " "              
            || boardToCheck.[2] = " "  
            || boardToCheck.[3] = " "  
            || boardToCheck.[4] = " "  
            || boardToCheck.[5] = " "  
            || boardToCheck.[6] = " "  
            || boardToCheck.[7] = " "  
            || boardToCheck.[8] = " " then  
            false 
        else 
            true 

    let checkForWin (board: array<string>, marker: string): bool =
        let winCombos = [|(0, 1, 2); (3, 4, 5); (6, 7, 8); (0, 3, 6); (1, 4, 7); (2, 5, 8); (0, 4, 8); (2, 4, 6) |]
