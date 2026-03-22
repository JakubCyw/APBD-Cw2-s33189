namespace APBD_Cw2_s33189;

public abstract class User
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Surname { get; set; }
    public abstract int MaxWypozyczenia { get; }
}

public class Student : User
{
    public override int MaxWypozyczenia => 2;
}

public class Employee : User
{
    public override int MaxWypozyczenia => 5;
}