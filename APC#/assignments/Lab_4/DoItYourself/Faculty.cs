namespace DoItYourself;

public class Faculty : Employee
{
    public double OfficeHours { get; set; }
    public string Rank { get; set; }

    public override double CalculateBonus()
    {
        return 1000 + 0.05 * Salary;
    }

    public override int CalculateVacation()
    {
        int v = 0;
        if (DateTime.Today.Year - Hired.Year >= 3)
        {
            v = 5;
            if (Rank.Equals("Senior Lecturer"))
            {
                v += 1;
            }
        }
        return v;
    }
}
