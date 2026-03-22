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
        equipment.Status = "Wypozyczone";
        _wypozyczenia.Add(new Wypozyczenie
        {
            User = user,
            Equipment = equipment,
            DataWypozyczenia = DateTime.Now,
            TerminZwrotu =  DateTime.Now.AddDays(days),
        });
    }

    public void Zwrot(Guid EquipmentId)
    {
        var wypozyczenie = _wypozyczenia.FirstOrDefault(w => w.Id == EquipmentId &&  !w.CzyZwrocona)
            ?? throw new Exception("Nie znaleziono aktywnego wypożyczenia dla tego sprzętu");

        wypozyczenie.DataZwrotu = DateTime.Now;
        wypozyczenie.Equipment.IsAvailable = true;
        wypozyczenie.Equipment.Status = "Available";

        if (wypozyczenie.DataZwrotu > wypozyczenie.TerminZwrotu)
        {
            var dniSpoznienia = (wypozyczenie.DataZwrotu.Value - wypozyczenie.TerminZwrotu).Days;
            Console.WriteLine("Kara za opóźnienie: " +  dniSpoznienia + "zł");
        }
    }

    public void EquipmentOff(Guid EquipmentId)
    {
        var equipment = _equipments.FirstOrDefault(e => e.Id == EquipmentId)
            ?? throw new Exception("Nie znaleziono takiego sprzętu");
        equipment.IsAvailable = false;
        equipment.Status = "W serwisie";
    }
}