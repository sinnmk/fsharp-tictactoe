module Program

open System
open Board
open ConsoleUi
open Game
open Minimax

[<EntryPoint>]

let main args =
    GameMenu |> ignore
    let mutable gameOver = IsBoardTerminal board
    let mutable turnsPlayed = 0
    while (gameOver = false) do 
        HumanPlayerTurn()
        turnsPlayed <- turnsPlayed + 1
        if turnsPlayed <= 8 then
            ComputerPlayerTurn()
            turnsPlayed <- turnsPlayed + 1
        else 
            DrawGamePrompt()            
            ExitGame()
    Console.ReadKey() |> ignore
    0 
