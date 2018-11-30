module MinimaxSpec
open Xunit
open System

[<Fact>]
let ``EvaluateScore_ReturnMaxScoreOf100_WhenGameIsTerminalAndMaximizingPlayerWin``() = 
    let board = [|"X"; "X"; " "; "O"; "O"; "O"; " "; "X"; " "|]
    let expected = -100
    let actual = Minimax.EvaluateScore (board) 
    Assert.Equal(expected, actual)

[<Fact>]
let ``EvaluateScore_ReturnMinScoreOfNegative100_WhenGameIsTerminalAndMinimizingPlayerWin``() =
    let board = [|"X"; "X"; "X"; "O"; "O"; " "; " "; " "; " "|]
    let expected = 100
    let actual = Minimax.EvaluateScore (board) 
    Assert.Equal(expected, actual)

[<Fact>]
let ``EvaluateScore_ReturnADrawScoreOfZero_WhenGameIsTerminalAndNoMovesLeft``() =
    let board = [|"X"; "O"; "X"; "O"; "X"; "X"; "O"; "X"; "O"|]
    let expected = 0
    let actual = Minimax.EvaluateScore (board)
    Assert.Equal(expected, actual)

[<Fact>]
let ``SwitchMarker_ReturnTheMarkerOWhenMarkerX`` () = 
    let marker = "X"
    let expected = "O"
    let actual = Minimax.SwitchMarker marker
    Assert.Equal(expected, actual)
    
[<Fact>]
let ``SwitchMarker_ReturnTheMarkerXWhenMarkerO`` () = 
    let marker = "O"
    let expected = "X"
    let actual = Minimax.SwitchMarker marker
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
let ``MakeBestMove_WhenBoardIsEmpty_Returns1AsBestMove`` () =
    let board = [|" "; " "; " "; " "; " "; " "; " "; " "; " "|]
    let expected = 1
    let actual = Minimax.MakeBestMove (board) 9 "X" 
    Assert.Equal(expected, actual)

[<Fact>]
let ``MakeBestMove_WhenBoardHasOneMoveInPosition1_Returns5AsBestMove`` () =
    let board = [|"X"; " "; " "; " "; " "; " "; " "; " "; " "|]
    let expected = 5
    let actual = Minimax.MakeBestMove (board) 8 "O" 
    Assert.Equal(expected, actual)

[<Fact>]
let ``MakeBestMove_WhenBoardIs_X-X-O----_Returns2AsBestMove`` () =
    let board = [|"X"; " "; "X"; " "; "O"; " "; " "; " "; " "|]
    let expected = 2
    let actual = Minimax.MakeBestMove(board) 6 "O"
    Assert.Equal(expected, actual)

//[<Fact>]
//let ``MakeBestMove_WhenBoardIs_XOX-O---X_Returns8AsBestMove`` () =
//    let board = [|"X"; "O"; "X"; " "; "O"; " "; " "; " "; "X"|]
//    let expected = 8
//    let actual = Minimax.MakeBestMove(board) 4 "O"
//    Assert.Equal(expected, actual)
