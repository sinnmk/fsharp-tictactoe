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

let rec GetHumanMove() = 
    let mutable humanMove = Console.ReadLine() 
    humanMove |> int 

let GenerateRandomMove (board) = 
    let moves = GetListOfMoves(board)
    let mutable computerMove = moves.[System.Random().Next(moves.Count)]
    computerMove

let HumanPlayerTurn() = 
    MovePrompt ()
    marker <- "X"
    let mutable humanMove = GetHumanMove() 
    if (IsAvailablePosition (board) humanMove = true) then
        ModifyBoard (board) humanMove marker
    else 
        invalidMovePrompt ()
        humanMove <- Console.ReadLine() |> int
    CheckForWin()
    PrintBoard board

let ComputerPlayerTurn() =  
    MovePrompt ()
    marker <- "O" 
    let mutable computerMove = GenerateRandomMove (board)
    if (IsAvailablePosition (board) computerMove = true) then
        ModifyBoard(board) computerMove marker
    CheckForWin()
    PrintBoard board
