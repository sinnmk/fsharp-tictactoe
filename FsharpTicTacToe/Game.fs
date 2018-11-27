module Game

open System
open Board
open ConsoleUi
open Minimax

    let mutable board = InitializeBoard 
    let mutable marker = " " 
    let mutable gameOver = IsBoardTerminal board
    let mutable depth = 0
    let mutable maxPlayer = "X" 
    let mutable turnsPlayed = 0

    let CheckWin () = 
        if(IsWin (board) marker = true) then  
            PrintBoard board
            WinPrompt ()
            ExitGame ()

    let HumanPlayerTurn() = 
        MovePrompt ()
        marker <- "X"
        let mutable humanMove = Console.ReadLine() |> int 
        if (IsAvailablePosition (board) humanMove = true) then
            ModifyBoard (board) humanMove marker|> ignore
        else 
            invalidMovePrompt ()
            humanMove <- Console.ReadLine() |> int
        CheckWin()
        //need to figure out how to bind who is max player to the player itself, otherwise it always remains true
        SwitchMaxPlayer maxPlayer
        depth <- depth + 1
        turnsPlayed <- turnsPlayed + 1
        PrintBoard board

    let ComputerPlayerTurn() =  
        MovePrompt ()
        marker <- "O" 
        let rnd = System.Random()
        let moves = GetListOfMoves board
        let mutable computerMove = moves.[rnd.Next(moves.Count)]
        //let mutable computerMove = BestMove
        if (IsAvailablePosition (board) computerMove = true) then
            ModifyBoard(board) computerMove marker |> ignore
        else 
            board |> ignore 
        CheckWin()
        //need to figure out how to bind who is max player to the player itself, otherwise it always remains true
        SwitchMaxPlayer maxPlayer
        depth <- depth + 1
        turnsPlayed <- turnsPlayed + 1
        PrintBoard board

