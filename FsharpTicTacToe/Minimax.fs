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
    if IsWin(board) "X" then 
        score <- -100
    else if IsWin(board) "O" then  
        score <- 100
    score

let rec DoMiniMax (board) depth maxPlayer marker =
    let mutable moves = GetListOfMoves(board)
    let mutable v = 0 
    let mutable b = board
    let mutable mp = maxPlayer
    let mutable d = depth 

    if IsBoardTerminal board = true || IsWin board marker = true then 
        EvaluateScore board |> ignore 

    if (maxPlayer = true) then
        v <- -100
        for move in moves do
            b <- ModifyBoard b move marker 
            v <- max(v)(DoMiniMax(b) depth maxPlayer marker) 
            mp <- false
            d <- d+1
            b <- ModifyBoard b move " "

    else 
        v <- 100
        for move in moves do
            b <- ModifyBoard b move marker
            v <- min(v)(DoMiniMax(b) depth maxPlayer marker) 
            mp <- true 
            d <- d+1
            b <- ModifyBoard b move " "
    v

let rec BestMove (board) depth maxPlayer marker: int = 
    let mutable m = 0
    let mutable v = DoMiniMax (board) depth maxPlayer marker
    if v > -100 && maxPlayer then
        m <- 1 
    m
            
