using System.Drawing;

namespace BinarySearchTree
{
    public class Node
    {
        public int Number { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Parent { get; set; }

        public Node()
        {
            
        }
        

        public Node(int number)
        {
            Number = number;
        }
    }
}