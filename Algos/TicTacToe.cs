using System;

namespace Algos
{
    public class TicTacToe
    {
        public static void Test()
        {
            var result = Tictactoe(new int[][] { new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 1, 0 }, new int[] { 2, 0 } });
            Console.WriteLine(result);

            //result = Tictactoe(new int[][] { new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 2, 0 }, new int[] { 1, 0 }, new int[] { 1, 2 }, new int[] { 2, 1 }, new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 2, 2 } });
            //Console.WriteLine(result);

            result = Tictactoe(new int[][] { new int[] { 0, 2 }, new int[] { 1, 0 }, new int[] { 2, 2 }, new int[] { 1, 2 }, new int[] { 2, 0 }, new int[] { 0, 0 }, new int[] { 0, 1 }, new int[] { 2, 1 }, new int[] { 1, 1 } });
            Console.WriteLine(result);
        }

        public static string Tictactoe(int[][] moves)
        {
            var board = new int[3, 3];

            for (int i = 0; i < moves.Length; i++)
            {
                int row = moves[i][0];
                int col = moves[i][1];
                int state = (i % 2) + 1;
                board[row, col] = state;

                if (i >= 4)
                {
                    bool rowWin = true;
                    bool colWin = true;
                    bool isDiagnol = (row == col) || (row + col == 2);
                    bool diagWin = isDiagnol;
                    bool minDiagWin = isDiagnol;
                    for (int j = 0; j < 3; j++)
                    {
                        rowWin = rowWin && (board[j, col] == state);
                        colWin = colWin && (board[row, j] == state);
                        if (isDiagnol)
                        {
                            diagWin = diagWin && (board[j, j] == state);
                            minDiagWin = minDiagWin && (board[j, 2 - j] == state);
                        }
                    }

                    if (rowWin || colWin || diagWin || minDiagWin)
                        return state == 1 ? "A" : "B";
                }
            }

            return "Pending";
        }
    }
}
