module Program

open System
open Board
open ConsoleUi

[<EntryPoint>]

let main args =
    
    let mutable board = InitializeBoard 
    let mutable i = 0

    GameMenu |> ignore

    let mutable gameOver = IsBoardTerminal board

    while (gameOver = false) do 
        printfn "Please enter your move (1-9)"
        let mutable move =  Console.ReadLine() |> int 
        let mutable marker = "X" 

        if (IsAvailablePosition (board) move = true) then
            ModifyBoard (board) move marker|> ignore
        else 
            board |> ignore 
        if(CheckForWin (board) marker = true) then  
            PrintBoard board
            printfn "Player One wins!"
            System.Threading.Thread.Sleep(1000)
            Environment.Exit(-1)
        PrintBoard board
        i <-i + 1

        printfn "Please enter your move (1-9)"
        let mutable move =  Console.ReadLine() |> int   
        let mutable marker = SetMarker marker 
        if (IsAvailablePosition (board) move = true) then
            ModifyBoard(board) move marker |> ignore
        else 
            board |> ignore 
        if(CheckForWin (board) marker = true) then  
            PrintBoard board
            printfn "Player two wins!"
            System.Threading.Thread.Sleep(1000)
            Environment.Exit(-1)
        PrintBoard board
        i <-i + 1

    Console.ReadKey() |> ignore
    0 
