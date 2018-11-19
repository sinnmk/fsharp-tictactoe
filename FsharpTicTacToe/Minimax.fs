module Minimax
open Board

let evaluateScore value: int=
    let mutable v = value
    v |> int

let bestMove = 
    let move = 1
    move

let rec minimax (board) depth maxPlayer marker = 
    let mutable value = 0

    if (isBoardTerminal (board) = true || checkForWin (board) marker = true) then 
        evaluateScore value
    else
        if maxPlayer = "X" then 
            let mutable value = -100
            value
        else
            let mutable value = 100
            value