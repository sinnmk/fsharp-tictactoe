module Program

open System
[<EntryPoint>]

let main args =
    Game.runMenu
    ConsoleUi.getMoveChoice |> ignore
    let board = Board.createBoard
    board |> ignore
    Console.ReadKey() |> ignore
    0 
