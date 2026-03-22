using APBD_Cw2_s33189;

public class Program
{
    public static void Main(string[] args)
    {
        Serwis serwis = new Serwis();
        
        Console.WriteLine("Dodawanie danych");

        var laptop = new Laptop("MSI 1", "SN1", "i7", 16);
        var projektor = new Projector("Epson 1", "SN1", 1080, "duzy");
        var kamera = new Camera("Sony 1", "SN1", 8, "retro");
        
        serwis.AddEquipment(laptop);
        serwis.AddEquipment(projektor);
        serwis.AddEquipment(kamera);
        
        var student = new Student {Name = "Patryk", Surname = "Kowalski"};
        var pracownik = new Employee {Name = "Adam", Surname = "Nowak"};
        
        serwis.AddUser(student);
        serwis.AddUser(pracownik);
        
        Console.WriteLine("Wypożyczenie");
        try
        {
            serwis.Wypozycz(student, laptop, 7);
            Console.WriteLine($"Student {student.Name} wypożyczył {laptop.Name}");
        }
        catch (Exception e)
        {
            Console.WriteLine("Błąd: " + e.Message);
        }
        
        Console.WriteLine("Wypożyczenie z niepowodzeniem");
        try
        {
            serwis.Wypozycz(pracownik, laptop, 3);
        }
        catch (Exception e)
        {
            Console.WriteLine("Błąd: " + e.Message);
        }
        
        Console.WriteLine("Zwrot sprzetu");
        try
        {
            serwis.Zwrot(laptop.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        Console.WriteLine("Raport");
        serwis.Raport();
    }
}