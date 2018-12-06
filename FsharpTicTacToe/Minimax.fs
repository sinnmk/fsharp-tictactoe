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
    if GameWon(board) "X" = true then
        score <- 100 
    else if GameWon(board) "O" = true then
        score <- -100 
    else 
        score <- 0
    score

let SwitchMarker marker= 
    let mutable result = 
        match marker with 
        |"X" -> "O"
        |_ -> "X"
    result

let MakeBestFirstMove(board) = 
    let moves = GetListOfMoves(board)
    let mutable bestMove = 0
    if moves.Count = 9 then
        bestMove <- 1
    else if moves.Count = 8 && (IsAvailablePosition(board) 5 = true) then 
        bestMove <- 5
    else if moves.Count = 8 && (IsAvailablePosition(board) 5 = false) then
        bestMove <- 1
    bestMove

let rec MiniMax (board) index marker= 
    let mutable value = 0
    let mutable board = board
    let mutable moves = GetListOfMoves(board)
    let mutable marker = marker
    let mutable bestValue = 0
    let mutable index = index

    if ((GameWon(board) marker) = true || (moves.Count = 0)) then
        let mutable score = EvaluateScore board 
        bestValue <- score
    else
        if marker = "X" then
            bestValue <- -100
            for move in moves do
                let mutable move = move
                board <- ModifyBoard(board) move marker 
                value <- max(MiniMax(board)(index)("O"))(bestValue) 
                board <- ModifyBoard(board) move " "
            bestValue <- value
        if marker = "O" then
            bestValue <- 100
            for move in moves do
                let mutable move = move
                board <- ModifyBoard(board) move marker 
                value <- min(MiniMax(board)(index)("X"))(bestValue) 
                board <- ModifyBoard(board) move " "
            bestValue <- value
    bestValue

let MakeBestMove(board) marker = 
    let mutable board = board
    let mutable marker = marker
    let mutable value = 0
    let mutable moves = GetListOfMoves board
    let mutable bestMove = 0
    let mutable r = 0

    if moves.Count = 9 || moves.Count = 8 then
        bestMove <- MakeBestFirstMove(board)
    else 
        for move in moves do 
            board <- ModifyBoard(board) move marker
            value <- MiniMax(board) move (SwitchMarker(marker)) 
            board <- ModifyBoard(board) move " "
            if marker = "O" then
                if value = -100 && r = 0 then
                    bestMove <- move 
                if value = 0 then
                    bestMove <- move
        bestMove<-bestMove
    bestMove 
