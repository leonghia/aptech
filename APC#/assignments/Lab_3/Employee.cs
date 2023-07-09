namespace Lab_3;

public class Employee
{
    private string firstName;
    private string lastName;
    private string address;
    private long sin;
    private double salary;

    public Employee(string firstName, string lastName, string address, long sin, double salary)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.address = address;
        this.sin = sin;
        this.salary = salary;
    }

    public override string ToString()
    {
        return $"firstName={firstName}, lastName={lastName}, address={address}, sin={sin}, salary={salary}";
    }

    public double CalcBonus(double percentage)
    {
        return salary * percentage;
    }
}
