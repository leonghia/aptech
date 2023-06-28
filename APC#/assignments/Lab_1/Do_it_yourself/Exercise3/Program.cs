// See https://aka.ms/new-console-template for more information
bool isInputValid = false;
while (!isInputValid)
{
    Console.Write("Enter a number from 1 to 7: ");
    string input = Console.ReadLine();
    byte number;
    bool success = byte.TryParse(input, out number);
    if (success && number >= 1 && number <= 7)
    {
        string day = "";
        switch (number)
        {
            case 1:
                day = "Monday";
                break;
            case 2:
                day = "Tuesday";
                break;
            case 3:
                day = "Wednesday";
                break;
            case 4:
                day = "Thursday";
                break;
            case 5:
                day = "Friday";
                break;
            case 6:
                day = "Saturday";
                break;
            case 7:
                day = "Sunday";
                break;
        }
        Console.WriteLine(day);
        isInputValid = true;
    }
    else
    {
        Console.WriteLine("Invalid number, please enter again");
    }
}
