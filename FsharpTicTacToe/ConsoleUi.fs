module ConsoleUi

        let displayMenu = 
            printfn "Welcome to Tic Tac Toe!"  
            printfn "Do you want to: \n 1. Play game \n 2. Display Rules \n 3. Quit"

        let getMoveChoice = 
            printfn "Please enter your move (1-9): "
            let input = System.Console.ReadLine()
            let validateNum = Validation.validateNumIsNum input
            if validateNum = Validation.Ok then
                input
            else "error!"  

        let getUserMenuChoice = 
            printfn "Please enter your menu choice (1-3): "
            let input  = System.Console.ReadLine()
            let validateNum = Validation.validateNumIsNum input
            if validateNum = Validation.Ok then 
                input
            else "error!"

                
