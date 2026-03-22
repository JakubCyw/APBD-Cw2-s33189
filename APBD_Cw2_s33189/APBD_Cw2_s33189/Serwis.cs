namespace APBD_Cw2_s33189;

public class Serwis
{
    private List<Equipment> _equipments = new();
    private List<User> _users = new();
    private List<Wypozyczenie> _wypozyczenia = new();
    
    public void AddEquipment(Equipment equipment) => _equipments.Add(equipment);
    public void AddUser(User user) => _users.Add(user);

    public void ViewAllEquipment()
    {
        _equipments.ForEach(s => Console.WriteLine($"{s.Id}: {s.Name} - {(s.IsAvailable ? "Dostępny" : "Zajęty")}"));
    }

    public void ViewAvailableEquipment()
    {
        _equipments.Where(s => s.IsAvailable).ToList().ForEach(s => Console.WriteLine($"{s.Id}: {s.Name}"));
    }

    public void Wypozycz(User user, Equipment equipment, int days)
    {
        if (!equipment.IsAvailable) throw new Exception("Sprzęt zajęty");
        
        int wypozyczeniaCount = _wypozyczenia.Count(w => w.User.Id == user.Id && !w.CzyZwrocona);

        if (wypozyczeniaCount >= user.MaxWypozyczenia) throw new Exception("Przekroczono limit wypożyczeń");
        
        equipment.IsAvailable = false;
        _wypozyczenia.Add(new Wypozyczenie
        {
            User = user,
            Equipment = equipment,
            DataWypozyczenia = DateTime.Now,
            TerminZwrotu =  DateTime.Now.AddDays(days),
        });
    }
}