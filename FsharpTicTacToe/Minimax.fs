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

let EvaluateScore (board) depth: int =
    let mutable score = 0
    if GameWon (board) "X" = true then
        score <- 100 - depth
    else if GameWon(board) "O" = true then
        score <- -100 - depth
    else 
        score <- 0
    score

let SwitchMarker marker= 
    let mutable result = 
        match marker with 
        |"X" -> "O"
        |"O" -> "X"
        |_ -> "X"
    result

let rec MiniMax (board) depth marker= 
    let mutable scores = ResizeArray<int>() 
    let mutable v = 0
    let mutable board = board
    let mutable moves = GetListOfMoves(board)
    let mutable depth = depth 

    if ((GameWon(board) marker) = true || depth = 0 || (moves.Count = 0)) then
        let mutable score = EvaluateScore board depth
        v <- score
    else
        if marker = "X" then
            let mutable value = -100
            for move in moves do
                board <- ModifyBoard(board) move marker 
                value <- max(value)(MiniMax(board)(depth-1) "O")  
                board <- ModifyBoard(board) move " "
            v <- value
        else
            let mutable value = 100
            for move in moves do 
                board <- ModifyBoard(board) move marker 
                value <- min(value)(MiniMax(board)(depth-1) "X")  
                board <- ModifyBoard(board) move " "
            v <- value
    v

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

//let MakeBestMove(board) depth marker = 
//    let mutable board = board
//    let mutable depth = depth
//    let mutable marker = marker
//    let mutable value = 0
//    let mutable moves = GetListOfMoves board
//    let mutable potentialMoves = ResizeArray<int>()
//    let mutable bestMove = 0
//    let mutable r = 0

//    if moves.Count = 9 || moves.Count = 8 then
//        bestMove <- MakeBestFirstMove(board)
//    else 
//        for move in moves do 
//            board <- ModifyBoard (board) move marker 
//            value <- MiniMax(board) depth marker
//            board <- ModifyBoard (board) move " "
//            if value = -100 && r = 0 then
//                bestMove <-move 
//                r <- r+1
//            else if value < 0 then
//                potentialMoves.Add(move)
//            else
//                potentialMoves.Add(move)
//    if bestMove > 0 then
//        bestMove <- bestMove  
//    else if potentialMoves.Count > 0 then
//        bestMove <- potentialMoves.[0]
//    bestMove 



          






                

        

    

