module Program

open System
open Board
open ConsoleUi

[<EntryPoint>]

let main args =
    
    let mutable board = [|" ";" ";" ";" ";" ";" ";" ";" ";" "|] 

    let mutable i = 0

    displayMenu

    while (isBoardTerminal board = false) do 
        printBoard board
        let mutable marker = "X"
        let mutable move =  Console.ReadLine() |> int 
        if (isAvailablePosition (board) move = true) then
            board.[move-1] <- marker
            if (checkForWin board marker = true) then
                printfn("Winner!")
        else 
            printfn("Error, not correct input")
        printBoard board
        i <-i + 1

        let mutable marker = "O"
        let mutable move =  Console.ReadLine() |> int 
        board.[move-1] <- marker
        if (isAvailablePosition (board) move = true) then
            board.[move-1] <- marker
            if (checkForWin board marker = true) then
                printfn("winner!")
        else 
            printfn("Error, not correct input")
        printBoard board
        i <-i + 1
    

    Console.ReadKey() |> ignore
    0 
