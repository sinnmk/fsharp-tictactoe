module ConsoleUi

    type ValidationResult = 
        |Ok
        |Invalid of string list

    let gameMenu = 
        printfn "Welcome to Tic Tac Toe!"  
        printfn "Press any key to Play Game"
        System.Console.ReadKey()

    let validateInputIsThere (input:string) =
        if input = "" then Invalid ["Input cannot be empty. Please re-enter your input."] 
        else Ok

    let validateNumIsNum (input: string) =
        match (System.Int32.TryParse(input)) with
        | (true, input) -> Ok 
        | (false, _) -> Invalid ["Error: Input is not a number. Please re-enter a valid number."]
        
       // let mutable validateNum = Validation.validateNumIsNum input
       // if validateNum = Validation.Ok then
       //     input |> int
       // else Error |> int 



