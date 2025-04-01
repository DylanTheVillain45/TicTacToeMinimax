public class TicTacToe {
    int[] board = new int[9];
    
    public void NewGame() {
        int move;
        bool isPlayerMove = HelperFunction.GetUserInput();
        bool isX = true;

        while (true) {
            List<int> possibleMoves = HelperFunction.GetMoves(board);
            if (isPlayerMove) {
                HelperFunction.ShowBoard(board);
                move = HelperFunction.GetPlayerMove(possibleMoves);
            } else {
                move = MiniMax.GetBestMove(board, possibleMoves, isX);
            }

            HelperFunction.CommitMove(board, move, isX);

            if (HelperFunction.CheckWin(board, move) != 0) {
                Console.Clear();
                HelperFunction.ShowBoard(board);
                Console.WriteLine();
                Console.WriteLine(isPlayerMove ? "Player Wins" : "AI Wins");
                return;
            }

            isX = !isX;
            isPlayerMove = !isPlayerMove;
        }   
    }
}