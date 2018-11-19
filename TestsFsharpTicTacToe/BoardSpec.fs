module BoardSpec

open System;
open Xunit;

[<Fact>]
let ``CreateBoard_ReturnsAnEmptyArrayOfEmptyStrings`` () =
    let expected = [|" "; " "; " "; " "; " "; " "; " "; " "; " "|] 
    let actual = Board.initializeBoard
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
    let actual = Board.isAvailablePosition (board)1 
    Assert.Equal(expected, actual)

[<Fact>]
let ``IsAvailablePositionOpen_ChecksIfPositionIsOpen_ReturnsFalseIfNot`` () =
    let expected = false 
    let board = [|"X"; " "; " "; " "; " "; " "; " "; " "; " "|]
    let actual = Board.isAvailablePosition (board)1 
    Assert.Equal(expected, actual)

[<Fact>]
let ``CheckForWinForPlayerX_ChecksIfGameIsWon_ReturnsTrueIfWon`` () =
    let expected = true 
    let board = [|"X"; "X"; "X"; " "; " "; " "; "O"; "O"; " "|]
    let marker = "X"
    let actual = Board.checkForWin (board) marker
    Assert.Equal(expected, actual)

[<Fact>]
let ``CheckForWinForPlayerX_ChecksIfGameIsLost_ReturnsFalseIfNot`` () =
    let expected = false 
    let board = [|"X"; "X"; " "; " "; " "; " "; "O"; "O"; " "|]
    let marker = "X"
    let actual = Board.checkForWin (board) marker
    Assert.Equal(expected, actual)

[<Fact>]
let ``CheckForWinForPlayerO_ChecksIfGameIsWon_ReturnsTrueIfWon`` () =
    let expected = true
    let board = [|"O"; "O"; "O"; " "; "X"; " "; "X"; "X"; " "|]
    let marker = "O"
    let actual = Board.checkForWin (board) marker
    Assert.Equal(expected, actual)

[<Fact>]
let ``CheckForWinForPlayerO_ChecksIfGameIsWon_ReturnsFalseIfNotWon`` () =
    let expected = false 
    let board = [|"O"; "O"; " "; " "; "X"; " "; "X"; "X"; " "|]
    let marker = "O"
    let actual = Board.checkForWin (board) marker
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





