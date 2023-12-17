class GP
{
    private double a0;
    private double q;
    private double n;

    public GP(double A0, double Q, double N)
    {
        a0 = A0;
        q = Q;
        n = N;
    }
  
    public double Calc()
    {
        return a0 * Math.Pow(n, q - 1);
    }

    public void Display()
    {
        Console.Write("Введіть a0: ");
        a0 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть d: ");
        q = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть n: ");
        n = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\nГеометрична прогресія:");
        double current = a0;
        for (int i = 0; i < n+1; i++)
        {
            Console.Write(current + " ");
            current *= q;
        }
        Console.WriteLine(); 
    }
    public bool Check()
    {
        double last = Calc();
        double current = a0;

        for (int i = 0; i < n+1;i++)
        {
            current += q;
            if(last <= current)
            {
                return false;
            }
        }
        return true;
    }
}
class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        GP progr = new GP(0,0,0);
        progr.Display();

        bool Check = progr.Check();
        if( Check )
        {
            Console.WriteLine("\nОстанній елемент найбільший в пргресії");
        }
        else
        {
            Console.WriteLine("\nОстанній елемент не найбільший в пргресії");
        }
    }
}
