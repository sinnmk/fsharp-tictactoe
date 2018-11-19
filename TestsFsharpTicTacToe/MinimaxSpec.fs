module MinimaxSpec
open Xunit

[<Fact>]
let ``EvaluateScore_ReturnMaxScore_WhenGameIsTerminalAndMaximizingPlayerWin``() = 
    let expected = 100
    let actual = Minimax.evaluateScore 100 
    Assert.Equal(expected, actual)

[<Fact>]
let ``EvaluateScore_ReturnMinScore_WhenGameIsTerminalAndMinimizingPlayerWin``() =
    let expected = -100
    let actual = Minimax.evaluateScore -100 
    Assert.Equal(expected, actual)

[<Fact>]
let ``BestMove_ReturnBestMoveForMaximizingPlayerX`` () =
    let expected = 1
    let actual = Minimax.bestMove
    Assert.Equal(expected, actual)

