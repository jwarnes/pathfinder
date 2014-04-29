using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a_star
{
    public class Node
    {
        #region Fields
        public float f;
        public float g;
        public float h;
        public float x;
        public float y;
        public bool obstacle = false;
        public int id;
        public Node parent;
        public List<Node> connected = new List<Node>();
        #endregion

        public Node()
        {

        }
        public Node(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static void Connect(Node first, Node second)
        {
            first.connected.Add(second);
            second.connected.Add(first);
        }
        public static void Disconnect(Node first, Node second)
        {
            first.connected.Remove(second);
            second.connected.Remove(first);
        }
    }
}
