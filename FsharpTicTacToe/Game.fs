module Game

open System
open Board
open ConsoleUi
open Minimax

let mutable board = InitializeBoard  
let mutable marker = " " 

let CheckForWin () = 
    if(GameWon (board) marker = true) then  
        PrintBoard board
        WinPrompt ()
        ExitGame ()

let GetHumanMove () = 
    let mutable humanMove = Console.ReadLine() |> int
    humanMove

let GenerateRandomMove (board) = 
    let rnd = System.Random()
    let moves = GetListOfMoves board
    let mutable computerMove = moves.[rnd.Next(moves.Count)]
    computerMove

let HumanPlayerTurn() = 
    MovePrompt ()
    marker <- "X"
    let mutable humanMove = GetHumanMove() 
    if (IsAvailablePosition (board) humanMove = true) then
        ModifyBoard (board) humanMove marker|> ignore
    else 
        invalidMovePrompt ()
        humanMove <- Console.ReadLine() |> int
    CheckForWin()
    PrintBoard board

let ComputerPlayerTurn() =  
    MovePrompt ()
    marker <- "O" 
    let mutable computerMove = MiniMax(board) marker 
    if (IsAvailablePosition (board) computerMove = true) then
        ModifyBoard(board) computerMove marker |> ignore
    else 
        board |> ignore 
    CheckForWin()
    PrintBoard board
