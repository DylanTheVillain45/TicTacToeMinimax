public static class HelperFunction {
    public static void RandomizeList(List<int> list) {
        Random random = new Random();
        for (int i = 0; i < list.Count; i++) {
            int j = random.Next(0, list.Count);
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    public static int CheckWin(int[] board, int lastMove) {
        int player = board[lastMove]; // GET CURRENT PLAYER EITHER 1 or -1

        int row = lastMove / 3;
        int col = lastMove % 3;

        // check row 
        if (board[row * 3] == player && board[row * 3 + 1] == player && board[row * 3 + 2] == player)  {
            return player;
        }

        // check col 
        if (board[col] == player && board[col + 3] == player && board[col + 6] == player) {
            return player;
        } 

        if (lastMove % 2 == 0 && board[4] == player) {
            if (board[0] == player && board[8] == player) return player;
            if (board[2] == player && board[6] == player) return player;
        }

        return 0;
    }

    public static bool GetUserInput() {
        Console.WriteLine("Do you want to play first? y or n");
        while (true) {
            string? response = Console.ReadLine();
            if (response == null) continue;
            if (response == "y") return true;
            if (response == "n") return false;
        }
    }

    public static List<int> GetMoves(int[] board) {
        List<int> moves = new List<int>();
        for (int i = 0 ; i < board.Length; i++) {
            if (board[i] == 0) {
                moves.Add(i);
            }
        }
        return moves;
    }

    public static int GetPlayerMove(List<int> posMoves) {
        Console.WriteLine("Select Move");
        foreach (int move in posMoves) {
            Console.WriteLine($"move: {move} at {move % 3}, {move / 3}");
        }

        while (true) {
            string? response = Console.ReadLine();
            if (response == null) {
                Console.WriteLine("Enter valid Integer");
                continue;
            } 
            if (int.TryParse(response, out int move) == false) {
                Console.WriteLine("Please Enter a number");
                continue;
            }
            if (posMoves.Contains(move)) {
                return move;
            } else {
                Console.WriteLine("That isn't a valid move");
            }
        }
    }

    public static void CommitMove(int[] board, int move, bool playerBool) {
        int player = playerBool ? 1 : -1;

        board[move] = player;
    }

    public static void UndoMove(int[] board, int move) {
        board[move] = 0;
    }

    public static void ShowBoard(int[] board) {
        Console.WriteLine("-----------");
        Console.Write("|");
        for (int i = 0; i < 9; i++) {
            char player = board[i] == 0 ? '.' : board[i] == 1 ? 'x' : 'o';


            if ((i + 1) % 3 == 0) {
                Console.Write($" {player} |");
                Console.WriteLine();
                if (i != 8) {
                    Console.Write("|");
                }
            } else {
                Console.Write($" {player} ");
            }
        }
        Console.WriteLine("-----------");
    }

}