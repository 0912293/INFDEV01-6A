using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace EntryPoint
{
    class Graphity
    {
        private Dictionary<Tuple<Vector2, Vector2>, GraphNode> _nodes;

        public Dictionary<Tuple<Vector2, Vector2>, GraphNode> Nodes
        {
            get { return _nodes; }
            set { _nodes = value; }
        }

        public Graphity()
        {
            _nodes = new Dictionary<Tuple<Vector2, Vector2>, GraphNode>();
        }

        public void AddNode(Tuple<Vector2,Vector2> tup)
        {
            var node = new GraphNode(tup);
            _nodes.Add(tup, node);
        }

        public void AddConnection(Tuple<Vector2, Vector2> fromNode, Tuple<Vector2, Vector2> toNode, double distance)
        {
            _nodes[fromNode].AddConnection(_nodes[toNode], distance);
        }
    }
}
