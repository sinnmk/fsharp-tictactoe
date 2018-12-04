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
    if GameWon (board) "X" = true then
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
        |"O" -> "X"
        |_ -> "X"
    result

