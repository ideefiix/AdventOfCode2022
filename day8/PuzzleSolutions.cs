namespace day8
{
    public class PuzzleSolutions
    {
        private string[] lines;
        private int forrestWidth;
        private int forrestHeight;

        public PuzzleSolutions()
        {
            //Read input
            lines = System.IO.File.ReadAllLines(@"C:\Users\flind\Desktop\AdventOfCode2022\day8\input.txt");
            forrestWidth = lines[0].Length;
            forrestHeight = lines.Length;
        }
        public void PrintPuzzle1Solution()
        {
            //Create matrix
            int[,] forrest = new int[forrestWidth,forrestHeight];

            for (int y = 0; y < forrestHeight; y++)
            {
                for (int x = 0; x < forrestWidth; x++)
                {
                    forrest[x, y] = (int)Char.GetNumericValue(lines[y][x]); 
                }
            }
            //Find visible trees
            int visibleTrees = 0;

            for (int y = 0; y < forrestHeight; y++)
            {
                for (int x = 0; x < forrestWidth; x++)
                {
                    if (TreeIsVisible(x, y, forrest)) visibleTrees++;
                }
            }

            Console.WriteLine("There are " + visibleTrees + " trees visible!");

        }

        public bool TreeIsVisible(int x, int y, int[,] forrest)
        {
            //Border checks
            if (x == 0 || x == forrestWidth - 1) return true;
            if (y == 0 || y == forrestHeight - 1) return true;

            //Look up 
            for (int y2 = y - 1; y2 >= 0; y2--)
            {
                if (forrest[x, y2] < forrest[x, y])
            Console.WriteLine("WOHO");
                {
                    return true;
                }
            }
            //Look down
            for (int y2 = y + 1; y2 < forrestHeight; y2++)
            {
                if (forrest[x, y2] < forrest[x, y])
                {
                    return true;
                }
            }
            //Look left 
            for (int x2 = x - 1; x2 >= 0; x2--)
            {
                if (forrest[x2, y] < forrest[x, y])
                {
                    return true;
                }
            }
            //Look right
            for (int x2 = x + 1; x2 < forrestWidth; x2++)
            {
                if (forrest[x2, y] < forrest[x, y])
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}