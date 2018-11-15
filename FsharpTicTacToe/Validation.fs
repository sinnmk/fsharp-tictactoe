module Validation

type ValidationResult = 
    |Ok
    |Invalid of string list

let validateInputIsThere (input:string) =
    if input = "" then Invalid ["Input cannot be empty. Please re-enter your input."] 
    else Ok

let validateNumIsNum (input: string) =
    match (System.Int32.TryParse(input)) with
    | (true, input) -> Ok 
    | (false, _) -> Invalid ["Error: Input is not a number. Please re-enter a valid number."]
