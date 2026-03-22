namespace APBD_Cw2_s33189;

public abstract class Equipment
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; }
    public bool IsAvailable { get; set; } = true;
    public string SerialNumber { get; set; }

    protected Equipment(string name, string sn)
    {
        Name = name;
        SerialNumber = sn;
    }    
}