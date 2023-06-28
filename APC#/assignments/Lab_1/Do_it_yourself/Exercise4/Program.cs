// See https://aka.ms/new-console-template for more information
bool isInputValid = false;
while (!isInputValid)
{
    Console.Write("Enter n: ");
    string input = Console.ReadLine();
    Int16 number;
    bool success = Int16.TryParse(input, out number);
    if (success)
    {
        for (int i = 0; i < 10; i++)
        {
            Int32 result = number * (i + 1);
            Console.WriteLine($"{number} x {i + 1} = {result}");
        }
        isInputValid = true;
    }
    else
    {
        Console.WriteLine("Invalid number");
    }
}
