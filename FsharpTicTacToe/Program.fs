module Program

open System
open Board
open System.Threading

[<EntryPoint>]

let main args =
    Game.runMenu |> ignore
    createBoard |> ignore

    let mutable humanMove = ConsoleUi.getMoveChoice |> int
    if (isAvailablePosition humanMove) = true then
        let board = Board.modifyBoard humanMove "X" 
        Board.isBoardTerminal |> ignore 
        printBoard board 
    else 
        printfn "There was an error!"

    let mutable computerMove = Game.getComputerMove
    if (isAvailablePosition computerMove) = true then 
        let board = Board.modifyBoard computerMove "O"
        Thread.Sleep(1000)
        Board.isBoardTerminal |> ignore 
        printBoard board
    else 
        printfn "There was an error!"

    Console.ReadKey() |> ignore
    0 
