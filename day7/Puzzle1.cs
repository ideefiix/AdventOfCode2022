using System.Reflection.Metadata.Ecma335;

namespace day7;

public class Puzzle1
{
    public TreeNode root;
    public TreeNode currentDirectory;

    public Puzzle1()
    {
        root = new TreeNode(0, "/");
        currentDirectory = root;
    }

    public void PrintPuzzle1Solution()
    {
        string[] lines =
            System.IO.File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2022\day7\input.txt");
        lines[0] = "$ ls"; //This command is less annoying
        
        foreach (var line in lines)
        {
            
        }
        
    }

    public void InterpretLine(string line)
    {
        if (line[0] == '$') //Command
        {
            if(line.Substring(2,2) == "ls") return;

            if (line.Substring(5,2) == "..")
            {
                currentDirectory = currentDirectory.Parent;
            }
            else
            {
                string directoryName = line.Substring(5);
                TreeNode directory = currentDirectory.Children.Find(c => c.Name == directoryName); // Throws exception if none is found
                currentDirectory = directory;

            }
        }
        else //File
        {
            if (line.Substring(0,3) == "dir")
            {
                TreeNode child = new TreeNode(0, line.Substring(4));
                currentDirectory.AddChild(child);
            }
            else
            {
                string[] valAndName = line.Split(' ');
                TreeNode child = new TreeNode(Int32.Parse(valAndName[0]), valAndName[1]);
            }
        }
    }
}