namespace APBD_Cw2_s33189;

public class Wypozyczenie
{
    public Guid Id { get; } = Guid.NewGuid();
    public User User { get; set; }
    public Equipment Equipment { get; set; }
    public DateTime DataWypozyczenia { get; set; }
    public DateTime? DataZwrotu { get; set; }
    public DateTime TerminZwrotu { get; set; }
    public bool CzyZwrocona { get; set; }
}