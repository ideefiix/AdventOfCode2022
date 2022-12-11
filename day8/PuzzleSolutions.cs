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
            lines = System.IO.File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2022\day8\input.txt");
            forrestWidth = lines[0].Length;
            forrestHeight = lines.Length;
        }

        public void PrintPuzzle1Solution()
        {
            //Create matrix
            int[,] forrest = new int[forrestWidth, forrestHeight];

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

        public void PrintPuzzle2Solution()
        {
            //Create matrix
            int[,] forrest = new int[forrestWidth, forrestHeight];

            for (int y = 0; y < forrestHeight; y++)
            {
                for (int x = 0; x < forrestWidth; x++)
                {
                    forrest[x, y] = (int)Char.GetNumericValue(lines[y][x]);
                }
            }
            
            int highestScenicScore = 0;

            for (int y = 0; y < forrestHeight; y++)
            {
                for (int x = 0; x < forrestWidth; x++)
                {
                    if (TreeScenicScore(x, y, forrest) > highestScenicScore) highestScenicScore = TreeScenicScore(x, y, forrest);
                }
            }

            Console.WriteLine("The highest scenicScore is: " + highestScenicScore + " !");
        }

        private int TreeScenicScore(int x, int y, int[,] forrest)
        {
            //Border checks
            if (x == 0 || x == forrestWidth - 1) return 0;
            if (y == 0 || y == forrestHeight - 1) return 0;
            
            int scoreUp = 0;
            int scoreDown = 0;
            int scoreLeft = 0;
            int scoreRight = 0;
            
            //Look up 
            for (int y2 = y - 1; y2 >= 0; y2--)
            {
                if (forrest[x, y2] >= forrest[x, y])
                {
                    scoreUp++;
                    break;
                }
                else
                {
                    scoreUp++;
                }
            }

            //Look down
            for (int y2 = y + 1; y2 < forrestHeight; y2++)
            {
                if (forrest[x, y2] >= forrest[x, y])
                {
                    scoreDown++;
                    break;
                }
                else
                {
                    scoreDown++;
                }
            }

            //Look left 
            for (int x2 = x - 1; x2 >= 0; x2--)
            {
                if (forrest[x2, y] >= forrest[x, y])
                {
                    scoreLeft++;
                    break;
                }
                else
                {
                    scoreLeft++;
                }
            }

            //Look right
            for (int x2 = x + 1; x2 < forrestWidth; x2++)
            {
                if (forrest[x2, y] >= forrest[x, y])
                {
                    scoreRight++;
                    break;
                }
                else
                {
                    scoreRight++;
                }
            }

            return scoreUp * scoreDown * scoreLeft * scoreRight;
        }

        public bool TreeIsVisible(int x, int y, int[,] forrest)
        {
            //Border checks
            if (x == 0 || x == forrestWidth - 1) return true;
            if (y == 0 || y == forrestHeight - 1) return true;

            bool visibleUp = true;
            bool visibleDown = true;
            bool visibleLeft = true;
            bool visibleRight = true;

            //Look up 
            for (int y2 = y - 1; y2 >= 0; y2--)
            {
                if (forrest[x, y2] >= forrest[x, y])
                {
                    visibleUp = false;
                    break;
                }
            }

            //Look down
            for (int y2 = y + 1; y2 < forrestHeight; y2++)
            {
                if (forrest[x, y2] >= forrest[x, y])
                {
                    visibleDown = false;
                    break;
                }
            }

            //Look left 
            for (int x2 = x - 1; x2 >= 0; x2--)
            {
                if (forrest[x2, y] >= forrest[x, y])
                {
                    visibleLeft = false;
                    break;
                }
            }

            //Look right
            for (int x2 = x + 1; x2 < forrestWidth; x2++)
            {
                if (forrest[x2, y] >= forrest[x, y])
                {
                    visibleRight = false;
                    break;
                }
            }

            if (visibleUp || visibleDown || visibleLeft || visibleRight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}