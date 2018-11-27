module Program

open System
open Board
open ConsoleUi
open Minimax

[<EntryPoint>]

let main args =
    
    GameMenu |> ignore

    let mutable board = InitializeBoard 
    let mutable marker = " " 
    let mutable gameOver = IsBoardTerminal board
    let mutable depth = 0
    let mutable maxPlayer = true
    let mutable turnsPlayed = 0

    let SwitchMaxPlayer maxPlayer = 
        let mutable m = maxPlayer
        if m = true then 
            m <- false 
        else
            m <- true

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
        //let mutable computerMove = DoMiniMax (board) depth maxPlayer marker
        if (IsAvailablePosition (board) computerMove = true) then
            ModifyBoard(board) computerMove marker |> ignore
        else 
            board |> ignore 
        CheckWin()
        SwitchMaxPlayer maxPlayer
        depth <- depth + 1
        turnsPlayed <- turnsPlayed + 1
        PrintBoard board


    while (gameOver = false) do 
        HumanPlayerTurn()
        ComputerPlayerTurn()

    Console.ReadKey() |> ignore
    0 
