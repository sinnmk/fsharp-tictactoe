module Minimax
open Board

let SwitchMaxPlayer maxPlayer = 
    let mutable m = maxPlayer
    if m = "X" then 
        m <- "O" 
    else
        m <- "X" 

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


let rec MaximizeScore (board) depth maxPlayer marker = 
    let mutable moves = GetListOfMoves(board)
    let mutable v = 0 
    let mutable b = board
    let mutable mp = maxPlayer
    let mutable d = depth 
    v <- -100
    for move in moves do
        b <- ModifyBoard b move marker 
        v <- max(v)(MaximizeScore(b) depth maxPlayer marker) 
        mp <- "O" 
        d <- d+1
        b <- ModifyBoard b move " "
    v

let rec MinimizeScore (board) depth maxPlayer marker =
    let mutable moves = GetListOfMoves(board)
    let mutable v = 0 
    let mutable b = board
    let mutable mp = maxPlayer
    let mutable d = depth 

    v <- 100
    for move in moves do
        b <- ModifyBoard b move marker
        v <- min(v)(MinimizeScore(b) depth maxPlayer marker) 
        mp <- "X" 
        d <- d+1
        b <- ModifyBoard b move " "
    v

let MiniMax (board) depth maxPlayer marker = 
    if IsBoardTerminal board = true || IsWin board marker = true then 
        EvaluateScore board |> ignore 
    if maxPlayer = "X" then
        MaximizeScore (board) depth maxPlayer marker
    else 
        MinimizeScore (board) depth maxPlayer marker
