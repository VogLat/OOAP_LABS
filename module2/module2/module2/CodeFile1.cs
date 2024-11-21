namespace FactoryMethodExample
{
    public abstract class Shape
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Shape(double x, double y)
        {
            X = x;
            Y = y;
        }

        public abstract double CalculateArea();
        public abstract void DisplayColor();
        public abstract (double, double) GetCenterOfCircumscribedCircle();
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double x, double y, double radius) : base(x, y)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override void DisplayColor()
        {
            Console.WriteLine("Color: Blue");
        }

        public override (double, double) GetCenterOfCircumscribedCircle()
        {
            return (X, Y);
        }
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double x, double y, double width, double height) : base(x, y)
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override void DisplayColor()
        {
            Console.WriteLine("Color: Red");
        }

        public override (double, double) GetCenterOfCircumscribedCircle()
        {
            return (X + Width / 2, Y + Height / 2);
        }
    }

    public abstract class ShapeFactory
    {
        public abstract Shape CreateShape();
    }

    public class CircleFactory : ShapeFactory
    {
        private double _radius;

        public CircleFactory(double radius)
        {
            _radius = radius;
        }

        public override Shape CreateShape()
        {
            return new Circle(0, 0, _radius);
        }
    }

    public class RectangleFactory : ShapeFactory
    {
        private double _width, _height;

        public RectangleFactory(double width, double height)
        {
            _width = width;
            _height = height;
        }

        public override Shape CreateShape()
        {
            return new Rectangle(0, 0, _width, _height);
        }
    }
}