module ConsoleUi
open System

type ValidationResult = 
    |Ok
    |Invalid of string list

let GameMenu = 
    printfn "Welcome to Tic Tac Toe!"  
    printfn "Press any key to Play..."
    System.Console.ReadKey()

let DrawGamePrompt () = printfn "The game is a draw..."

let ValidateInputIsThere (input:string) =
    if input = "" then Invalid ["Input cannot be empty. Please re-enter your input."] 
    else Ok

let ValidateNumIsNum (input: string) =
    match (System.Int32.TryParse(input)) with
    | (true, input) -> Ok 
    | (false, _) -> Invalid ["Error: Input is not a number. Please re-enter a valid number."]

let MovePrompt () = 
    printfn "Please enter your move: "

let invalidMovePrompt () = 
    printfn "INVALID MOVE: please re-enter your move"

let WinPrompt () = 
    printfn "Winner!"

let ExitGame () = 
    System.Threading.Thread.Sleep(1000)
    Environment.Exit(-1)

let PrintBoard board = 
    let join s arr = sprintf "%s%s%s" s (String.concat s arr) s
    board 
    |> Seq.chunkBySize 3
    |> Seq.map (Seq.map (sprintf " %s ") >> join "|")
    |> Seq.map (fun s -> s + "\n")
    |> join "+===+===+===+\n"
    |> printfn "%s"
