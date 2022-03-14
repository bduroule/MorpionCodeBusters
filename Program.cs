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
            while (true)
            {
                inputs = Console.ReadLine().Split(' ');
                if (inputs.Length != 2) {
                    Console.WriteLine("invalid input, you have to enter: x y");
                    continue ;
                }
                Console.WriteLine(inputs.Length);
                if (int.TryParse(inputs[0], out int x) && int.TryParse(inputs[1], out int y)) {
                    if (FellTab(MorpionGrid, x, y) == true)
                        MorpionGrid[x][y] = 'X';
                    Console.WriteLine($"{x}, {y}");

                    CheckWinCondition(MorpionGrid, null, 'X');
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
            for (int i = 0; i < 2; i++) {
                if (Grid[i].Where(e => e == Player).ToArray().Length == 2 && Array.FindIndex(Grid[i], ) != -1)
                    Console.WriteLine("coucou ca marche");
            }
            return false;
        }
    }
}