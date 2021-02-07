using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.ComponentModel;
using System.Collections;

namespace ClassLibrary1
{
    public class Triangle : Shape2D, IEnumerator<Vector2>, IEnumerable<Vector2> 
    {
        private readonly Vector2 _p1;
        private readonly Vector2 _p2;
        private readonly Vector2 _p3;

        private int currentIndex = -1;
        private List<Vector2> verticesList;

        public Vector2 Current
        {
            get
            {
                return verticesList[currentIndex];
            }
        }

        public override Vector3 Center { get; }

        public override float Area
        {
            get
            {
                return (_p1.X * (_p2.Y - _p3.Y) + _p2.X * (_p3.Y - _p1.Y) + _p3.X * (_p1.Y - _p2.Y)) / 2f;
            }
        }

        public override float Circumference
        {
            get 
            { 
                return (Vector2.Distance(_p1, _p2) + Vector2.Distance(_p1, _p3) + Vector2.Distance(_p2, _p3)); 
            }
        }

        object IEnumerator.Current => verticesList[currentIndex];

        public Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            _p1 = p1;
            _p2 = p2;
            _p3 = p3; 
            Vector2 centroid = (p1 + p2 + p3) / 3f;
            Center = new Vector3(centroid.X, centroid.Y, 0);
            verticesList = new List<Vector2>() { p1, p2, p3 };
        }

        public override string ToString()
        {
            return $"triangle @({Center.X}, {Center.Y}): p1({_p1.X}, {_p1.Y}), p2({_p2.X}, {_p2.Y}), p3({_p3.X}, {_p3.Y})";
        }

        public void Dispose()
        {
            verticesList = null;
        }

        public bool MoveNext()
        {
            currentIndex++;
            return (currentIndex < verticesList.Count);
        }

        public void Reset()
        {
            currentIndex = -1;
        }

        public IEnumerator<Vector2> GetEnumerator()
        {
            return verticesList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return verticesList.GetEnumerator();
        }
    }
}
