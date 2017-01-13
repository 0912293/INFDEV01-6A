using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EntryPoint
{
    class MatrixCreatrix
    {
        Graphity graph = new Graphity();
        List<Tuple<Vector2, Vector2>> pleasework;
        public MatrixCreatrix(Vector2 start, Vector2 end, IEnumerable<Tuple<Vector2, Vector2>> roads)
        {
            IEnumerable<Tuple<Vector2, Vector2>> RoadsRange;
            Double distance = Dist.get_dist(start, end);
            RoadsRange = InRange(distance, roads,start,end);
            int q = 0;   
            foreach (var i in RoadsRange)
            {
                q++;                
                graph.AddNode(i);   
                  
            }
            Console.WriteLine(q);
            foreach (var i in RoadsRange)
            {
                foreach (var j in RoadsRange)
                {
                    if (i != j)
                    {
                        if (i.Item2 == j.Item1)
                        {
                            graph.AddConnection(i, j, GetDistDing(j.Item2,end));
                        }
                    }
                }     
            }                          
            Dijkstur dk = new Dijkstur(graph,start);
            dk.hurrdurr(graph,start);
            pleasework = dk.GetDatList(); 
        }

        public List<Tuple<Vector2, Vector2>> PleaseWork
        {
            get { return PleaseWork; }

        }

        public double GetDistDing(Vector2 start, Vector2 end)
        {                                                         
            return Dist.get_dist(start, end);
        }               

        public IEnumerable<Tuple<Vector2, Vector2>> InRange(Double dist, IEnumerable<Tuple<Vector2, Vector2>> roads, Vector2 start, Vector2 end)
        {
            IEnumerable<Tuple<Vector2, Vector2>> RoadsInRange;
            var roadlist = new List<Tuple<Vector2, Vector2>>();
            foreach (var i in roads)
            {
                if (Dist.get_dist(i.Item1, start) < dist && Dist.get_dist(i.Item2, end) < dist || Dist.get_dist(i.Item2, start) < dist && Dist.get_dist(i.Item2, end) < dist)
                {
                    roadlist.Add(i);
                }                                                        
            }
            RoadsInRange = roadlist;
            return RoadsInRange;  
        }                                

    }     
}
