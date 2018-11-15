module GameSpec

open System;
open Xunit;

[<Fact>]
let ``MakeMove_CallsMakeMoveFromConsoleUi_ReturnsModifiedBoard`` () =
    let expected = [|"X"; " "; " "; " "; " "; " "; " "; " "; " "|] 
    let board = [|" "; " "; " "; " "; " "; " "; " "; " "; " "|]
    let actual = Game.makeMove (board) 1 "X"
    Assert.Equal<Collections.Generic.IEnumerable<string>>(expected, actual)

[<Fact>]
let ``SwitchMarker_CallsSwitchMarkerWithX_ReturnsOMarker`` () =
    let expected = "O"
    let marker = "X"
    let actual = Game.switchMarker marker
    Assert.Equal(expected, actual)

[<Fact>]
let ``SwitchMarker_CallsSwitchMarkerWithO_ReturnsXMarker`` () =
    let expected = "X"
    let marker = "O"
    let actual = Game.switchMarker marker
    Assert.Equal(expected, actual)

