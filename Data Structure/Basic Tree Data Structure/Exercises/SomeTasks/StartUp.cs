
using System;
using System.Collections.Generic;
using System.Linq;


public class StartUp
{
    static Dictionary<int, Tree<int>> treeNodes = new Dictionary<int, Tree<int>>();

    public static void Main(string[] args)
    {
        ReadTree();
        Tree<int> root = RootRead();


        //07 Task Problem 7.	All Paths With a Given Sum
        var targetSum = int.Parse(Console.ReadLine());
        Console.WriteLine($"Paths of sum {targetSum}:");
        var leaves = GetPathWithGivenSum(root, targetSum);
        foreach (var leaf in leaves)
        {
            PrintPath(leaf);
        }

        //08 Task All Subtrees With a Given Sum
        
        Console.WriteLine($"Subtrees of sum {targetSum}:");
        var subtreeRoots = GetSubtreeWithSum(root, targetSum);

        foreach (var node in subtreeRoots)
        {
            PrintPreOrder(node);
            Console.WriteLine();
        }


    }
    //08
    private static List<Tree<int>> GetSubtreeWithSum(Tree<int> root, int targetSum)
    {
        List<Tree<int>> roots = new List<Tree<int>>();

        int sum = DfsTrees(root, targetSum, 0, roots);

        return roots;
    }

    //08
    private static int DfsTrees(Tree<int> node, int targetSum, int currentSum, List<Tree<int>> roots)
    {

        if (node == null)
        {
            return 0;
        }

        currentSum = node.Value;

        foreach (var child in node.Children)
        {
            currentSum += DfsTrees(child, targetSum, currentSum, roots);
        }

        if (currentSum == targetSum)
        {
            roots.Add(node);
        }

        return currentSum;
    }
    //08
    private static void PrintPreOrder(Tree<int> node)
    {
        Console.Write(node.Value + " ");
        foreach (var child in node.Children)
        {
            PrintPreOrder(child);
        }

    }
    //07
    private static void PrintPath(Tree<int> leaf)
    {
        Stack<int> stack = new Stack<int>();
        Tree<int> current = leaf;

        while (current != null)
        {
            stack.Push(current.Value);
            current = current.Parent;
        }


        Console.WriteLine(string.Join(" ", stack.ToArray()));
    }
    //07
    private static List<Tree<int>> GetPathWithGivenSum(Tree<int> root, int targetSum)
    {
        List<Tree<int>> leaves = new List<Tree<int>>();

        //find with dfs leaves and check sum
        FindLeavesAndCheckSumWithDfs(root, targetSum, 0, leaves);

        return leaves;
    }

    //07
    private static void FindLeavesAndCheckSumWithDfs(Tree<int> currentNode, int targetSum, int currentSum, List<Tree<int>> leaves)
    {
        if (currentNode == null)
        {
            return;
        }

        currentSum += currentNode.Value;

        foreach (var currentNodeChild in currentNode.Children)
        {
            FindLeavesAndCheckSumWithDfs(currentNodeChild, targetSum, currentSum, leaves);
        }

        if (currentSum == targetSum && currentNode.Children.Count == 0)
        {
            leaves.Add(currentNode);
        }
    }

    //06
    private static void PrintLongestPath(Tree<int> root)
    {
        
        Tree<int> deepest = PrintDeepestNodeDFS(root);

        Stack<int> stack =new Stack<int>();
        stack.Push(deepest.Value);

        while (deepest.Parent != null)
        {

            var current = deepest.Parent;
            stack.Push(current.Value);
           
            deepest.Parent = current.Parent;
        }

        Console.WriteLine($"Longest path: {string.Join(" ",stack)}");
    }



    //06
    private static Tree<int>  PrintDeepestNodeDFS(Tree<int> root) //Using DFS
    {
        int maxLevel = 0;
        Tree<int> deepest = null;

        DFS(root, 0, ref maxLevel, ref deepest);

        return deepest;
       

    }
    //06
    private static void DFS(Tree<int> node, int level, ref int maxLevel, ref Tree<int> deepest)
    {
        if (node == null)
        {
            return;
        }
        if (level > maxLevel)
        {
            deepest = node;
            maxLevel = level;
        }
        foreach (var child in node.Children)
        {
            DFS(child, level + 1, ref maxLevel, ref deepest);
        }
    }

    //05
    private static void PrintDeepestNode(Tree<int> root)//Using BFS
    {
        Queue<Tree<int>> queue = new Queue<Tree<int>>();
        queue.Enqueue(root);
        Tree<int> current = null;

        while (queue.Count > 0)
        {
            current = queue.Dequeue();

            for (int i = current.Children.Count - 1; i >= 0; i--)
            {
                queue.Enqueue(current.Children[i]);
            }
        }

        Console.WriteLine($"Deepest node: {current.Value}");

    }

    //04
    private static void PrintMiddleNodes()
    {
        var result = treeNodes.Values
            .Where(c => c.Parent != null && c.Children.Count != 0)
            .Select(c => c.Value)
            .OrderBy(x => x)
            .ToList();

        Console.WriteLine($"Middle nodes: {string.Join(" ", result)}");
    }
    //03
    private static void PrintAllLeafs()
    {

        var result = treeNodes.Values
            .Where(c => c.Children.Count == 0)
            .Select(s => s.Value)
            .OrderBy(x => x).ToList();

        Console.WriteLine($"Leaf nodes: {string.Join(" ", result)}");
    }
    //01
    private static Tree<int> RootRead()
    {
        return treeNodes.Values.FirstOrDefault(c => c.Parent == null);

    }
    //02
    private static void ReadTree()
    {
        int tops = int.Parse(Console.ReadLine());


        for (int i = 0; i < tops - 1; i++)
        {
            int[] nodes = Console.ReadLine().Split().Select(int.Parse).ToArray();



            Tree<int> parent = GetNode(nodes[0]);
            Tree<int> child = GetNode(nodes[1]);

            parent.Children.Add(child);
            child.Parent = parent;


        }
    }

    private static Tree<int> GetNode(int value)
    {
        if (!treeNodes.ContainsKey(value))
        {
            treeNodes[value] = new Tree<int>(value);
        }
        return treeNodes[value];
    }
}

