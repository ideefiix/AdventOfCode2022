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
           InterpretLine(line); 
        }

        int sum = SumSizeOfSmallDirectories(root);
        Console.WriteLine("The sum of all small directories are " + sum + "!");

    }
    
    public void PrintPuzzle2Solution()
    {
        string[] lines =
            System.IO.File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2022\day7\input.txt");
        lines[0] = "$ ls"; //This command is less annoying
        
        foreach (var line in lines)
        {
            InterpretLine(line); 
        }

        int diskAvailable = 70000000 - root.ValueInDirectory();
        int diskNeeded = 30000000 - diskAvailable;
        //Console.WriteLine("We need " + diskNeeded + " disk to update!");
        int sizeOfDirectoryToRemove = SizeOfDirectoryToRemove(diskNeeded);
        
        Console.WriteLine("The size of the directory to remove is " + sizeOfDirectoryToRemove + "!");

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
                TreeNode child = new TreeNode(0, line.Substring(4), currentDirectory);
                currentDirectory.AddChild(child);
            }
            else
            {
                string[] valAndName = line.Split(' ');
                TreeNode child = new TreeNode(Int32.Parse(valAndName[0]), valAndName[1]);
                currentDirectory.AddChild(child);
            }
        }
    }
    // Small directories has less than 100 000 bytes of size
    int SumSizeOfSmallDirectories(TreeNode node)
    {
        int totalValue = 0;
        foreach (var child in node.Children)
        {
            if (child.Value == 0)
            {
                if (child.ValueInDirectory() <= 100000)
                {
                    totalValue += child.ValueInDirectory();
                }

                totalValue += SumSizeOfSmallDirectories(child);
            }
        }
        return totalValue;
    }

    int SizeOfDirectoryToRemove(int diskNeeded)
    {
        List<int> directorySizes = new List<int>();
        
        FindAllDirectoriesOfSizeGreaterThan(diskNeeded, root, directorySizes);

        return directorySizes.Min();
    }

    void FindAllDirectoriesOfSizeGreaterThan(int size, TreeNode node, List<int> listToPopulate)
    {
        if (node.ValueInDirectory() > size)
        {
            listToPopulate.Add(node.ValueInDirectory());
        }
        
        foreach (var child in node.Children)
        {
            if (child.Value == 0)
            {
                FindAllDirectoriesOfSizeGreaterThan(size, child, listToPopulate);
            }
        }
       
        
    }
}