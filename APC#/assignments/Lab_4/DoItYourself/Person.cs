namespace DoItYourself;

public class Person
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"{this.GetType.Name}[name={Name}, email={Email}]";
    }
}
