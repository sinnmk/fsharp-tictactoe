module BoardSpec

open System;
open Xunit;

[<Fact>]
let ``CreateBoard_ReturnsAnEmptyArrayOfEmptyStrings`` () =
    let expected = [|" "; " "; " "; " "; " "; " "; " "; " "; " "|] 
    let actual = Board.InitializeBoard
    Assert.Equal<Collections.Generic.IEnumerable<string>>(expected, actual)

[<Fact>]
let ``ModifyBoard_ModifiesBoardAtMoveIndex_ReturnsModifiedBoard`` () =
    let expected = [|"X"; " "; " "; " "; " "; " "; " "; " "; " "|]  
    let board = [|" "; " "; " "; " "; " "; " "; " "; " "; " "|] 
    let actual = Board.ModifyBoard (board) 1 "X" 
    Assert.Equal<Collections.Generic.ICollection<string>>(expected, actual)

[<Fact>]
let ``IsAvailablePositionOpen_ChecksIfPositionIsOpen_ReturnsTrueIfOpen`` () =
    let expected = true
    let board = [|" "; " "; " "; " "; " "; " "; " "; " "; " "|]
    let actual = Board.IsAvailablePosition (board)1 
    Assert.Equal(expected, actual)

[<Fact>]
let ``IsAvailablePositionOpen_ChecksIfPositionIsOpen_ReturnsFalseIfNot`` () =
    let expected = false 
    let board = [|"X"; " "; " "; " "; " "; " "; " "; " "; " "|]
    let actual = Board.IsAvailablePosition (board)1 
    Assert.Equal(expected, actual)

[<Fact>]
let ``CheckForWinForPlayerX_ChecksIfGameIsWon_ReturnsTrueIfWon`` () =
    let expected = true 
    let board = [|"X"; "X"; "X"; " "; " "; " "; "O"; "O"; " "|]
    let marker = "X"
    let actual = Board.GameWon (board) marker
    Assert.Equal(expected, actual)

[<Fact>]
let ``CheckForWinForPlayerX_ChecksIfGameIsLost_ReturnsFalseIfNot`` () =
    let expected = false 
    let board = [|"X"; "X"; " "; " "; " "; " "; "O"; "O"; " "|]
    let marker = "X"
    let actual = Board.GameWon(board) marker
    Assert.Equal(expected, actual)

[<Fact>]
let ``CheckForWinForPlayerO_ChecksIfGameIsWon_ReturnsTrueIfWon`` () =
    let expected = true
    let board = [|"O"; "O"; "O"; " "; "X"; " "; "X"; "X"; " "|]
    let marker = "O"
    let actual = Board.GameWon (board) marker
    Assert.Equal(expected, actual)

[<Fact>]
let ``CheckForWinForPlayerO_ChecksIfGameIsWon_ReturnsFalseIfNotWon`` () =
    let expected = false 
    let board = [|"O"; "O"; " "; " "; "X"; " "; "X"; "X"; " "|]
    let marker = "O"
    let actual = Board.GameWon (board) marker
    Assert.Equal(expected, actual)

[<Fact>]
let ``IsBoardTerminal_ChecksIfBoardIsCompleted_ReturnsTrueIfCompleted`` () =
    let expected = true
    let board = [|"X"; "X"; "X"; "O"; "X"; "O"; "O"; "O"; "X"|]
    let actual = Board.IsBoardTerminal (board) 
    Assert.Equal(expected, actual)

[<Fact>]
let ``IsBoardTerminal_ChecksIfBoardIsCompleted_ReturnsFalseIfCompleted`` () =
    let expected = false
    let board =  [|"X"; "X"; " "; " "; " "; " "; "O"; "O"; " "|]
    let actual = Board.IsBoardTerminal (board)
    Assert.Equal(expected, actual)

[<Fact>]
let ``CheckHorizontalWins_ChecksForHorizontalWin_ReturnsTrueWhenAWin`` () = 
    let expected =true  
    let board =  [|"X"; "X"; "X"; " "; " "; " "; "O"; "O"; " "|]
    let actual = Board.CheckHorizontalWins (board) "X" 
    Assert.Equal(expected, actual)

[<Fact>]
let ``CheckHorizontalWins_ChecksForHorizontalWin_ReturnsFalseWhenNotAWin`` () = 
    let expected = false  
    let board =  [|" "; " "; "X"; " "; " "; " "; "X"; "O"; "O"|]
    let actual = Board.CheckHorizontalWins (board) "X" 
    Assert.Equal(expected, actual)
