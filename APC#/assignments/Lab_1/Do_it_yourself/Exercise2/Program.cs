// See https://aka.ms/new-console-template for more information


Console.WriteLine(FindMax(1998, 2004, 2003));

static int FindMax(int a, int b, int c)
{
    int max = a;
    if (b > max)
    {
        max = b;
    }
    if (c > max)
    {
        max = c;
    }
    return max;
}
