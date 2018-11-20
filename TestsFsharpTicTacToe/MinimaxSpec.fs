module MinimaxSpec
open Xunit
open System
open Minimax

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
let ``Minimax_FindsBestMoveScoreForMaxPlayer_ReturnsBestMoveScore`` ()=
    let board = [|" "; " "; " "; " "; "X"; "O"; "X"; "O"; "X"|]
    let expected = -100
    let maxPlayer = "X"
    let marker = "X"
    let actual = Minimax.MinMax (board) maxPlayer marker
    Assert.Equal(expected, actual)

[<Fact>]
let ``Minimax_FindsBestMoveScoreForMinPlayer_ReturnsBestMoveScore ``() = 
    let board = [|"O"; "O"; " "; " "; "X"; "X"; "O"; "X"; "X"|]
    let expected = 100
    let maxPlayer = "O"
    let marker = "O"
    let actual = Minimax.MinMax (board) maxPlayer marker
    Assert.Equal(expected, actual)

[<Fact>]
let ``BestMove_WithBoard220011211_ReturnsBestMoveForBoardStateForMaxPlayer`` () =
    let board = [|"O"; "O"; " "; " "; "X"; "X"; "O"; "X"; "X"|]
    let expected = 4
    let maxPlayer = "X"
    let marker = "X"
    let actual = BestMove (board) maxPlayer marker
    Assert.Equal(expected, actual)


