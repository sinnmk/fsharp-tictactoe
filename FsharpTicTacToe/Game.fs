module Game 

open System

    let getMove = 
        let move =  ConsoleUi.getMoveChoice 
        move 

    let shuffleNumber (num: Random) xs = xs |> Seq.sortBy (fun _ -> num.Next())

    let makeMove (board) move marker= 
        let action = Board.modifyBoard move marker
        action

    let getComputerMove: int = 
        let move = [1..9] |> shuffleNumber (Random ()) |> Seq.head
        move

    let runMenu =
        ConsoleUi.displayMenu
