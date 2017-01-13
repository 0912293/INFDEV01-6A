using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace EntryPoint
{
    class GraphNode
    {
        private List<Edgy> _connections;
        private Tuple<Vector2,Vector2> _tuple;
        private double _distance;
        private List<GraphNode> _testPath;
        private double _bigBoned;  

        public List<Edgy> Connections
        {
            get { return _connections; }
        }

        public Tuple<Vector2, Vector2> Tuple
        {
            get { return _tuple; }
            set { _tuple = value; }
        }

        public double Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }

        public List<GraphNode> TestPath
        {
            get { return _testPath; }
            set { _testPath = value; }
        }
        public double BigBoned
        {
            get { return _bigBoned; }
            set { _bigBoned = value; }
        }

        public GraphNode(Tuple<Vector2,Vector2> tuple)
        {
            _tuple = tuple;
            _connections = new List<Edgy>();
        }

        public void AddConnection(GraphNode targetNode, double distance)
        {
            if (targetNode == null) throw new ArgumentNullException("¯\\_(ツ)_/¯");
            if (targetNode == this) throw new ArgumentException("( ͡° ͜ʖ ͡°)");
            if (distance < 0) throw new ArgumentException("Soon™");

            _connections.Add(new Edgy(targetNode, distance));
//            if (twoWay) targetNode.AddConnection(this, distance, false);
        }
    }
}
