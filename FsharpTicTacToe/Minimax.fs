module Minimax
open Board
open ConsoleUi

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
    if ((GameWon(board) marker) = true || depth = 0 || (GetListOfMoves(board).Count = 0)) then
        let mutable score = EvaluateScore board
        v <- score
    else

        if marker = "X" then
            let mutable value = -100
            let mutable moves = GetListOfMoves board
            let mutable board = board
            for move in moves do
                board <- ModifyBoard(board) move marker 
                value <- max(value)(MiniMax(board) depth "O")  
                board <- ModifyBoard(board) move " "
            v <- value

        else
            let mutable value = 100
            let mutable board = board
            let mutable moves = GetListOfMoves board
            for move in moves do 
                board <- ModifyBoard(board) move marker 
                value <- min(value)(MiniMax(board) depth "X")  
                board <- ModifyBoard(board) move " "
            v <- value
        v <- v
    v

let MakeBestMove(board) depth marker = 
    let mutable board = board
    let mutable depth = depth
    let mutable marker = marker
    let mutable moves = GetListOfMoves board
    let mutable bestMove = 0
    let mutable potentialMoves = ResizeArray<int>()
    let mutable value = 0
    let mutable m = 0

    for move in moves do 
        board <- ModifyBoard (board) move marker 
        value <- MiniMax(board) depth marker
        board <- ModifyBoard (board) move " "

        if marker = "X" then
            if value = 100 then
                bestMove <-move 
            else if value > 0 then
                potentialMoves.Add(move) 
        else if marker = "O" then
            if value = -100 then
                bestMove <-move 
            else if value > -100 then
                potentialMoves.Add(move)
        if bestMove > 0 then
            m <- bestMove  
        else if potentialMoves.Count > 0 then
            m <- potentialMoves.[0]
    m



          






                

        

    

