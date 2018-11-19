module ConsoleUi

    type ValidationResult = 
        |Ok
        |Invalid of string list

    let displayMenu = 
        printfn "Welcome to Tic Tac Toe!"  
        printfn "Do you want to: \n 1. Play game \n 2. Display Rules \n 3. Quit"
        

    let validateInputIsThere (input:string) =
        if input = "" then Invalid ["Input cannot be empty. Please re-enter your input."] 
        else Ok

    let validateNumIsNum (input: string) =
        match (System.Int32.TryParse(input)) with
        | (true, input) -> Ok 
        | (false, _) -> Invalid ["Error: Input is not a number. Please re-enter a valid number."]

    let getUserMenuChoice = 
        printfn "Please enter your menu choice (1-3): "
        let mutable input  = System.Console.ReadLine()
        let mutable validateNum = Validation.validateNumIsNum input
        if validateNum = Validation.Ok then 
            let mutable validNumber = input
            validNumber 
        else   
            "error!"

    let getMoveChoice: int = 
        printfn "Please enter your move (1-9): "
        let mutable input = System.Console.ReadLine()
        let mutable validateNum = Validation.validateNumIsNum input
        if validateNum = Validation.Ok then
            input |> int
        else "error" |> int  
