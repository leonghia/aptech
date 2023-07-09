using Lab_3;

class Program
{
    public static void Main1()
    {
        // declare a Car object reference named myCar
        Car myCar;
        // create a Car object, and assign its address to myCar
        System.Console.WriteLine("Creating a Car object and assigning " + "its memory location to myCar");
        myCar = new Car();

        // assign values to the Car object's fields using myCar
        myCar.make = "Toyota";
        myCar.model = "MR2";
        myCar.color = "black";
        myCar.yearBuilt = 1995;

        // display the field values using myCar
        System.Console.WriteLine("myCar details:");
        System.Console.WriteLine("myCar.make = " + myCar.make);
        System.Console.WriteLine("myCar.model= " + myCar.model);
        System.Console.WriteLine("myCar.color = " + myCar.color);
        System.Console.WriteLine("myCar.yearBuilt=" + myCar.yearBuilt);

        // call the methods using myCar
        myCar.Start();
        myCar.Stop();

        // declare another Car object reference and
        // create another Car object
        System.Console.WriteLine("Creating another Car object and" + "assigning its memory location to redPorsche");
        Car redPorsche = new Car();
        redPorsche.make = "Porsche";
        redPorsche.model = "Boxster";
        redPorsche.color = "red";
        redPorsche.yearBuilt = 2000;
        System.Console.WriteLine("redPorsche is a " + redPorsche.model);
        //change the object referenced by the myCar object //reference to the object referenced by redPorshe
        System.Console.WriteLine("Assigning redPorsche to  myCar");
        myCar = redPorsche;
        System.Console.WriteLine("myCar details:");
        System.Console.WriteLine("myCar.make = " + myCar.make);
        System.Console.WriteLine("myCar.model = " + myCar.model);
        System.Console.WriteLine("myCar.color = " + myCar.color);
        System.Console.WriteLine("myCar.yearBuilt = " + myCar.yearBuilt);
        // assign null to myCar (myCar will no longer reference 
        //an object)
        myCar = null;
        Console.ReadLine();
    }

    public static void Main(string[] args)
    {
        Employee e = new Employee("Nghia", "La", "Hanoi", 1998, 15.0);
        Console.WriteLine(e);
        Console.WriteLine(e.CalcBonus(0.2));
    }
}
