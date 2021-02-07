using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Sphere : Shape3D
    {
        private readonly float _radius;

        public override Vector3 Center { get;  }

        public override float Area { get; }

        public override float Volume { get; }

        public Sphere(Vector3 center, float radius)
        {
            _radius = radius;
            Center = center;
            Area = (float)(4 * Math.PI * Math.Pow(_radius, 2));
            Volume = (float)(0.75d * Math.PI * Math.Pow(radius, 3));
        }

        public override string ToString()
        {
            return $"sphere @({Center.X}, {Center.Y}, {Center.Z}): r = {_radius}";
        }
    }
}
