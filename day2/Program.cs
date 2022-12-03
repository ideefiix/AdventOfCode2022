Console.WriteLine("The answer for puzzle1 is: " + Puzzle1Solution() + " points");
Console.WriteLine("The answer for puzzle2 is: " + Puzzle2Solution() + " points");

static int Puzzle1Solution()
{
    int total_score = 0;
    string[] lines = System.IO.File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2022\day2\input.txt");

    /*char myShape= Char.Parse(lines[0].Substring(2, 1));
    char enemyShape = Char.Parse(lines[0].Substring(0, 1));
    Console.WriteLine("Characters " + myShape + " " + enemyShape + " was selected");*/
    
    foreach (string line in lines)
    {
        char myShape= Char.Parse(line.Substring(2, 1));
        char enemyShape = Char.Parse(line.Substring(0, 1));

        total_score += ShapeScore(myShape);
        total_score += OutcomeScore(myShape, enemyShape);

    }
    
    return total_score;
}

static int Puzzle2Solution()
{
    int total_score = 0;
    string[] lines = System.IO.File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2022\day2\input.txt");

    /*char myShape= Char.Parse(lines[0].Substring(2, 1));
    char enemyShape = Char.Parse(lines[0].Substring(0, 1));
    Console.WriteLine("Characters " + myShape + " " + enemyShape + " was selected");*/
    
    foreach (string line in lines)
    {
        char enemyShape = Char.Parse(line.Substring(0, 1));
        char outcome = Char.Parse(line.Substring(2, 1));

        char myShape = SelectShape(enemyShape, outcome);

        total_score += ShapeScore(myShape);
        total_score += OutcomeScore(myShape, enemyShape);

    }
    
    return total_score;
}

static int ShapeScore(char shape)
{
    if (shape == 'X')
    {
        return 1;
    }else if (shape == 'Y')
    {
        return 2;
    }else if (shape == 'Z')
    {
        return 3;
    }
    else
    {
        throw new ArgumentException("Unrecognized shape!");
    }
}

static int OutcomeScore(char myShape, char enemyShape)
{
    if ((myShape == 'X' && enemyShape == 'A') || (myShape == 'Y' && enemyShape == 'B') 
       || (myShape == 'Z' && enemyShape == 'C')) //DRAW 
    {
        return 3;
    }

    switch (myShape)
    {
        case 'X':
            if (enemyShape == 'B')
            {
                return 0;
            }else if (enemyShape == 'C')
            {
                return 6;
            } 
            break;
        case 'Y':
            if (enemyShape == 'A')
            {
                return 6;
            }else if (enemyShape == 'C')
            {
                return 0;
            } 
            break;
        case 'Z':
            if (enemyShape == 'B')
            {
                return 6;
            }else if (enemyShape == 'A')
            {
                return 0;
            } 
            break;
                
    }

    throw new ArgumentException("Unrecognized Shape in OutcomeScore");
}

static char SelectShape(char enemyShape, char outcome)
{
    switch (enemyShape)
    {
        case 'A':
            if (outcome == 'X')
            {
                return 'Z';
            }else if (outcome == 'Y')
            {
                return 'X';
            }
            else if (outcome == 'Z')
            {
                return 'Y';
            }
            break;
        case 'B':
            if (outcome == 'X')
            {
                return 'X';
            }else if (outcome == 'Y')
            {
                return 'Y';
            }
            else if (outcome == 'Z')
            {
                return 'Z';
            }
            break;
        case 'C':
            if (outcome == 'X')
            {
                return 'Y';
            }else if (outcome == 'Y')
            {
                return 'Z';
            }
            else if (outcome == 'Z')
            {
                return 'X';
            }
            break;
    }

    throw new ArgumentException("Weird inputs in SelectShape");

}

