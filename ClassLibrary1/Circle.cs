using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Circle : Shape2D
    {
        private readonly float _radius;

        public override Vector3 Center { get; }

        public override float Area
        {
            get
            {
                return (float)(Math.PI * Math.Pow(_radius, 2));
            }
        } 

        public override float Circumference
        {
            get 
            { 
                return (float)Math.PI * (_radius * 2); 
            }
        }

        public Circle(Vector2 center, float radius)
        {
            _radius = radius;
            Center = new Vector3(center.X, center.Y, 0);
        }

        public override string ToString()
        {
            return $"circle @({Center.X}, {Center.Y}): r = {_radius}";
        }
    }
}
