module Minimax
open Board
open System

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

let EvaluateScore (board) =
    let mutable score = 0
    if CheckForWin(board) "X" then 
        score <- -100
    else if CheckForWin(board) "O" then  
        score <- 100
    else
        score <- score
    score

let rec MinMax (board) maxPlayer marker = 
    let mutable moves = GetListOfMoves (board)
    let mutable value = 0

    if (IsBoardTerminal (board) = true || CheckForWin (board) marker = true) then 
        EvaluateScore (board) 
    else 
        if maxPlayer = "X" then 
            value <- -100
            for move in moves do 
                ModifyBoard (board) move "X" |> ignore 
                value <- max(value)(MinMax(board) maxPlayer marker)
                ModifyBoard (board) move " " |> ignore 
            value

        else
            value <- 100
            for move in moves do 
                ModifyBoard(board) move "O" |> ignore 
                value <- min(value)(MinMax(board) maxPlayer marker)
                ModifyBoard (board) move " " |> ignore 
            value

let BestMove (board) maxPlayer marker: int = 
    let mutable value = 0
    let mutable choice = 0 
    let mutable moves = GetListOfMoves(board)
    if maxPlayer = "X" then
        for move in moves do 
            ModifyBoard (board) move "X" |> ignore
            value <- max(value)(MinMax(board) maxPlayer marker)
            ModifyBoard (board) move " " |> ignore
            if value > -100 then 
                choice <- move
            else choice <- choice
        choice |> int
    else 
        for move in moves do
            ModifyBoard (board) move "O" |> ignore
            value <- min(value)(MinMax(board) maxPlayer marker)
            ModifyBoard (board) move " " |> ignore
            if value > 100 then 
                choice <- move
            else choice <- choice
        choice |> int

