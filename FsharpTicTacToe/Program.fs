module Program

open System
open Board
open ConsoleUi

[<EntryPoint>]

let main args =
    
    let mutable board = initializeBoard 
    let mutable i = 0

    gameMenu |> ignore

    let mutable gameOver = isBoardTerminal board

    while (gameOver = false) do 
        printfn "Please enter your move (1-9)"
        let mutable move =  Console.ReadLine() |> int 
        let mutable marker =  "X" 

        if (isAvailablePosition (board) move = true) then
            modifyBoard (board) move marker|> ignore
        else 
            board |> ignore 
        if(checkForWin (board) marker = true) then  
            printfn "Player One wins!"
            System.Threading.Thread.Sleep(2000)
            Environment.Exit(-1)
        printBoard board
        i <-i + 1

        printfn "Please enter your move (1-9)"
        let mutable move =  Console.ReadLine() |> int   
        let mutable marker = "O" 
        if (isAvailablePosition (board) move = true) then
            modifyBoard(board) move marker |> ignore
        else 
            board |> ignore 
        if(checkForWin (board) marker = true) then  
            printfn "Player two wins!"
            System.Threading.Thread.Sleep(2000)
            Environment.Exit(-1)
        printBoard board
        i <-i + 1

    Console.ReadKey() |> ignore
    0 
