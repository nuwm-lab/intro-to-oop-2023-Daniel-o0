public class Practicant
{
    private string Fname;
    private string Lname;
    private string Uname;

    public string f_name
    {
        get { return Fname; }
        set { Fname = value; }
    }
    public string l_name
    {
        get { return Lname; }
        set { Lname = value; }
    }
    public string u_name
    {
        get { return Uname; }
        set { Uname = value; }
    }

    public Practicant()
    {
        f_name = "";
        l_name = "";
        u_name = "";
    }
    public Practicant(string Fname, string Lname, string Uname)
    {
        f_name = Fname;
        l_name = Lname;
        u_name = Uname;
    }

    public virtual void Print()
    {
        Console.WriteLine($"Name:{f_name} {l_name}");
        Console.WriteLine($"The name of the university : {u_name}");
    }

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

public class Pracivnuk : Practicant
{
    private DateTime dateOfPracivnuk;
    private string Posada;

    public DateTime DateOfPracivnuk
    {
        get { return dateOfPracivnuk; }
        set { dateOfPracivnuk = value; }
    }
    public string posada
    {
        get { return Posada; }
        set { Posada = value; }
    }

    public Pracivnuk()
    {
        DateOfPracivnuk = DateTime.MinValue;
        posada = "";
    }
    public Pracivnuk(string Fname, string Lname, string Uname, DateTime dateOfPracivnuk, string Posada) : base(Fname, Lname, Uname)
    {
        DateOfPracivnuk = new DateTime(dateOfPracivnuk.Year, dateOfPracivnuk.Month, dateOfPracivnuk.Day);
        posada = Posada;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"The date pruynatya on job: {DateOfPracivnuk.ToShortDateString()}");
        Console.WriteLine($"Posada: {posada}");
        StashRobotu();
    }

    
    public void StashRobotu()
    {
        DateTime current = DateTime.Now;
        int month = (current.Year - DateOfPracivnuk.Year) * 12 + current.Month - DateOfPracivnuk.Month + (DateOfPracivnuk.Day <= current.Day ? 0 : -1);
        Console.WriteLine($"Stash robotu is: {month / 12} year {month % 12} month");
    }
}


class Program
{
    static void Main(string[] args)
    {
        int userSelect;
        Practicant baseObj;
        do
        {
            Console.WriteLine("\nEnter 1, if you want to work with Practicantom, or 2 - with Pracivnukom");
            Console.WriteLine("Enter 3 for End your work\n");
            userSelect = Convert.ToInt32(Console.ReadLine());
            
            switch (userSelect)
            {
                case 1:
                    {
                        string Fname, Lname, Uname;
                            Console.WriteLine("Practicant: ");
                            Console.Write("First name: ");
                        Fname = Console.ReadLine();
                            Console.Write("Last name: ");
                        Lname = Console.ReadLine();
                            Console.Write("University: ");
                        Uname = Console.ReadLine();

                        baseObj = new Practicant(Fname, Lname, Uname);
                        break;
                    }


                case 2:
                    {
                        string Fname, Lname, Uname, date, Posada;
                            Console.WriteLine("Pracivnuk: ");
                            Console.Write("First name: ");
                        Fname = Console.ReadLine();
                            Console.Write("Last name: ");
                        Lname = Console.ReadLine();
                            Console.Write("University: ");
                        Uname = Console.ReadLine();

                        bool validDate = false;
                        DateTime dateOfEmployment = DateTime.MinValue;

                        do
                        {
                            Console.Write("The date pruynatya on job (Day.Month.Year): ");
                            date = Console.ReadLine();

                            if (DateTime.TryParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfEmployment))
                            {
                                if (dateOfEmployment <= DateTime.Now)
                                {
                                    validDate = true;
                                }
                                else
                                {
                                    Console.WriteLine("Check your date.\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please use format like Day.Month.Year\n");
                            }
                        } while (!validDate);

                        Console.Write("Posada: ");
                        Posada = Console.ReadLine();

                        baseObj = new Pracivnuk(Fname, Lname, Uname, dateOfEmployment, Posada);
                        break;
                    }

                default:
                    return;
            }
            Console.WriteLine("\n");
            baseObj.Print();
            if (baseObj.Symetriya())
                Console.WriteLine("\nLast name symetrichne");
            else
                Console.WriteLine("\nLast name not symetrichne");

        } while (true);
    }
}
