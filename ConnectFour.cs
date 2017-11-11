/*
  Author: Dawit Hailu
  objective:
    A C# script for a 7x6 two player Connect4 game
    
  check it out in action! simply go to the link and click run. 
  repl: https://repl.it/OEIN/5
  
  contact: davucan@gmail.com
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public static class MyGlobals
    {
        //A dictionary of arrays for game stats
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
        //constants to set game environtment
        const int DEFAULT_ROW_SIZE = 6;
        const int DEFAULT_COL_SIZE = 7;

        const int DEFAULT_NUM_PLAYERS = 2;

        //create a list of lists(7x6) and initialize values to zero 
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
            //game starts here
            while (!MyGlobals.gameOver)
            {
                //for number of player each has one turn
                for (int pl = 1; pl <= DEFAULT_NUM_PLAYERS; pl++)
                {
                    //display board based on values of our list
                    RenderBoard(board);

                    //get column number from player pl(player enters a number between 1 and 7 both inclusive, of course.)
                    var i = GetNextMove(pl);
                    try
                    {
                        //get next empty cell on column choosen
                        var j = board[i].IndexOf(0);
                        //populate cell with players number(1 or 2 !_this programm solves a two players problem, but, its scaleable 
                                                                  //!__to n number of players)
                        board[i][j] = pl;
                        //update gameStats dictionary based on cell number
                        UpdateStats(i, j, pl);
                    }
                    catch (Exception e)
                    {
                        //print error message
                        Console.WriteLine(e.Message);
                    }
                    if (MyGlobals.gameOver)
                    {
                        //display grid based on game status
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
            //this number expresses the cells on the six diagonal lines to the right, winning is possible
            int right = i + 2 - j;
            //this number expresses the cells on the six diagonal lines to the left, winning is possible
            int left = 8 - i - j;
            //add poits to the vertical variable in gameStats dictionary 
            AddPoits("vertical", i, player);

            //check if either diagonal is 
          
                if (right > -1 && right < 6 && !MyGlobals.gameOver)
                    AddPoits("rightDiagonal", right, player);
                if (left > -1 && left < 6 && !MyGlobals.gameOver)
                    AddPoits("leftDiagonal", left, player);
            
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
            
            //this line is to clear screen on repl.it so, can be removed for a local run
            for(int i=0;i<55;i++){Console.WriteLine("");}
            
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
        }
    }
}
