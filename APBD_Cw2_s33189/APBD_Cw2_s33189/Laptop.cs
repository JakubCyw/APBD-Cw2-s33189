namespace APBD_Cw2_s33189;

public class Laptop : Equipment
{
    public string Procesor { get; set; }
    public int Ram { get; set; }
    
    public Laptop(string name, string sn, string procesor, int ram) : base(name, sn)
    {
        Procesor = procesor;
        Ram = ram;
    }
}