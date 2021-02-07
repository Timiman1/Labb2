using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Labb2_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            ConsoleKey response;

            do
            {
                Console.Write("Do you want to specify a center point for all generated shapes? [y/n] ");
                response = Console.ReadKey(false).Key;

                if (response != ConsoleKey.Enter)
                    Console.WriteLine();

            } while ((response != ConsoleKey.Y) && (response != ConsoleKey.N));

            if (response == ConsoleKey.Y)
            {
                float x;
                float y;
                float z;

                Console.Write("Center X: ");

                while (!float.TryParse(Console.ReadLine(), out x))
                {
                    Console.WriteLine("Not a number! Try again.");
                    Console.Write("Center X: ");
                }

                Console.Write("Center Y: ");

                while (!float.TryParse(Console.ReadLine(), out y))
                {
                    Console.WriteLine("Not a number! Try again.");
                    Console.Write("Center Y: ");
                }

                Console.Write("Center Z: ");

                while (!float.TryParse(Console.ReadLine(), out z))
                {
                    Console.WriteLine("Not a number! Try again.");
                    Console.Write("Center Z: ");
                }

                Console.WriteLine($"\nGenerating 20 shapes @({x}, {y}, {z}):");

                for (int i = 0; i < 20; i++)
                    shapes.Add(Shape.GenerateShape(new Vector3(x, y, z)));
            }
            else
            {
                Console.WriteLine("\nGenerating 20 shapes with random center points:");

                for (int i = 0; i < 20; i++)
                    shapes.Add(Shape.GenerateShape());
            }

            float triangleCircSum = 0f;
            float best3DVolume = 0f;
            float sumAreas = 0f;

            Shape3D best3DShape = null;

            for (var i = 0; i < 20; i++)
            {
                Shape shape = shapes[i];

                Console.WriteLine($"{i + 1}: {shape.ToString()}");

                if (shape is Triangle)
                {
                    var triangle = shape as Triangle;
                    triangleCircSum += triangle.Circumference;

                    foreach(var v in triangle)
                        Console.WriteLine(v);
                }

                if (shape is Shape3D)
                {
                    var shape3D = shape as Shape3D;

                    if (best3DVolume < shape3D.Volume)
                    {
                        best3DVolume = shape3D.Volume;
                        best3DShape = shape3D;
                    }
                }

                sumAreas += shape.Area;
            }
            Console.WriteLine($"\nSum of all triangle circumerances: {triangleCircSum}");

            Console.WriteLine($"The avarage area of all 20 shapes: {sumAreas / 20f}");

            Console.WriteLine($"The 3D shape with the biggest volume: {best3DShape.ToString()}, Volume = {best3DVolume}");

            Console.ReadKey();
        }
    }
}
