using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class Edgy
    {
        private GraphNode _target;
        private double _distance;
        private double _bigBoned;

        public GraphNode Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public double Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }

        public double BigBoned
        {
            get { return _bigBoned; }
            set { _bigBoned = value; }
        }

        public Edgy(GraphNode target, double distance)
        {
            Target = target;
            _distance = distance;
        }
    }
}
