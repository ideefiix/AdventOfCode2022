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

    public void PrintPuzzle2Solution()
    {
        int stepsToClosest_a = 1000;
        CreateGraph(); 
        Console.WriteLine("Graph created!");

        foreach (var node in graph)
        {
            if (node.alltitude == 'a' ) 
            {
                sourceNode = node;
                RefreshGraphAndRefillPQ();
                FindShortestPath();
                if (targetNode.distanceToSource < stepsToClosest_a)
                {
                    stepsToClosest_a = targetNode.distanceToSource;
                    Console.WriteLine("New shortest distance to a " + stepsToClosest_a);
                }

            }
        }
        Console.WriteLine("Shortest distance from any a is " + stepsToClosest_a);
        
    }

    public void RefreshGraphAndRefillPQ()
    {
        pq = new StablePriorityQueue<Node>((mapHeight * mapWidth) + 10);
        foreach (var node in graph)
        {
            node.distanceToSource = 9999;
            pq.Enqueue(node,node.distanceToSource);
        }

        sourceNode.distanceToSource = 0;
        pq.UpdatePriority(sourceNode, 0);
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
            if (node.alltitude >= neighbour.alltitude || neighbour.alltitude - node.alltitude == 1)
            {
                node.neighbours.Add(neighbour);
            }
        }

        //Look down
        if (node.y != mapHeight - 1)
        {
            Node neighbour = graph.Find(n => n.x == node.x && n.y == node.y + 1);
            if (node.alltitude >= neighbour.alltitude || neighbour.alltitude - node.alltitude == 1)
            {
                node.neighbours.Add(neighbour);
            }
        }

        //Look left
        if (node.x != 0)
        {
            Node neighbour = graph.Find(n => n.x == node.x - 1 && n.y == node.y);
            if (node.alltitude >= neighbour.alltitude || neighbour.alltitude - node.alltitude == 1)
            {
                node.neighbours.Add(neighbour);
            }
        }

        //Look right
        if (node.x != mapWidth - 1)
        {
            Node neighbour = graph.Find(n => n.x == node.x + 1 && n.y == node.y);
            if (node.alltitude >= neighbour.alltitude || neighbour.alltitude - node.alltitude == 1)
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
    }
    
    /*
 * Creates a broadcast search from the Target node
 * In order to avoid endless loops we use a ttl
 */
    //Bad idea. STACK OVERFLOW
    /*private void FindClosest_a_InGraph(int ttl, int jumps, Node startNode)
    {
        if (ttl == 0) return;

        if (startNode.alltitude == 'a')
        {
            if (jumps < stepsToClosest_a)
            {
                stepsToClosest_a = jumps;
                Console.WriteLine("New shortest distance to a " + stepsToClosest_a);
            }
        }

        foreach (Node neighbour in startNode.neighbours)
        {
            FindClosest_a_InGraph(--ttl, ++jumps, neighbour);
        }
    }*/
}