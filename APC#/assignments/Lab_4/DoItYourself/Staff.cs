namespace DoItYourself;

public class Staff : Employee
{
    public string Title { get; set; }

    public override int CalculateVacation()
    {   
        int v = 0;
        if (DateTime.Today.Year - Hired.Year >= 5)
        {
            v = 4;
        }
        else
        {
            v = 3;
        }
        return v;
    }
}
