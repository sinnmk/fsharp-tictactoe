module GameSpec

open System;
open Xunit;
open Game;

[<Fact>]
let ``makeMove_CallsMakeMoveFromConsoleUi_ReturnsModifiedBoard`` () =
    let expected = [|"X"; " "; " "; " "; " "; " "; " "; " "; " "|] 
    let board = [|" "; " "; " "; " "; " "; " "; " "; " "; " "|]
    let actual = Game.makeMove (board, 1, "X")
    Assert.Equal<Collections.Generic.IEnumerable<string>>(expected, actual)

//[<Fact>]
//let ``runMenu_CallsDisplaymenuFromConsoleUi_PrintsOutMenuInConsole``()=
//    let expected = ""
//    let actual = Game.runMenu
