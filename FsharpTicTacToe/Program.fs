module Program

open System

[<EntryPoint>]

let main args =
    Game.runMenu |> ignore

    Console.ReadKey() |> ignore
    0 
