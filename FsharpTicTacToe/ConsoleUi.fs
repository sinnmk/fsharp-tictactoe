module ConsoleUi

    type ValidationResult = 
        |Ok
        |Invalid of string list

    let GameMenu = 
        printfn "Welcome to Tic Tac Toe!"  
        printfn "Press any key to Play Game"
        System.Console.ReadKey()

    let ValidateInputIsThere (input:string) =
        if input = "" then Invalid ["Input cannot be empty. Please re-enter your input."] 
        else Ok

    let ValidateNumIsNum (input: string) =
        match (System.Int32.TryParse(input)) with
        | (true, input) -> Ok 
        | (false, _) -> Invalid ["Error: Input is not a number. Please re-enter a valid number."]
