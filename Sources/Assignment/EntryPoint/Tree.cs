using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace EntryPoint
{
    class Tree
    {
        List<Vector2> nodeList = new List<Vector2>();
        private Node _rootNode = null;     
        public Tree(Vector2[]vec2)
        {       
            if (vec2 != null)  
            {
                foreach (Vector2 vec in vec2)
                {
                    Insert(vec);
                }                                  
            }             
        }           

        public void Insert(Vector2 vec2)       
        {               
            Node current = _rootNode; 
            Node previous = null;  
            bool hor = false;    
            bool useLeftSubtree = false;
                                           
            while (current != null)
            {                                
                previous = current;
                if (hor)
                {
                    if (useLeftSubtree = vec2.X < current.Vec2.X)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
                else
                {
                    if (useLeftSubtree = vec2.Y < current.Vec2.Y)
                        current = current.Left;  
                    else            
                        current = current.Right;        
                }
                hor = !hor;         
            }                   

            if (_rootNode == null)      
                _rootNode = new Node(vec2);    
            else                        
            {                      
                if (useLeftSubtree)  
                    previous.Left = new Node(vec2);  
                else                             
                    previous.Right = new Node(vec2);  
            }                
        }

        public List<Vector2> TraverseInOrder(Node node, Tuple<Vector2,float> i )
        {                        
            // note to self: Don't make new lists in a recursive method ( ._.)                         
            if (node != null)
            {                                              
                TraverseInOrder(node.Left, i);
                if (InRange(i,node))
                {        
                    nodeList.Add(node.Vec2);
                }
                TraverseInOrder(node.Right, i);
                if (InRange(i, node))
                {
                    nodeList.Add(node.Vec2);
                }    
            }     
            return nodeList; 
        }

        public IEnumerable<IEnumerable<Vector2>> Traverse(Tree root, IEnumerable<Tuple<Vector2, float>> housesAndDistances)
        {
            IEnumerable<IEnumerable<Vector2>> specialNodesArr;
            var specialNodes = new List<List<Vector2>>();
            List<Vector2> nodes = new List<Vector2>();
            if (root != null)
            {
                foreach (var item in housesAndDistances)
                {                                      
                    nodes = TraverseInOrder(root._rootNode, item);    
                    specialNodes.Add(nodes);
                }       
            }
            else
            {                                      
                specialNodesArr = specialNodes.ToArray();
                return specialNodesArr;
            }                       
            specialNodesArr = specialNodes.ToArray();
            return specialNodesArr;
        }

        public bool InRange(Tuple<Vector2,float> house , Node node)
        {
            double range = Dist.get_dist(house.Item1, node.Vec2);
            if (range < house.Item2)
            {
                return true;
            }
            else
            {
                return false;
            }      
        }

    }
}   

