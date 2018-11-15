module BoardSpec

open System;
open Xunit;

[<Fact>]
let ``CreateBoard_ReturnsAnEmptyArrayOfEmptyStrings`` () =
    let expected = [|" "; " "; " "; " "; " "; " "; " "; " "; " "|] 
    let actual = Board.createBoard
    Assert.Equal<Collections.Generic.IEnumerable<string>>(expected, actual)

[<Fact>]
let ``ModifyBoard_ModifiesBoardAtMoveIndex_ReturnsModifiedBoard`` () =
    let expected = [|"X"; " "; " "; " "; " "; " "; " "; " "; " "|]  
    let board = [|" "; " "; " "; " "; " "; " "; " "; " "; " "|] 
    let actual = Board.modifyBoard (board) 1 "X" 
    Assert.Equal<Collections.Generic.ICollection<string>>(expected, actual)

[<Fact>]
let ``IsAvailablePositionOpen_ChecksIfPositionIsOpen_ReturnsTrueIfOpen`` () =
    let expected = true
    let board = [|" "; " "; " "; " "; " "; " "; " "; " "; " "|]
    let actual = Board.isAvailablePosition 1 (board)
    Assert.Equal(expected, actual)

[<Fact>]
let ``IsAvailablePositionOpen_ChecksIfPositionIsOpen_ReturnsFalseIfNot`` () =
    let expected = false 
    let board = [|"X"; " "; " "; " "; " "; " "; " "; " "; " "|]
    let actual = Board.isAvailablePosition 1 (board)
    Assert.Equal(expected, actual)

[<Fact>]
let ``CheckForWin_ChecksIfGameIsWon_ReturnsTrueIfWon`` () =
    let expected = true 
    let board = [|"X"; "X"; "X"; " "; " "; " "; "O"; "O"; " "|]
    let actual = Board.checkForWin (board, "X")
    Assert.Equal(expected, actual)

[<Fact>]
let ``CheckForWin_ChecksIfGameIsLost_ReturnsFalseIfNot`` () =
    let expected = true 
    let board = [|"X"; "X"; " "; " "; " "; " "; "O"; "O"; " "|]
    let actual = Board.checkForWin (board, "O")
    Assert.Equal(expected, actual)

[<Fact>]
let ``IsBoardTerminal_ChecksIfBoardIsCompleted_ReturnsTrueIfCompleted`` () =
    let expected = true
    let board = [|"X"; "X"; "X"; "O"; "X"; "O"; "O"; "O"; "X"|]
    let actual = Board.isBoardTerminal (board)
    Assert.Equal(expected, actual)

[<Fact>]
let ``IsBoardTerminal_ChecksIfBoardIsCompleted_ReturnsFalseIfCompleted`` () =
    let expected = false
    let board =  [|"X"; "X"; " "; " "; " "; " "; "O"; "O"; " "|]
    let actual = Board.isBoardTerminal (board)
    Assert.Equal(expected, actual)

