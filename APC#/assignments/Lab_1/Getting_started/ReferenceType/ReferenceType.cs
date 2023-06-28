using System;

class ReferenceType
{
    public int valueVal;

}

class TestReference
{
    static void Main(string[] args)
    {
        ReferenceType refer = new ReferenceType();
        refer.valueVal = 5;
        Test(refer);
        Console.WriteLine("The value of the variable is {0}", refer.valueVal);
        Console.ReadLine();
    }

    static void Test(ReferenceType refer)
    {
        int temp = 5;
        refer.valueVal = temp * 2;
    }
}