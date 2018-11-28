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
        score <- -100
    else if GameWon(board) "O" then  
        score <- 100
    else 
        score <- 0 
    score

let SwitchMarker marker= 
    let mutable m = marker
    if m = "X" then
        m <- "O"
    else if m = "O" then 
        m <- "X"
    m

let rec MiniMax (board) depth marker = 
    let mutable board = board
    let mutable depth = depth  
    let mutable marker = marker
    let mutable value = 0

    if ((GameWon (board) marker) = true) || (GetListOfMoves(board).Count = 0) then 
        value <- EvaluateScore board  

    if marker = "X" then
        let mutable bestValue = -100
        for move in GetListOfMoves(board) do
            board <- ModifyBoard board move marker 
            value <- MiniMax(board) depth (SwitchMarker(marker)) 
            bestValue <- max(value)(bestValue)
            board <- ModifyBoard board move " "
        bestValue
    else 
        let mutable bestValue = 100
        for move in GetListOfMoves(board) do
            board <- ModifyBoard board move marker
            value <- MiniMax(board) depth (SwitchMarker(marker)) 
            bestValue <- min(value)(bestValue)
            board <- ModifyBoard board move " "
        bestValue

let rec MakeBestMove (board) depth marker = 
    let mutable board = board
    let mutable depth = depth  
    let mutable marker = marker
    let mutable value = 0
    let mutable bestMove = 0
    
    for move in GetListOfMoves(board) do
        board <- ModifyBoard board move marker
        value <- MiniMax(board) depth (SwitchMarker(marker))
        if value = 100 then
            bestMove <- move 
    bestMove
