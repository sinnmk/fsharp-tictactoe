module Minimax
open Board

let GetListOfMoves (board: array<string>) =
    let listOfMoves = ResizeArray<int>() 
    for i=0 to 8 do
        if board.[i] = " " then
            listOfMoves.Add (i+1) 
        else 
            listOfMoves |> ignore
    listOfMoves  

let EvaluateScore (board): int =
    let mutable score = 0
    if IsWin(board) "X" then 
        score <- -100
    else if IsWin(board) "O" then  
        score <- 100
    else 
        score <- 0 
    score

let rec MiniMax (board) depth marker = 
    let mutable bestMove = 1
    let mutable board = board
    let mutable depth = depth  
    let mutable marker = marker
    let mutable moves = ResizeArray<int>()

    if ((IsWin (board) marker) = true) then 
        EvaluateScore board |> ignore 

    if marker = "X" then
        let mutable value = -100
        for move in GetListOfMoves(board) do
            board <- ModifyBoard board move marker 
            value <- max(value)(MiniMax(board) depth marker) 
            board <- ModifyBoard board move " "
            marker <- "O"
        value

    else 
        let mutable value = 100
        for move in GetListOfMoves(board) do
            board <- ModifyBoard board move marker
            value <- min(value)(MiniMax(board) depth marker) 
            board <- ModifyBoard board move " "
            marker <- "X" 
        value
        
let SwitchMarker marker= 
    let mutable m = marker
    if m = "X" then
        m <- "O"
    else if m = "O" then 
        m <- "X"
    m

let rec MakeBestMove(board) depth marker = 
    let mutable board = board
    let mutable marker = marker
    let mutable value = 0
    let mutable bestMove = 0
    let mutable bestMoves = ResizeArray<int>();

    for move in GetListOfMoves(board) do
        board <- ModifyBoard board move marker
        value <- MiniMax(board) depth (SwitchMarker(marker)) 
        board <- ModifyBoard board move " " 
        if marker = "X" then
            if value = 100 then 
                bestMove <- move
            if value > 0 then 
                bestMoves.Add (move)
            else if value = 0 then 
                bestMoves.Add (move)
        else if marker = "O" then
            if value = -100 then 
                bestMove <- move
            if value < 0 then 
                bestMoves.Add (move)
            else if value = 0 then 
                bestMoves.Add (move)

    if bestMoves.Count > 0 then
        bestMove <- bestMoves.[0]
    bestMove

//let best_move(self, board, depth, player_marker): 
//        moves = self.get_open_positions(board)
//        choices = []
//        for move in moves: 
//            self.make_next_move(move, board, player_marker)
//            move_score = self.minimax(board, depth + 1, self.change_marker(player_marker))
//            self.make_next_move(move, board, 0)
//            if player_marker == 1: 
//                if move_score == 10: 
//                    choices = move
//                    return choices
//                if move_score > 0: 
//                    choices = [move]
//                elif move_score == 0: 
//                    choices.append(move)
//            else: 
//                if move_score == -10: 
//                    choices = move
//                    return choices
//                if move_score < 0: 
//                    choices = [move]
//                elif move_score == 0: 
//                    choices.append(move)
//        if len(choices) > 0: 
//            return random.choice(choices)
//        else: 
//            return random.choice(moves)