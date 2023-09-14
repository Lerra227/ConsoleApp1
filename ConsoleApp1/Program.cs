
Console.WriteLine("Min/max vaiues of date types:");
Console.WriteLine("bool (true/false)\nbyte (0/255)\nsbyte (-128/127)");
Console.WriteLine($"short ({(long)Math.Pow(2, 15):N0}/ {(long)Math.Pow(2, 15) - 1:N0})\n" +
    $"ushort (0/{Math.Pow(2, 16) - 1:N0})\n" +
    $"int (-{Math.Pow(2, 31):N0}/{Math.Pow(2, 31) - 1:N0})\n" +
    $"uint (0/{Math.Pow(2, 32):N0})\n" +
    $"long ({Math.Pow(2, 63):N0}/{Math.Pow(2, 63) - 1:N0})\n" +
    $"ulong (0/{Math.Pow(2, 64):N0}\n" +
    $"decimal (+-{Math.Pow(10, -28)}/+-{Math.Pow(2, 96)})\n" +
    $"float (+-1,5*{Math.Pow(10, -45)}/+-{Math.Pow(2, 128)})\n" +
    $"double (+-5.0*{Math.Pow(10,-324)}/+-1.7*{Math.Pow(10, 308)})");




Console.Write("/////////////////////////////////////////////////////\n");



double side1, side2;
Console.WriteLine("Enter rectagular's sides");
Console.Write("Side 1 = ");
side1 = Convert.ToDouble(Console.ReadLine());
Console.Write("Side 2 = ");
side2 = Convert.ToDouble(Console.ReadLine());

var rec = new Rectangle(side1, side2);
double area = rec.Area;
double perimetr = rec.Perimeter;
Console.WriteLine("Area = " + area);
Console.WriteLine("Perimetr = " + perimetr);

Console.WriteLine("/////////////////////////////////////////////////\n");
var p1 = new Point(0, 1);
var p2 = new Point(2, 3);
var p3 = new Point(3, 4);
var p4 = new Point(4, 5);
var p5 = new Point(5, 6);

var triangle = new Figure(p1, p2, p3);
var quadrilateral = new Figure(p1, p2, p3, p4);
var pentagon = new Figure(p1, p2, p3, p4, p5);


var perim = triangle.PerimeterCalculator();
Console.WriteLine("Type = " + triangle.Type + "\nPerimeter = " + perim.ToString());
Console.WriteLine("Type = " + quadrilateral.Type + "\nPerimeter = " + quadrilateral.PerimeterCalculator().ToString());
Console.WriteLine("Type = " + pentagon.Type + "\nPerimeter = " + pentagon.PerimeterCalculator().ToString());







public class Rectangle
{
    double side1, side2;
    public Rectangle(double sideA, double sideB)
    {
        this.side1 = sideA;
        this.side2 = sideB;
    }
    private double CalculateArea()
    {
        return (this.side1 * this.side2);
    }
    double CalculatePerimeter()
    {
        return 2*(this.side2 + this.side1);
    }
    public double Area
    {
        get { return this.CalculateArea(); }
    }
    public double Perimeter
    {
        get { return this.CalculatePerimeter(); }
    }
}

public class Point
{
    int x, y;

    public int X
    { get { return x; } 
    }
    public int Y
    { get { return y; }
    }
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

}


public class Figure
{
    private Point p1, p2, p3, p4, p5;
    public Figure(Point p1, Point p2, Point p3)
    {
        this.p1 = p1;
        this.p2 = p2;
        this.p3 = p3;
        Type = "Triangle";
    }
    public Figure(Point p1, Point p2, Point p3, Point p4):this(p1, p2, p3)
    {
        this.p4 = p4;
        Type = "Quadrilateral";
    }

    public Figure(Point p1, Point p2, Point p3, Point p4, Point p5) : this(p1, p2, p3, p4)
    {
        this.p5 = p5;
        Type = "Pentagon";
    }

    public string Type { get; set; }
    double LengthSide(Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow((p1.X - p2.X),2) + Math.Pow((p1.Y - p2.Y),2));
    }

   public double PerimeterCalculator()
    {
        
        switch (Type)
        {
            case "Triangle": 
                var length = this.LengthSide(p1, p2) + this.LengthSide(p2, p3) + this.LengthSide(p3, p1);
                return length;
                break;

            case "Quadrilateral": return this.LengthSide(p1, p2) + this.LengthSide(p2, p3) + 
                    this.LengthSide(p3, p4) + this.LengthSide(p4, p1);
                break;
            case "Pentagon": return this.LengthSide(p1, p2) + this.LengthSide(p2, p3) + 
                    this.LengthSide(p3, p4) + this.LengthSide(p4, p5) + this.LengthSide(p5, p1);
                break;

            default: Console.WriteLine("Perimeter error");
                return 0;
                break;
        }
    }

}




