using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class Rectangle : Shape2D
    {
        private readonly float _height;
        private readonly float _width;

        public override Vector3 Center { get; }

        public override float Area
        {
            get { return (_width * _height); }
        }

        public override float Circumference
        {
            get { return 2 * (_height + _width); }
        }

        public bool IsSqure
        {
            get
            {
                return (_height == _width);
            }
        }

        public Rectangle(Vector2 center, Vector2 size)
        {
            _width = size.X;
            _height = size.Y;
            Center = new Vector3(center.X, center.Y, 0);           
        }

        public Rectangle(Vector2 center, float width)
        {
            _width = width;
            _height = width; 
            Center = new Vector3(center.X, center.Y, 0);          
        }

        public override string ToString()
        {
            return $"rectangle @({Center.X}, {Center.Y}): w = {_width}, h = {_height} (square == {IsSqure})";
        }
    }
}
