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
    while (gameOver = false) do 
        HumanPlayerTurn()
        if turnsPlayed <= 8 then
            ComputerPlayerTurn()
        else 
            DrawGamePrompt()            
            ExitGame()
    Console.ReadKey() |> ignore
    0 
