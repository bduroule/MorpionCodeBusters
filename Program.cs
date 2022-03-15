using System;
using System.Threading.Tasks;
using System.Linq;

namespace Morpion
{
    class Program
    {
        static void Main(string[] args)
        {
            char?[][] MorpionGrid = new char?[3][] {new char?[3] {null, null, null}, new char?[3] {null, null, null}, new char?[3] {null, null, null}};
            string[] inputs;
            var OCord = new Cord(-1, -1);

            while (true)
            {
                inputs = Console.ReadLine().Split(' ');
                if (inputs.Length != 2) {
                    Console.WriteLine("invalid input, you have to enter: x y");
                    continue ;
                }
                if (int.TryParse(inputs[0], out int x) && int.TryParse(inputs[1], out int y)) {
                    if (FellTab(MorpionGrid, x, y) == true)
                        MorpionGrid[x][y] = 'X';
                    if (CheckWinCondition(MorpionGrid, OCord, 'O'))
                        MorpionGrid[OCord.x][OCord.y] = 'O';
                    else if (CheckWinCondition(MorpionGrid, OCord, 'X'))
                        MorpionGrid[OCord.x][OCord.y] = 'O';
                }

                PrintGrid(MorpionGrid);
            }

        }

        static void PrintGrid(char?[][] Grid) 
        {
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (Grid[i][j] == null)
                        Console.Write('.');
                    else
                        Console.Write(Grid[i][j]);
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        static bool FellTab(char?[][] Grid, int x, int y)
        {
            if (x < 0 || x > 3 || y < 0 || y > 3)
                return false;
            if (Grid[x][y] != null)
                return false;
            return true;
        }

        static bool CheckWinCondition(char?[][] Grid, Cord cord, char Player) 
        {
            int searchPlayerPosition = 0;
            int searchEmptyPosition = 0;

            for (int i = 0; i < 2; i++) {
                if (Grid[i].Where(e => e == Player).ToArray().Length == 2 && Array.FindIndex(Grid[i], e => e == null) != -1) {
                    cord.x = i;
                    cord.y = Array.FindIndex(Grid[i], e => e == null);
                    return true;
                }
                if (Grid.Where(e => e[i] == Player).ToArray().Length == 2 && Array.FindIndex(Grid, e => e[i] == null) != -1) {
                    cord.x = Array.FindIndex(Grid, e => e[i] == null);
                    cord.y = i;
                    return true;
                }

                searchPlayerPosition = 2;
                searchEmptyPosition = 2;
                if (Grid.Where(x => x[searchPlayerPosition--] == Player).ToArray().Length == 2 && Array.FindIndex(Grid, x => x[searchEmptyPosition--] ==  null) != -1) {
                    searchPlayerPosition = 2;
                    cord.x = Array.FindIndex(Grid, x => x[searchPlayerPosition--] == null);
                    cord.y = 2 - cord.x;
                    Console.WriteLine("here 1");
                    return true;
                } 
                searchPlayerPosition = 0;
                searchEmptyPosition = 0;
                if (Grid.Where(x => x[searchPlayerPosition++] == Player).ToArray().Length == 2 && Array.FindIndex(Grid, x => x[searchEmptyPosition++] == null) != -1) {
                    searchPlayerPosition = 0;
                    cord.x = Array.FindIndex(Grid, x => x[searchPlayerPosition++] == null);
                    cord.y = cord.x;
                    Console.WriteLine("here 2");
                    return true;
                } 
            }

            return false;
        }
    }
}