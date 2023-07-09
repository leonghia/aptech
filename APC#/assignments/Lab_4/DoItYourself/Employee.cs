namespace DoItYourself;

public abstract class Employee
{
    public string Department { get; set; }
    public double Salary { get; set; }
    public DateTime Hired { get; set; }

    public abstract double CalculateBonus();

    public abstract int CalculateVacation();
}
