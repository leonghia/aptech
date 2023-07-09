using GeometricObjectDemo;

public class Program
{
    static void Main(string[] args)
    {
        Circle c1 = new Circle(2.45, "Blue", 23);
        Console.WriteLine("Circle before change: " + c1.ToString());

        //using properties
        c1.PColor = "red";
        c1.PWeight = 2.56;

        Console.WriteLine("Circle after change: " + c1.ToString());
        Console.ReadLine();
    }
}
