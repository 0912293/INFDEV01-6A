using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace EntryPoint
{
    public class Dist
    {
        public static Double get_dist(Vector2 building, Vector2 house)
        {
            Double Distance;
            Distance = Math.Sqrt(Math.Pow(house.X - building.X, 2) + Math.Pow(house.Y - building.Y, 2));
            return Distance;
        }                        
    }
}
