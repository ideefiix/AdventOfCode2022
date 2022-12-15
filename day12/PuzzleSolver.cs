namespace day12;

using Priority_Queue;

public class PuzzleSolver
{
    private List<Node> graph;
    private StablePriorityQueue<Node> pq;
    private Node targetNode;
    private Node sourceNode;
    int mapWidth;
    int mapHeight;
    private Node lastReadNeighbour;

    public PuzzleSolver()
    {
    }

    public void PrintPuzzle1Solution()
    {
        CreateGraph();
        Console.WriteLine("Graph created!");
        FindShortestPath();
        Console.WriteLine("Shortest path found!");
        Console.WriteLine("There is " + targetNode.distanceToSource + " steps to the target!");
    }

    public void CreateGraph()
    {
        string[] input =
            System.IO.File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2022\day12\input.txt");
        mapWidth = input[0].Length;
        mapHeight = input.Length;

        pq = new StablePriorityQueue<Node>((mapHeight * mapWidth) + 10);
        graph = new List<Node>();

        //Create nodes
        for (int i = 0; i < mapHeight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                Node node = new Node();
                node.x = j;
                node.y = i;
                node.alltitude = input[i][j];
                node.neighbours = new List<Node>();
                node.distanceToSource = 9999;
                node.previous = null;
                if (input[i][j] == 'S')
                {
                    node.distanceToSource = 0;
                    node.alltitude = 'a';
                    sourceNode = node;
                }
                else if (input[i][j] == 'E')
                {
                    node.alltitude = 'z';
                    targetNode = node;
                }

                graph.Add(node);
                pq.Enqueue(node, node.distanceToSource);
            }
        }

        //Create connections
        foreach (var node in graph)
        {
            AddNeighbours(node);
        }
    }

    private void FindShortestPath()
    {
        while (pq.Count > 0)
        {
            Node node = pq.Dequeue();
            if (node == targetNode) break;

            foreach (var neighbour in node.neighbours)
            {
                int distToNeighbour = node.distanceToSource + 1;
                    if (distToNeighbour < neighbour.distanceToSource)
                    {
                        neighbour.distanceToSource = distToNeighbour;
                        neighbour.previous = node;
                        pq.UpdatePriority(neighbour, distToNeighbour);
                        lastReadNeighbour = neighbour;
                    }
                
            }
        }
    }

    private void AddNeighbours(Node node)
    {
        //Look up
        if (node.y != 0)
        {
            Node neighbour = graph.Find(n => n.x == node.x && n.y == node.y - 1);
            if (Math.Abs(node.alltitude - neighbour.alltitude) < 2)
            {
                node.neighbours.Add(neighbour);
            }
        }

        //Look down
        if (node.y != mapHeight - 1)
        {
            Node neighbour = graph.Find(n => n.x == node.x && n.y == node.y + 1);
            if (Math.Abs(node.alltitude - neighbour.alltitude) < 2)
            {
                node.neighbours.Add(neighbour);
            }
        }

        //Look left
        if (node.x != 0)
        {
            Node neighbour = graph.Find(n => n.x == node.x - 1 && n.y == node.y);
            if (Math.Abs(node.alltitude - neighbour.alltitude) < 2)
            {
                node.neighbours.Add(neighbour);
            }
        }

        //Look right
        if (node.x != mapWidth - 1)
        {
            Node neighbour = graph.Find(n => n.x == node.x + 1 && n.y == node.y);
            if (Math.Abs(node.alltitude - neighbour.alltitude) < 2)
            {
                node.neighbours.Add(neighbour);
            }
        }
    }

    class Node : StablePriorityQueueNode
    {
        public int x;
        public int y;
        public char alltitude;
        public List<Node> neighbours;
        public int distanceToSource;
        public Node previous;
    }
}