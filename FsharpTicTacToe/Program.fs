module Program

open System
open Board
open ConsoleUi
open Game
open Player

[<EntryPoint>]

let main args =
    GameMenu |> ignore
    let mutable gameOver = IsBoardTerminal board
    PrintBoard(board)
    let humanPlayer = new HumanPlayer()
    let computerPlayer = new ComputerPlayer()
    let mutable isHumansTurn = true
    while (gameOver = false) do 
        if(isHumansTurn) then
            PlayerMakesMove(humanPlayer)
        else
            PlayerMakesMove(computerPlayer)
        isHumansTurn <- not isHumansTurn

    Console.ReadKey() |> ignore
    0 
