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
    
}