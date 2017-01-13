using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace EntryPoint
{
    class Dijkstur
    {
        private Graphity _graph = new Graphity();
        private Vector2 _start = new Vector2();
        private List<Edgy> edge;
        private List<Tuple<Vector2, Vector2>> _datList = new List<Tuple<Vector2, Vector2>>();  
        private double inf = double.MaxValue;
        private LinkedList<GraphNode> nextNode = new LinkedList<GraphNode>();



        public Dijkstur(Graphity graph, Vector2 start)
        {
            _graph = graph;
            _start = start;             
        }

        public List<Tuple<Vector2, Vector2>> GetDatList()
        {
           return _datList; 
        }

        public void hurrdurr(Graphity graph, Vector2 start)
        {
            List<Tuple<Vector2, Vector2>> prev = new List<Tuple<Vector2, Vector2>>();
            Dictionary<Tuple<Vector2,Vector2>,double> dist = new Dictionary<Tuple<Vector2, Vector2>, double>();
            Dictionary<Tuple<Vector2, Vector2>, GraphNode> nodes = new Dictionary<Tuple<Vector2, Vector2>, GraphNode>();
            
            int q = 0;
            int counter = 0;
            bool test = false;
            Console.WriteLine("start");

            foreach (var i in graph.Nodes)
            {                                
                Console.WriteLine("almost");
                if (i.Key.Item1 == start)
                {
                    dist.Add(i.Key, 0);
                    prev.Add(i.Key);
                    nextNode.AddFirst(graph.Nodes[i.Key]);
                    _datList.Add(i.Key);
                }
                else
                {
                    dist.Add(i.Key, inf);
                }
                nodes.Add(i.Key,i.Value);
            }
            Console.WriteLine("maybe?");
            var current = nextNode.First;
            current.Value.TestPath = new List<GraphNode> {current.Value}; 
              
            while (nodes.Count != 0)
            {                                                  
//                if (current.Value.Tuple.Item2 == )
//                {
//                }

                var currentNode = current.Value;        
                if (prev.Contains(currentNode.Tuple))
                {
                    current= current.Next;
                    nextNode.RemoveFirst();   
                }

                prev.Add(currentNode.Tuple);

                foreach (var i in currentNode.Connections)
                {
//                    var bigBoned = i.Distance;
//                     if(bigBoned < i.)
//                    Console.WriteLine(counter++);
//                    double wtf = dist[i.Key];
//                    Console.WriteLine(wtf);
//                    if (_datList[q].Item2 == i.Key.Item1)
//                    {
//                        dist[i.Key] = i.Value.Distance;
//                    }
//                    if (dist[i.Key] < i.Value.Distance)
//                    {
//                        test = true;
//                        _datList[q+1] = i.Key;
//                        nodes.Remove(i.Key);
//                        Console.WriteLine("\\o/");
//                    }          
                }
                if (test)
                {
                    q++;
                    test = false;
                }         
            }                
        }
    }
}
