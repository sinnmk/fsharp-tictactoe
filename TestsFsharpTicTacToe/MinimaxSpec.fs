module MinimaxSpec
open Xunit
open System

[<Fact>]
let ``EvaluateScore_ReturnMaxScore_WhenGameIsTerminalAndMaximizingPlayerWin``() = 
    let board = [|"X"; "X"; " "; "O"; "O"; "O"; " "; "X"; " "|]
    let expected = 100
    let actual = Minimax.EvaluateScore (board) 
    Assert.Equal(expected, actual)

[<Fact>]
let ``EvaluateScore_ReturnMinScore_WhenGameIsTerminalAndMinimizingPlayerWin``() =
    let board = [|"X"; "X"; "X"; "O"; "O"; " "; " "; " "; " "|]
    let expected = -100
    let actual = Minimax.EvaluateScore (board) 
    Assert.Equal(expected, actual)

[<Fact>]
let ``GetListOfMoves_ReturnsAListOfAvailableMovesOfCurrentGameState`` () =
    let board = [|" "; " "; " "; " "; "X"; "O"; "X"; "O"; "X"|]
    let expected = [|1; 2; 3; 4|]
    let actual = Minimax.GetListOfMoves (board)
    Assert.Equal<Collections.Generic.ICollection<int>>(expected, actual)

[<Fact>]
let ``GetListOfMoves_ReturnsAListOfAvailableMovesOfGame`` () =
    let board = [|" "; " "; " "; " "; " "; "O"; "X"; " "; " "|]
    let expected = [|1; 2; 3; 4; 5; 8; 9|]
    let actual = Minimax.GetListOfMoves (board)
    Assert.Equal<Collections.Generic.ICollection<int>>(expected, actual)

[<Fact>]
let ``DoMiniMax_WithBoard_OO--XXOXX_ReturnsBestMoveForMaxPlayer`` () =
    let board = [|"O"; "O"; " "; " "; "X"; "X"; "O"; "X"; "X"|]
    let expected = 4
    let depth = 0
    let maxPlayer = "O" 
    let marker = "O"
    let actual = Minimax.MaximizeScore (board) depth maxPlayer marker
    Assert.Equal(expected, actual)

[<Fact>]
let ``DoMiniMax_XO-X-O---_ReturnsBestMoveForMaxPlayer`` () = 
    let board =  [|"X"; "O"; " "; "X"; "-"; "O"; "-"; "-"; "-"|]
    let expected = 7 
    let depth = 0
    let maxPlayer = "X"
    let marker = "X"
    let actual = Minimax.MaximizeScore (board) depth maxPlayer marker
    Assert.Equal(expected, actual)
