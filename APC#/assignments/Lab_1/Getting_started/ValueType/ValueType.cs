using System;
using System.Text;

class Example1
{
    static void Main(string[] args)
    {
        int valueVal = 5;
        Test(valueVal);
        Console.WriteLine("The value of the variable is {0}", valueVal);
        Console.ReadLine();
    }

    static void Test(int valueVal)
    {
        int temp = 5;
        valueVal = temp * 2;
    }
}