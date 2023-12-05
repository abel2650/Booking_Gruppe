namespace Booking_Gruppe.model;

public class User
{
    private int _id;
    private string _name;
    private string _pass;
    private bool _isAdmin;

    //public int Id { get; set; }
    public int Id { get { return _id; } set { _id = value; } }
    public string Name { get { return _name; } set { _name = value; } }
    public string Pass { get { return _pass; } set { _pass = value; } }
    public bool IsAdmin { get { return _isAdmin; }  set { _isAdmin = value; } }


    public User()
    {
        _id = 0;
        _name = "";
        _pass = "";
        _isAdmin = false;
    }

    public User(int id, string name, string pass, bool isAdmin)
    {
        _id = id;
        _name = name;
        _pass = pass;
        _isAdmin = isAdmin;
    }

    public override string ToString()
    {
        return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Pass)}={Pass}, {nameof(IsAdmin)}={IsAdmin.ToString()}}}";
    }
}
