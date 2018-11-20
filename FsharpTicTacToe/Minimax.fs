module Minimax
open Board
open System

let getListOfMoves (board: array<string>) =
    let mutable listOfMoves = ResizeArray<int>() 
    for i=0 to 8 do
        if board.[i] = " " then
            listOfMoves.Add (i+1) 
        else 
            listOfMoves |> ignore
    listOfMoves


let shuffleNumber (num: Random) xs = xs |> Seq.sortBy (fun _ -> num.Next())

let getComputerMove: int = 
    let mutable move = [1..9] |> shuffleNumber (Random ()) |> Seq.head
    move

let bestMove: int = 
    1

let evaluateScore (board) =
    let mutable score = 0
    if checkForWin(board) "X" then 
        score <- -100
    else if checkForWin(board) "O" then  
        score <- 100
    else
        score <- score
    score

let rec minimax (board) depth maxPlayer marker = 
    let mutable moves = getListOfMoves (board)
    let mutable value = 0

    if (isBoardTerminal (board) = true || checkForWin (board) marker = true) then 
        evaluateScore (board) 
    else 
        if maxPlayer = "X" then 
            value <- -100
            for move in moves do 
                modifyBoard (board) move "X" |> ignore 
                value <- max(value)(minimax(board) depth maxPlayer marker)
                modifyBoard (board) move " " |> ignore 
            value

        else
            value <- 100
            for move in moves do 
                modifyBoard(board) move "O" |> ignore 
                value <- min(value)(minimax(board) depth maxPlayer marker)
                modifyBoard (board) move " " |> ignore 
            value
