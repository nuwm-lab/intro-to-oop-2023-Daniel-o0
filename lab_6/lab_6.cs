public abstract class Workers
{
    
    protected string Fname;
    protected string Lname;
    protected string Uname;

    public string f_name { get; set; }
    public string l_name { get; set; }
    public string u_name { get; set; }

    public Workers()
    {
        f_name = "";
        l_name = "";
        u_name = "";
    }
    public Workers(string Fname, string Lname, string Uname)
    {
        f_name = Fname;
        l_name = Lname;
        u_name = Uname;
    }

    public abstract void Print();

    public bool Symetriya()
    {
        int length = l_name.Length;
        string Lname = l_name.ToLower();
        for (int i = 0; i < length / 2; i++)
        {
            if (Lname[i] != Lname[length - 1 - i]) return false;
        }
        return true;
    }
}

public class Practicant : Workers
{
    public Practicant(string Fname, string Lname, string Uname) : base(Fname, Lname, Uname)
    {}
    public override void Print()
    {
        Console.WriteLine($"Name and LName: {f_name} {l_name}");
        Console.WriteLine($"The name of the university: {u_name}");
    }
}


public class Pracivnuk : Workers
{
    protected DateTime dateOfEmployment;
    protected string Posada;

    public DateTime DateOfEmployment { get; set; }
    public string posada { get; set; }

    public Pracivnuk() : base()
    {
        DateOfEmployment = DateTime.MinValue;
        posada = "";
    }

    public Pracivnuk(string Fname, string Lname, string Uname, DateTime dateOfEmployment, string Posada) : base(Uname, Lname, Uname)
    {
        DateOfEmployment = new DateTime(dateOfEmployment.Year, dateOfEmployment.Month, dateOfEmployment.Day);
        posada = Posada;
    }

    public override void Print()
    {
        Console.WriteLine($"\nName and LName: {f_name} {l_name}");
        Console.WriteLine($"The date pruynatya on job: {DateOfEmployment.ToShortDateString()}");
        Console.WriteLine($"Posada: {posada}");
    }

    public void StashRobotu()
    {
        DateTime current = DateTime.Now;
        int month = (current.Year - DateOfEmployment.Year) * 12+ current.Month - DateOfEmployment.Month+ (DateOfEmployment.Day <= current.Day ? 0 : -1);
        Console.WriteLine($"Work experience {month / 12} year {month % 12} month");
    }
}


class Program
{
    static void Main(string[] args)
    {
        Practicant practicant = new Practicant("Lyudmila", "Oraro", "Vodnik");
        practicant.Print();

        if (practicant.Symetriya())
            Console.WriteLine("Last name symetrichne");
        else
            Console.WriteLine("Last name symetrichne");

        Pracivnuk pracivnuk = new Pracivnuk("Dada", "Oraro", "Maroko", DateTime.Parse("10.01.2019"), "Teacher");
        pracivnuk.Print();
        pracivnuk.StashRobotu();
        Console.WriteLine("\n");
    }
}
