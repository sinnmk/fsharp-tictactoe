module Board

    type Board() =
        let mutable boardState = [|" ";" ";" ";" ";" ";" ";" ";" ";" "|] 
        member x.BoardState
            with get() = boardState
            and set(b) = boardState <- b

    type Marker() = 
        let mutable marker = null
        member x.Marker
            with get() = marker 
            and set(mark) = marker <- mark

    type Move() = 
        let mutable move = null
        member x.Move
            with get() = move
            and set(m) = move <- m

    let createBoard =
        let state = Board()
        let board = state.BoardState 
        board

    let printBoard board = 
        let join s arr = sprintf "%s%s%s" s (String.concat s arr) s
        board 
        |> Seq.chunkBySize 3
        |> Seq.map (Seq.map (sprintf " %s ") >> join "|")
        |> Seq.map (fun s -> s + "\n")
        |> join ".===.===.===.\n"
        |> printfn "%s"

    let modifyBoard move marker = 
        let board = Board().BoardState
        board.[move-1] <- marker 
        board

    let isAvailablePosition move: bool= 
        let board = Board().BoardState
        match board.[move-1] with
        |" " -> true
        |"X" -> false 
        |"O" -> false

    let isBoardTerminal = 
        let state = Board()
        let boardToCheck = state.BoardState
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

    let checkForWin (marker: string): bool =
        let winCombos = [|(0, 1, 2); (3, 4, 5); (6, 7, 8); (0, 3, 6); (1, 4, 7); (2, 5, 8); (0, 4, 8); (2, 4, 6) |]
        true
