module Game
open ConsoleUi
open Board
open System

type Game() =

    static member runMenu =
        let menu = ConsoleUi.displayMenu
        menu

        let choice = ConsoleUi.getUserMenuChoice

        match choice with  
        |1 -> printfn "runGame"
        |2 -> printfn "displayRules"
        |3 -> printfn "quit"

    static member getMove = 
        let move =  ConsoleUi.getMoveChoice 
        move 

    static member getComputerMove = 
        let moveOptions = [1, 2, 3, 4, 5, 6, 7, 8, 9]
        let randomMove = 
            let random = Random()
            fun () -> moveOptions.Item (random.Next(moveOptions.Length - 1))
        randomMove 

    
    static member makeMove (board, move, marker)= 
        let action = Board.modifyBoard (board, move, marker)
        action

    static member takeHumanTurn board = 
        ConsoleUi.displayMovePrompt
        let move = Game.getMove |> int
        Board.isAvailablePosition (move, board) 
        let marker = "X" 
        Game.makeMove (board, move, marker)
        Board.printBoard board

    static member takeComputerTurn board =  
        let move = Game.getComputerMove 
        let marker = "O"
        Game.makeMove (board, 2, marker)
        Board.printBoard board







        




    
