module Game
open Board
open ConsoleUi
open Minimax
open Player

let mutable board = InitializeBoard  

let CheckForWin marker = 
    if(GameWon (board) marker = true) then  
        PrintBoard board
        WinPrompt ()
        ExitGame ()

let CheckForDraw() = 
    if(GetListOfMoves(board).Count = 0) then
        DrawGamePrompt()
        ExitGame()

let GenerateRandomMove (board) = 
    let rnd = System.Random()
    let moves = GetListOfMoves board
    let mutable computerMove = moves.[rnd.Next(moves.Count)]
    computerMove

let PlayerMakesMove (currentPlayer) = 
    let mutable marker = (currentPlayer:>IPlayer).Marker
    let mutable move = (currentPlayer:>IPlayer).GetMove(board)
    ModifyBoard (board) move marker|> ignore
    CheckForWin(marker)
    CheckForDraw()
    PrintBoard board
