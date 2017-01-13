using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace EntryPoint
{
    class Node
    {
        private Vector2 _vec2;   
        private Node _left;    
        private Node _right;
        private Tuple<Vector2, Vector2> _tup;
                                    
        public Node(Vector2 v)     
        {                           
            _vec2 = v;       
        }           

        public Vector2 Vec2
        {
            get { return _vec2; }
            set { _vec2 = value; }
        }

        public Node Right  
        {               
            get { return _right; }   
            set { _right = value; }  
        }
           
        public Node Left      
        {     
            get { return _left; }        
            set { _left = value; }    
        }

        public Tuple<Vector2, Vector2> Tup
        {
            get { return _tup; }
            set { _tup = value; }
        }
    }
}    