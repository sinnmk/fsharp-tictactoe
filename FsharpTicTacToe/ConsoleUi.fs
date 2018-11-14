module ConsoleUi

    type ConsoleUi() = 

        static member displayMenu = 
            printfn "Welcome to Tic Tac Toe!"  
            printfn "Do you want to: \n 1. Play game \n 2. Display Rules \n 3. Quit"

        static member displayMovePrompt = 
            printfn "Please enter your move (1-9)"

        static member getMoveChoice = 
            let choice = System.Console.ReadLine()
            choice

        static member getUserMenuChoice: int = 
            printfn "Please enter your choice: "
            let choice  = System.Console.ReadLine()
            let moveChoice = choice |> int
            moveChoice

       

        


