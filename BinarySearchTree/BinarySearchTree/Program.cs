
using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree();
            var root = new Node();
            
            tree.Insert(8);
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(7);
            tree.Insert(3);
            tree.Insert(15);
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(18);
            tree.Insert(22);

            Console.WriteLine("Balanced: " + tree.IsPerfectlyBalanced());
            Console.WriteLine("Closest node to 17: " + tree.SearchClosest(17).Number);
            Console.WriteLine("Closest node to 15: " + tree.SearchClosest(15).Number);
            Console.WriteLine("CheckExistTwoNodesWithSum(12): " + tree.CheckExistTwoNodesWithSum(12));
            


        }
    }
}