using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace ClassLibrary1
{
    public abstract class Shape
    {
        public abstract Vector3 Center { get; }

        public abstract float Area { get; }

        public static Shape GenerateShape()
        {
            var rand = new Random();

            int shapeIndex = rand.Next(0, 7);
            var radius = (float)(rand.NextDouble() * rand.Next(1, 50));

            var center = new Vector3(rand.Next(0, 100), rand.Next(0, 100), rand.Next(0, 100));
            var size = new Vector3(rand.Next(1, 100), rand.Next(0, 100), rand.Next(0, 100));
            
            switch (shapeIndex)
            {
                case 0:
                    return new Circle(new Vector2(center.X, center.Y), radius);
                case 1:
                    return new Rectangle(new Vector2(center.X, center.Y), new Vector2(size.X, size.Y));
                case 2:
                    return new Rectangle(new Vector2(center.X, center.Y), radius * 2);
                case 3:                
                    var vertex1 = new Vector2(rand.Next(0, 100), rand.Next(0, 100));
                    var vertex2 = new Vector2(rand.Next(0, 100), rand.Next(0, 100));

                    while (vertex1 == vertex2)
                        vertex2 *= (float)rand.NextDouble();

                    var vertex3 = new Vector2(rand.Next(0, 100), rand.Next(0, 100));

                    while (((Vector2.Normalize(vertex3) == Vector2.Normalize(vertex1)) && 
                        (Vector2.Normalize(vertex3) == Vector2.Normalize(vertex2))) ||
                        (vertex3 == vertex1 || vertex3 == vertex2))
                        vertex3 *= (float)rand.NextDouble();

                    return new Triangle(vertex1, vertex2, vertex3);
                case 4:                   
                    return new Cuboid(center, size);
                case 5:
                    return new Cuboid(center, radius * 2);
                case 6:
                    return new Sphere(center, radius);
            }
            return null;
        }

        public static Shape GenerateShape(Vector3 center)
        {
            var rand = new Random();
            int shapeIndex = rand.Next(0, 7);
            float radius = rand.Next(1, 50);

            var size = new Vector3(rand.Next(1, 100), rand.Next(0, 100), rand.Next(0, 100));
            
            switch (shapeIndex)
            {
                case 0:
                    return new Circle(new Vector2(center.X, center.Y), radius);
                case 1:
                    return new Rectangle(new Vector2(center.X, center.Y), new Vector2(size.X, size.Y));
                case 2:
                    return new Rectangle(new Vector2(center.X, center.Y), radius * 2);
                case 3:    
                    var sumVertices = new Vector2(center.X, center.Y) * 3f;

                    var vertex1 = new Vector2(rand.Next(0, 100), rand.Next(0, 100));
                    var vertex2 = new Vector2(rand.Next(0, 100), rand.Next(0, 100));

                    while (vertex1 == vertex2)
                        vertex2 *= (float)rand.NextDouble();

                    var vertex3 = sumVertices - vertex1 - vertex2;

                    return new Triangle(vertex1, vertex2, vertex3);
                case 4:
                    return new Cuboid(center, size);
                case 5:
                    return new Cuboid(center, radius * 2);
                case 6:
                    return new Sphere(center, radius);
            }
            return null;
        }
    }
}
