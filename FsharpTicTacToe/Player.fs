module Player 

    type IPlayer = 
        abstract member GetMove: array<string> -> int 
        abstract member Marker : string 

    type ComputerPlayer ()= 
        interface IPlayer with 
            member this.GetMove board = Minimax.MakeBestMove(board) 
            member this.Marker = "O"

    type HumanPlayer ()= 
        interface IPlayer with
            member this.Marker = "X"
            member this.GetMove board=
                let mutable isValidInput = false
                ConsoleUi.MovePrompt ()
                let mutable humanMove = 0 
                while (isValidInput = false) do
                    humanMove <- ConsoleUi.GetHumanMove()
                    if (Board.IsAvailablePosition (board) humanMove = true) then
                        isValidInput <- true
                    else 
                        ConsoleUi.invalidMovePrompt()
                humanMove
