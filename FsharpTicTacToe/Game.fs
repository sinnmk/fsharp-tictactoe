module Game 

open System

    let initializeBoard = 
        let board = Board.createBoard
        board

    let switchMarker marker = 
        if marker = "X" then
            let m = "O"
            m
        else 
            let m = "X"
            m

    let getMove = 
        let move =  ConsoleUi.getMoveChoice 
        move 

    let shuffleNumber (num: Random) xs = xs |> Seq.sortBy (fun _ -> num.Next())


    let makeMove (board) move marker= 
        let action = Board.modifyBoard (board) move marker
        action

    let getComputerMove: int = 
        let move = [1..9] |> shuffleNumber (Random ()) |> Seq.head
        move

    let takeHumanTurn board = 
        let move = getMove |> int
        Board.isAvailablePosition move (board) |> ignore 
        let marker = "X"
        let m = switchMarker marker 
        makeMove (board) move m |> ignore
        Board.printBoard board

    let takeComputerTurn board =  
        let marker = "O"
        let move = getComputerMove
        let m = switchMarker marker
        makeMove (board) move m |> ignore
        Board.printBoard board

    let IsNotTerminal board = 
        let b = Board.isBoardTerminal board
        if b = false then
            true
        else 
            false

    let runGame board= 
        takeHumanTurn board
        takeComputerTurn board

    let runMenu =
        ConsoleUi.displayMenu
        let choice = ConsoleUi.getUserMenuChoice
        match choice with  
        |"1" -> runGame 
    




