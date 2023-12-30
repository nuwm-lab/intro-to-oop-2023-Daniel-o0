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

     public void Print()
     {
         Console.WriteLine($"Name:{f_name} {l_name}");
         Console.WriteLine($"Nazva university de practicant studies: {u_name}");
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
         Posada = "";
     }
     public Pracivnuk(string Fname, string Lname, string Uname, DateTime dateOfPracivnuk, string Posada) : base(Fname, Lname, Uname) 
     {
         DateOfPracivnuk = new DateTime(dateOfPracivnuk.Year, dateOfPracivnuk.Month, dateOfPracivnuk.Day);
         posada = Posada;
     }
     
     public void Print()
     {
         Console.WriteLine($"\nName: {f_name} {l_name}");
         Console.WriteLine($"Date pracivnuka in company: {DateOfPracivnuk.ToShortDateString()}");
         Console.WriteLine($"Posada: {posada}");
     }

     public void StashRobotu()
     {
         DateTime current = DateTime.Now;
         int month = (current.Year - DateOfPracivnuk.Year) * 12 + current.Month - DateOfPracivnuk.Month + (DateOfPracivnuk.Day <= current.Day ? 0 : -1);
         Console.WriteLine($"Stash robotu {month/12} year {month % 12} month");
     }
     }
 }

 internal class Program
 {
     static void Main(string[] args)
     {
         Practicant practicant = new Practicant("Lyudmila", "Oraro", "Vodnik");
         practicant.Print();
     if (practicant.Symetriya())
         Console.WriteLine("Last name symetrichne");
     else
         Console.WriteLine("Last name not symetrichne");

     Pracivnuk pracivnuk = new Pracivnuk("Dada", "Oraro", "Maroko", DateTime.Parse("10.01.2019"), "Teacher");
     pracivnuk.Print();
     pracivnuk.StashRobotu();
     }
