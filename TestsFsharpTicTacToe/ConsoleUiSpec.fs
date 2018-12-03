module ConsoleUiSpec
open Xunit
open ConsoleUi

[<Fact>]
let ``ValidateInputIsThere_ReturnsOkIfInputIsValid`` () =
    let expected = Ok
    let input = "There is input here."
    let actual = ValidateInputIsThere input
    Assert.Equal(expected, actual)

[<Fact>]
let ``ValidateInputIsThere_ReturnsInvalidIfInputIsInvalid`` () =
    let expected = Invalid["Input cannot be empty. Please re-enter your input."]
    let input = ""
    let actual = ValidateInputIsThere input
    Assert.Equal(expected, actual)

[<Fact>]
let ``ValidateNumIsNum_ReturnsOkIfInputIsNum`` () =
    let expected = Ok
    let input = "1"
    let actual = ValidateNumIsNum input
    Assert.Equal(expected, actual)

[<Fact>]
let ``ValidateNumIsNum_ReturnsInvalidIfInputIsNotNum`` () =
    let expected = Invalid ["Error: Input is not a number. Please re-enter a valid number."]
    let input = "This is a string not number."
    let actual = ValidateNumIsNum input
    Assert.Equal(expected, actual)
