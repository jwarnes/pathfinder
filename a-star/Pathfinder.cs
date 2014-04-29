using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a_star
{
    public static class Pathfinder
    {
        public static float heuristic(Node start, Node end, float cost = 1.0f)
        {
            //basic euclidian distance
            var dx = start.x - end.x;
            var dy = start.y - end.y;
            return (float)Math.Sqrt(dx*dx + dy *dy) * cost;
        }

        public static List<Node> findPath(Node start, Node end)
        {
            var open = new List<Node>();
            var closed = new List<Node>();
            var current = start;
            Node test;
            List<Node> connected;
            var cost = 1.0f;
            float g, h, f;

            current.g = 0;
            current.h = Pathfinder.heuristic(current, end, cost);
            current.f = current.g + current.h;
            int l, i;

            while(current != end)
            {
                connected = current.connected;
                l = connected.Count;

                for(i=0; i< l; ++i)
                {
                    test = connected[i];
                    if (test == current || test.obstacle) continue;

                    g = current.g + cost;
                    h = heuristic(test, end, cost);
                    f = g + h;

                    if(open.Contains(test) || closed.Contains(test))
                    {
                        if(test.f > f)
                        {
                            test.f = f;
                            test.g = g;
                            test.h = h;
                            test.parent = current;
                        }
                    }
                    else
                    {
                        test.f = f;
                        test.g = g;
                        test.h = h;
                        test.parent = current;
                        open.Add(test);
                    }

                }
                closed.Add(current);
                if (open.Count == 0) // no path found
                    return new List<Node>();
                open = open.OrderBy(n => n.f).ToList();
                current = open[0];
                open.RemoveAt(0);
            }

            //build waypoint list
            return buildPath(end, start);
        }

        public static List<Node> buildPath(Node end, Node start)
        {
            var path = new List<Node>();
            var node = end;
            path.Add(node);
            while(node != start)
            {
                node = node.parent;
                path.Insert(0, node);
            }
            return path;
        }
    }
    
}
