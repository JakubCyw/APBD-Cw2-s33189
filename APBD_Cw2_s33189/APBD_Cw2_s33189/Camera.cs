namespace APBD_Cw2_s33189;

public class Camera : Equipment
{
    public int Zoom { get; set; }
    public string Type { get; set; }

    public Camera(string name, string sn, int zoom, string type) : base(name, sn)
    {
        Zoom = zoom;
        Type = type;
    }    
}