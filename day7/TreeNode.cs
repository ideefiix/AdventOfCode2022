namespace day7;

public class TreeNode
{
    public TreeNode Parent { get; set; }
    public List<TreeNode> Children { get; set; }
    public int Value { get; set; } // Directories have value = 0
    public string Name { get; set; } 

    public TreeNode(int value, string name, TreeNode? parent = null)
    {
        Parent = parent;
        Children = new List<TreeNode>();
        Value = value;
        Name = name;
    }

    public void AddChild(TreeNode child)
    {
        Children.Add(child);
    }

    public int ValueInDirectory()
    {
        if (this.Value != 0) throw new ArgumentException("TreeNode is not a directory!");
        
        int value = 0;
        foreach (var child in this.Children)
        {
            if (child.Value == 0)
            {
                value += child.ValueInDirectory();
            }
            else
            {
                value += child.Value;
            }
        }

        return value;
    }
    
}