module Board

type Board() = 

    static member createBoard =
        let board = [|" ";" ";" ";" ";" ";" ";" ";" ";" "|]
        board

    static member printBoard board = 
        let join s arr = sprintf "%s%s%s" s (String.concat s arr) s
        board 
        |> Seq.chunkBySize 3
        |> Seq.map (Seq.map (sprintf " %s ") >> join "|")
        |> Seq.map (fun s -> s + "\n")
        |> join ".===.===.===.\n"
        |> printfn "%s"

    static member modifyBoard (board: string array, move: int, marker: string): array<string> = 
        board.[move-1] <- marker 
        board

    static member isAvailablePosition (move: int, board: array<string>): bool= 
        match board.[move-1] with
        |" " -> true
        |"X" -> false 
        |"O" -> false

    static member checkForWin (board: array<string>, marker: string): bool =
        let winCombos = [|(0, 1, 2); (3, 4, 5); (6, 7, 8); (0, 3, 6); (1, 4, 7); (2, 5, 8); (0, 4, 8); (2, 4, 6) |]
        true
