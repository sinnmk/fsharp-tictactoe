module Minimax
open System
open Board

let GetListOfMoves (board: array<string>) =
    let mutable listOfMoves = ResizeArray<int>() 
    for i=0 to 8 do
        if board.[i] = " " then
            listOfMoves.Add (i+1) 
        else 
            listOfMoves |> ignore
    listOfMoves

let ShuffleNumber (num: Random) xs = xs |> Seq.sortBy (fun _ -> num.Next())

let GetComputerMove: int = 
    let mutable move = [1..9] |> ShuffleNumber (Random ()) |> Seq.head
    move 

let EvaluateScore (board): int =
    let mutable score = 0
    if CheckForWin(board) "X" then 
        score <- -100
    else if CheckForWin(board) "O" then  
        score <- 100
    score

let rec MinMax (board) maxPlayer marker : int =
    let mutable moves = GetListOfMoves(board)
    let mutable v = 0 
    let mutable b = board

    if IsBoardTerminal board = true || CheckForWin board marker = true then 
        EvaluateScore board 
    else
        if maxPlayer = "X" then
            v <- -100
            for move in moves do
                b <- ModifyBoard board move marker
                v <- max(v)(MinMax(b) maxPlayer marker) 
                b <- ModifyBoard board move " "

        if maxPlayer = "O" then 
            v <- 100
            for move in moves do
                b <- ModifyBoard b move marker
                v <- min(v)(MinMax(b) maxPlayer marker) 
                b <- ModifyBoard board move " "
        v

let BestMove (board) maxPlayer marker : int =
    let mutable maxP = maxPlayer
    let mutable moves = GetListOfMoves(board)
    let mutable bestMove = 0
    let mutable b = board
    let mutable v = 0
    if moves.Count = 9 then
        bestMove <- 1
    else  
        if maxPlayer = "X" then
            for move in moves do
                b <- ModifyBoard b move "X" 
                v <- max(v)(MinMax(b) maxP marker) 
                b <- ModifyBoard b move " " 
                if v = 100 then 
                    bestMove <- move
            bestMove <- bestMove

        else if maxPlayer = "O" then
            for move in moves do
                b <- ModifyBoard b move "O" 
                v <- min(v)(MinMax(b) maxP marker) 
                b <- ModifyBoard b move " " 
                if v = -100 then 
                    bestMove <- move
            bestMove <- bestMove
    bestMove
