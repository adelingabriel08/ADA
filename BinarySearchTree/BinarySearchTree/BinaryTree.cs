using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    public class BinaryTree
    {
        private Node _root;
        private List<int> _InorderValues;

        public BinaryTree()
        {
            _root = null;
            _InorderValues = new List<int>();
        }

        public void Insert(int number)
        {
            if (_root == null)
            {
                _root = new Node(number);
                return;
            }

            InsertNode(_root, new Node(number));
        }

        private void InsertNode(Node root, Node newNode)
        {
            if (root == null)
                root = newNode;

            if (newNode.Number < root.Number)
            {
                if (root.Left == null)
                {
                    root.Left = newNode;
                    root.Left.Parent = root;
                }
                else
                    InsertNode(root.Left, newNode);
            }
            else
            {
                if (root.Right == null)
                {
                    root.Right = newNode;
                    root.Right.Parent = root;
                }
                else
                    InsertNode(root.Right, newNode);
            }
        }

        private void PrintTree(Node root)
        {
            if (root == null) return;

            PrintTree(root.Left);
            System.Console.Write(root.Number + " ");
            PrintTree(root.Right);
        }

        public void Print()
        {
            PrintTree(_root);
        }

        private int findDepth(Node node)
        {
            int counter = 0;
            while (node != null)
            {
                counter++;
                node = node.Left;
            }

            return counter;
        }

        private bool isPerfectRec(Node root, int counter, int level)
        {
            if (root == null)
                return true;

            if (root.Left == null && root.Right == null)
                return (counter == level + 1);

            if (root.Left == null || root.Right == null)
                return false;

            return isPerfectRec(root.Left, counter, level++) && isPerfectRec(root.Right, counter, level++);
        }

        public bool IsPerfectlyBalanced()
        {
            int d = findDepth(_root);
            return isPerfectRec(_root, d, 0);
        }

        private Node SearchClosestNode(Node node, Node closestNode, int valueToSearch)
        {
            if (node == null)
                return closestNode;

            if (node.Number == valueToSearch)
                return node;

            var closest = Math.Abs(closestNode.Number - valueToSearch) > Math.Abs(node.Number - valueToSearch)
                ? node
                : closestNode;

            if (node.Number < valueToSearch)
                return SearchClosestNode(node.Right, closest, valueToSearch);

            return SearchClosestNode(node.Left, closest, valueToSearch);
        }

        public Node SearchClosest(int valueToSearch)
        {
            if (_root is null)
                return null;
            return SearchClosestNode(_root, _root, valueToSearch);
        }

        private int NumberOfNodes(Node root)
        {
            if (root is null)
                return 0;
            return NumberOfNodes(root.Right) + NumberOfNodes(root.Left);
        }

        private void Inorder(Node root)
        {
            if (_InorderValues.Count > 0 && _root == root)
                _InorderValues.Clear();
            if (root is null)
                return;
            Inorder(root.Left);
            _InorderValues.Add(root.Number);
            Inorder(root.Right);
        }

        public bool CheckExistTwoNodesWithSum(int sum)
        {
            var numberOfNodes = NumberOfNodes(_root);
            Inorder(_root);
            var inorderList = _InorderValues;
            var i = 0;
            var j = inorderList.Count - 1;
            inorderList.Sort();
            while (i != j)
            {
                if (inorderList[i] + inorderList[j] == sum)
                    return true;
                if (inorderList[i] + inorderList[j] > sum)
                    j--;
                else
                    i++;
            }

            return false;
        }

        public void PrintInorder()
        {
            Console.WriteLine(_InorderValues);
        }
    }
}