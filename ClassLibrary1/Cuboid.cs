using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Cuboid : Shape3D
    {
        private readonly Vector3 _size;

        public override Vector3 Center { get; }

        public override float Area
        {
            get
            {
                return (2 * ((_size.Z * _size.X) + (_size.X * _size.Y) + (_size.Y * _size.Z)));
            }
        }

        public override float Volume { get; }

        public bool IsCube 
        {
            get 
            {
                return ((_size.X == _size.Y) && (_size.X == _size.Z)); 
            }
        }

        public Cuboid(Vector3 center, Vector3 size)
        {
            _size = size; 
            Center = center;
            Volume = (size.X * size.Y * size.Z);        
        }

        public Cuboid(Vector3 center, float width)
        {
            _size = new Vector3(width, width, width); 
            Center = center;
            Volume = (width * width * width);
        }

        public override string ToString()
        {
            return $"cuboid @({Center.X}, {Center.Y}, {Center.Z}): w = {_size.X}, h = {_size.Y}, l={_size.Z}” (cube == {IsCube})";
        }
    }
}
