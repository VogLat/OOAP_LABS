using System;

namespace FactoryMethodExample
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select shape to draw (1 for Circle, 2 for Rectangle, 0 to Exit): ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 0)
                    break;

                ShapeFactory shapeFactory = null;
                Shape shape = null;

      
                if (choice == 1)
                {
                    Console.WriteLine("Enter the radius of the circle: ");
                    double radius = double.Parse(Console.ReadLine());
                    shapeFactory = new CircleFactory(radius);
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter the width of the rectangle: ");
                    double width = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the height of the rectangle: ");
                    double height = double.Parse(Console.ReadLine());
                    shapeFactory = new RectangleFactory(width, height);
                }

                shape = shapeFactory.CreateShape();

                Console.WriteLine($"Shape created at ({shape.X}, {shape.Y})");
                Console.WriteLine($"Area: {shape.CalculateArea()}");
                shape.DisplayColor();
                var center = shape.GetCenterOfCircumscribedCircle();
                Console.WriteLine($"Center of circumscribed circle: ({center.Item1}, {center.Item2})\n");
            }
        }
    }
}
