module Game 

    let runMenu =
        let menu = ConsoleUi.displayMenu
        menu

        let choice = ConsoleUi.getUserMenuChoice

        match choice with  
        |"1" -> printfn "runGame"
        |"2" -> printfn "displayRules"
        |"3" -> printfn "quit"

    let getMove = 
        let move =  ConsoleUi.getMoveChoice 
        move 

    let makeMove (board) move marker= 
        let action = Board.modifyBoard (board) move marker
        action

    let switchMarker marker = 
        if marker = "X" then
            let m = "O"
            m
        else 
            let m = "X"
            m

    let takeHumanTurn board = 
        let move = getMove |> int
        Board.isAvailablePosition move (board) |> ignore 
        let marker = "X"
        let m = switchMarker marker 
        makeMove (board) move m |> ignore
        Board.printBoard board

    let takeComputerTurn board =  
        let marker = "O"
        let m = switchMarker marker
        makeMove (board) 2 m |> ignore
        Board.printBoard board

    







        




    
