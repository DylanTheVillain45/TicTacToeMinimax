public class TicTacToe {
    public void NewGame() {
        int[] board = new int[9];
        int move;
        bool isPlayerMove = HelperFunction.GetUserInput();
        bool isX = true;

        while (true) {
            List<int> possibleMoves = HelperFunction.GetMoves(board);
            
            if (possibleMoves.Count == 0) {
                Console.Clear();
                HelperFunction.ShowBoard(board);
                Console.WriteLine();
                Console.WriteLine("Draw");
                Console.WriteLine("Press enter to play again");
                Console.ReadLine();
                NewGame();
                return;
            }

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
                Console.WriteLine("Press enter to play again");
                Console.ReadLine();
                NewGame();
                return;
            }

            isX = !isX;
            isPlayerMove = !isPlayerMove;
        }   
    }
}