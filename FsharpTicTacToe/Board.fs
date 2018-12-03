module Board

let InitializeBoard = 
    let mutable board = [|" "; " "; " "; " "; " "; " "; " "; " "; " "|]
    board

let ModifyBoard (board: array<string>) move marker = 
     board.[move-1] <- marker 

let IsAvailablePosition (board: array<string>) (move) : bool = 
    match board.[move-1] with
    |" " -> true
    |"X" -> false 
    |"O" -> false
    |_ -> false

let IsBoardTerminal (board: array<string>)= 
    let mutable count = 0
    for i = 0 to 8 do
        if board.[i] = " " then  
            count <- count 
        else 
            count <- count + 1 
    if count = board.Length then
        true
    else 
        false

let GameWon (board: array<string>)  (marker: string): bool=
    let mutable board = board
    let mutable result = 
        match board with 
        |[|a; b; c; _; _; _; _; _; _|] when a = marker && b = marker && c = marker-> true
        |[|_; _; _; a; b; c; _; _; _|] when a = marker && b = marker && c = marker-> true
        |[|_; _; _; _; _; _; a; b; c|] when a = marker && b = marker && c = marker-> true
        |[|a; _; _; b; _; _; c; _; _|] when a = marker && b = marker && c = marker-> true
        |[|_; a; _; _; b; _; _; c; _|] when a = marker && b = marker && c = marker-> true
        |[|_; _; a; _; _; b; _; _; c|] when a = marker && b = marker && c = marker-> true
        |[|a; _; _; _; b; _; _; _; c|] when a = marker && b = marker && c = marker-> true
        |[|_; _; a; _; b; _; c; _; _|] when a = marker && b = marker && c = marker-> true
        |_ -> false
    result