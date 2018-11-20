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

let BestMove (board): int = 
    let mutable value = 0
    let mutable choices = ResizeArray<int>()
    let mutable moves = GetListOfMoves(board)
    1

let EvaluateScore (board) =
    let mutable score = 0
    if CheckForWin(board) "X" then 
        score <- -100
    else if CheckForWin(board) "O" then  
        score <- 100
    else
        score <- score
    score

let rec MinMax (board) depth maxPlayer marker = 
    let mutable moves = GetListOfMoves (board)
    let mutable value = 0

    if (IsBoardTerminal (board) = true || CheckForWin (board) marker = true) then 
        EvaluateScore (board) 
    else 
        if maxPlayer = "X" then 
            value <- -100
            for move in moves do 
                ModifyBoard (board) move "X" |> ignore 
                value <- max(value)(MinMax(board) depth maxPlayer marker)
                ModifyBoard (board) move " " |> ignore 
            value

        else
            value <- 100
            for move in moves do 
                ModifyBoard(board) move "O" |> ignore 
                value <- min(value)(MinMax(board) depth maxPlayer marker)
                ModifyBoard (board) move " " |> ignore 
            value
