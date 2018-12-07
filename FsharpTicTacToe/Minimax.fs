module Minimax
open Board

let GetListOfMoves (board:array<string>) =
    let listOfMoves = ResizeArray<int>() 
    for i=0 to 8 do
        if board.[i] = " " then
            listOfMoves.Add (i+1) 
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

let rec MiniMax(board) marker = 
    let mutable bestValue = 0
    let mutable board = board
    let mutable moves = GetListOfMoves(board) 
    if GameWon(board) marker = true || GetListOfMoves(board).Count = 0 then
        bestValue <- EvaluateScore(board)
    else
        if marker = "X" then
            bestValue <- -100
            for move in moves do  
                board <- ModifyBoard(board) move marker
                bestValue <- max(MiniMax(board) "O")(bestValue) 
                board <- ModifyBoard(board) move " "
            bestValue <- bestValue
        else if marker = "O" then 
            bestValue <- 100
            for move in moves do  
                board <- ModifyBoard(board) move marker
                bestValue <- min(MiniMax(board) "X")(bestValue) 
                board <- ModifyBoard(board) move " "
            bestValue <- bestValue
    bestValue

let MakeBestMove (board) marker = 
    let mutable board = board
    let mutable bestMove = 0
    let mutable bestValue = 0
    let mutable bestMoves = ResizeArray<int>()
    let moves = GetListOfMoves(board)
    for move in moves do
        board <- ModifyBoard(board) move marker
        bestValue <- MiniMax(board) "X" 
        board <- ModifyBoard(board) move " "
        if marker = "X" then
            if bestValue = 100 then
                bestMove <- move
            if bestValue > 0 then
                bestMoves.Add(move)
            else if bestValue = 0 then
                bestMoves.Add(move)
        elif marker = "O" then
            if bestValue = -100 then
                bestMove <- move
            if bestValue < 0 then
                bestMoves.Add(move)
            else if bestValue = 0 then
                bestMoves.Add(move)
    if bestMove = 0 && bestMoves.Count > 0 then
        bestMove <- bestMoves.[0]
    elif bestMove <> 0 then
        bestMove <- bestMove
    else
        bestMove <- GetListOfMoves(board).[0]
    bestMove     

//let rec MiniMax (board) marker= 
//    let mutable value = 0
//    let mutable board = board
//    let mutable moves = GetListOfMoves(board)
//    let mutable marker = marker
//    let mutable bestValue = 0

//    if ((GameWon(board) marker) = true || (moves.Count = 0)) then
//        let mutable score = EvaluateScore board 
//        bestValue <- score
//    else
//        if marker = "X" then
//            bestValue <- -100
//            for move in moves do
//                let mutable move = move
//                board <- ModifyBoard(board) move marker 
//                value <- MiniMax(board)("O") 
//                bestValue <- max(value)(bestValue)
//                board <- ModifyBoard(board) move " "

//        else
//            bestValue <- 100
//            for move in moves do
//                let mutable move = move
//                board <- ModifyBoard(board) move marker 
//                value <- MiniMax(board)("X") 
//                bestValue <- min(value)(bestValue)
//                board <- ModifyBoard(board) move " "
//    bestValue

//let MakeBestMove (board) = 
//    let mutable board = board
//    let mutable bestMove = 0
//    let mutable listOfMoves = GetListOfMoves(board)
//    if listOfMoves.Count = 9 || listOfMoves.Count = 8 then
//        bestMove <- MakeBestFirstMove(board)
//    else
//        for move in listOfMoves do
//            board <- ModifyBoard(board) move "O" 
//            let mutable value = MiniMax(board) "X"
//            board<-ModifyBoard(board) move " "
//            if value = -100 then
//                bestMove <- move 
//    bestMove
