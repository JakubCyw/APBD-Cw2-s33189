namespace APBD_Cw2_s33189;

public class Projector : Equipment
{
    public int Resolution { get; set; }
    public string Size { get; set; }
    
    public Projector(string name, string sn, int res, string  size) : base(name, sn)
    {
        Resolution = res;
        Size = size;
    }
}