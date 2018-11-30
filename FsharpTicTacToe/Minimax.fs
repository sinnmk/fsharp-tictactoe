module Minimax
open Board

let GetListOfMoves (board: array<string>) =
    let listOfMoves = ResizeArray<int>() 
    for i=0 to 8 do
        if board.[i] = " " then
            listOfMoves.Add (i+1) 
        else 
            listOfMoves |> ignore
    listOfMoves  

let EvaluateScore (board): int =
    let mutable score = 0
    if GameWon(board) "X" then 
        score <- 100
    else if GameWon(board) "O" then  
        score <- -100
    else 
        score <- 0 
    score

let SwitchMarker marker= 
    let mutable marker = marker
    if marker = "X" then
        marker <- "O"
    else if marker = "O" then 
        marker <- "X"
    marker

let rec MiniMax (board) depth marker= 
    let mutable v = 0
    let mutable board = board
    let mutable moves = GetListOfMoves(board)

    if ((GameWon(board) marker) = true || depth = 0 || (moves.Count = 0)) then
        let mutable score = EvaluateScore board
        v <- score
    else
        if marker = "X" then
            let mutable value = -100
            for move in moves do
                board <- ModifyBoard(board) move marker 
                value <- max(value)(MiniMax(board) (depth-1) "O")  
                board <- ModifyBoard(board) move " "
            v <- value
        else if marker = "O" then
            let mutable value = 100
            for move in moves do 
                board <- ModifyBoard(board) move marker 
                value <- min(value)(MiniMax(board) (depth-1) "X")  
                board <- ModifyBoard(board) move " "
            v <- value
        v <- v
    v

let MakeBestMove(board) depth marker = 
    let mutable board = board
    let mutable depth = depth
    let mutable marker = marker
    let mutable value = 0
    let mutable moves = GetListOfMoves board
    let mutable potentialMoves = ResizeArray<int>()
    let mutable bestMove = 0
    let mutable r = 0

    if moves.Count = 9 then
        bestMove <- 1
    else if moves.Count = 8 && (IsAvailablePosition(board) 5 = true) then
        bestMove <- 5
    else if moves.Count = 8 && (IsAvailablePosition(board) 5 = false) then
        bestMove <- 1
    else
        for move in moves do 
            board <- ModifyBoard (board) move marker 
            value <- MiniMax(board) depth marker
            board <- ModifyBoard (board) move " "
            if marker = "X" && (r=0) then
                if value = 100 then
                    bestMove <- move
                    r <-1
                else if value > 0 then
                    potentialMoves.Add(move)
                else 
                    potentialMoves.Add(move)
            if marker = "O" && (r=0) then
                if value = -100 then
                    bestMove <-move 
                    r <-1
                else if value < 0 then
                    potentialMoves.Add(move)
                else
                    potentialMoves.Add(move)
        if bestMove > 0 then
            bestMove <- bestMove  
        else if potentialMoves.Count > 0 then
            bestMove <- potentialMoves.[0]
    bestMove 



          






                

        

    

