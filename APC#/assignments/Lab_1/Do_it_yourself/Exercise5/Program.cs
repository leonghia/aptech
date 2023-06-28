// See https://aka.ms/new-console-template for more information

for (int i = 1; i < 11; i++)
{
    Console.WriteLine($"{i}! = {Factorial(i)}");
}

static int Factorial(int n)
{
    // base case: n = 0 or n = 1;
    if (n == 0 || n == 1)
    {
        return 1;
    }
    else
    {
        return n * Factorial(n - 1);
    }
}
