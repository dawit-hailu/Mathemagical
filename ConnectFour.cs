using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public static class MyGlobals
    {
        public static Dictionary<string, int[]> gameStats = new Dictionary<string, int[]>
        {
             { "leftDiagonal" , new int[] { 0, 0, 0, 0, 0, 0 } },
             { "rightDiagonal", new int[] { 0, 0, 0, 0, 0, 0 } },
             { "vertical",      new int[] { 0, 0, 0, 0, 0, 0, 0 } }
        };
        public static bool gameOver = false;

    }
    public class Program
    {
        const int DEFAULT_ROW_SIZE = 6;
        const int DEFAULT_COL_SIZE = 7;

        const int DEFAULT_NUM_PLAYERS = 2;

        public static void Main(string[] args)
        {
            List<List<int>> board = new List<List<int>>();
            for (int i = 0; i < 7; i++)
            {
                List<int> temp = new List<int>();
                for (int j = 0; j < 6; j++)
                {
                    temp.Add(0);
                }
                board.Add(temp);
            }

            while (!MyGlobals.gameOver)
            {
                for (int pl = 1; pl <= DEFAULT_NUM_PLAYERS; pl++)
                {
                    RenderBoard(board);
                    var i = GetNextMove(pl);
                    try
                    {
                        var j = board[i].IndexOf(0);
                        board[i][j] = pl;
                        UpdateStats(i, j, pl);
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                    if (MyGlobals.gameOver)
                    {
                        RenderBoard(board);
                        Console.WriteLine("player {0} wins!!", pl);
                        Console.ReadKey();
                        return;
                    }
                }
            }
        }

        private static void UpdateStats(int i, int j, int player)
        {
            int right = i + 2 - j;
            int left = 8 - i - j;
            AddPoits("vertical", i, player);
            if ((right > -1 && right < 6) || (left > -1 && left < 6))
            {
                if (right > -1 && right < 6 && !MyGlobals.gameOver)
                    AddPoits("rightDiagonal", right, player);
                if (left > -1 && left < 6 && !MyGlobals.gameOver)
                    AddPoits("leftDiagonal", left, player);
            }
        }

        public static void AddPoits(string direction, int i, int player)
        {
            int currentPoint = MyGlobals.gameStats[direction][i];
            if (currentPoint > 0)
            {
                MyGlobals.gameStats[direction][i] +=
                    player == 2 ? 1 : -currentPoint - 1;
            }
            else if (currentPoint < 0)
            {
                MyGlobals.gameStats[direction][i] +=
                    player == 1 ? -1 : (-currentPoint + 1);
            }
            else
            {
                MyGlobals.gameStats[direction][i] +=
                   player == 1 ? -1 : 1;
            }
            var points = Math.Abs(MyGlobals.gameStats[direction][i]);
            MyGlobals.gameOver = points == 4 ? true : false;
        }
        private static int GetNextMove(int player)
        {
            Console.WriteLine("Player {0}'s turn", player);
            Console.WriteLine("Enter column number 1-7 :");
            string input = Console.ReadLine();
            int colmNumber;
            Int32.TryParse(input, out colmNumber);
            return colmNumber - 1;
        }

        private static void RenderBoard(List<List<int>> board)
        {
            Console.Clear();
            Console.WriteLine(" =                           =");
            Console.WriteLine(" -----------------------------");
            for (int i = 5; i >= 0; i--)
            {
                string rowLine = " | ";
                for (int j = 0; j <= 6; j++)
                {
                    if (board[j][i] != 0)
                        rowLine += board[j][i] == 1 ? "1 | " : "2 | ";
                    else
                        rowLine += "  | ";
                }
                Console.WriteLine(rowLine);
                Console.WriteLine(" -----------------------------");

            }
            Console.WriteLine(" ==                         ==");
            //Console.ReadKey();
        }
    }
}
