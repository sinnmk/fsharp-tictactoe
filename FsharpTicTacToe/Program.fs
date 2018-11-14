open System
open Game
open Board

[<EntryPoint>]
let main argv =
    Game.runMenu
    let board = Board.createBoard
    let i = 0
    while (i < 9) do
        Game.takeHumanTurn board
        Game.takeComputerTurn board
        i + 1
    Console.ReadKey() |> ignore
    0 
