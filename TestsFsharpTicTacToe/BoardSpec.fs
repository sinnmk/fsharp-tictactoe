module BoardSpec

open System;
open Xunit;
open Board;

[<Fact>]
let ``CreateBoard_CreatesAnEmptyArrayOfEmptyStrings`` () =
    let expected = [|" "; " "; " "; " "; " "; " "; " "; " "; " "|] 
    let actual = Board.createBoard
    Assert.Equal<Collections.Generic.IEnumerable<string>>(expected, actual)

[<Fact>]
let ``ModifyBoard_ModifiesBoard`` () =
    let expected = [|"X"; " "; " "; " "; " "; " "; " "; " "; " "|]  
    let board = Board.createBoard 
    let actual = Board.modifyBoard (board, 1, "X") 
    Assert.Equal<Collections.Generic.ICollection<string>>(expected, actual)

[<Fact>]
let ``IsAvailablePositionOpen_ChecksIfPositionIsOpen_ReturnsTrueIfOpen`` () =
    let expected = true
    let board = Board.createBoard
    let actual = Board.isAvailablePosition (1, board)
    Assert.Equal(expected, actual)

[<Fact>]
let ``IsAvailablePositionOpen_ChecksIfPositionIsOpen_ReturnsFalseIfNot`` () =
    let expected = false 
    let board = [|"X"; " "; " "; " "; " "; " "; " "; " "; " "|]
    let actual = Board.isAvailablePosition (1, board)
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





