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
            board.[move-1] <- marker
        else 
            printfn("Error, not correct input")
        if(checkForWin (board) marker = true) then  
            printfn"Winner"
        printBoard board
        i <-i + 1

        System.Threading.Thread.Sleep(1000)

        //printfn "Please enter your move (1-9)"
        //let mutable move =  Console.ReadLine() |> int 
        //let mutable marker = "O" 
        //if (isAvailablePosition (board) move = true) then
        //    board.[move-1] <- marker
        //else 
        //    printfn("Error, not correct input")
        //if(checkForWin (board) marker = true) then  
        //    printfn"Winner"
        //printBoard board
        //i <-i + 1

    Console.ReadKey() |> ignore
    0 
