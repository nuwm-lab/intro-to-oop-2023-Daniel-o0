class GP
{

    double a0;
    double q;
    double n;

    public byte[] data;

    public GP()
    {
        a0 = 1;
        q = 1;
        n = 1;
    }

    public GP(double a0, double q, double n)
    {
        this.a0 = a0;
        this.q = q;
        this.n = n;
    }
    public void InputCoord(double va0, double vq, double vn)
    {
        a0 = va0;
        q = vq;
        n = vn;
    }

    ~GP()
    {
        Console.WriteLine($"Garbage Collector has worked. {data.Length * sizeof(byte) / 1637421} МБ");
    }


    public void DisplayProgression()
    {
        double current = a0;
        for (int i = 0; i < n; i++)
        {
            Console.Write(current + " ");
            current *= q;
        }
        Console.WriteLine();
    }

    public double GetLast()
    {
        double l = a0 * Math.Pow(q, n - 1);
        return l;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;

        GP[] v = new GP[100];
        double a0 = 0, q = 0, n = 0;
        double va0, vq, vn;
        int count;
        int k = 0;
        Console.WriteLine("Введіть кількість векторів: ");
        count = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < count; i++)
        {
            v[i] = new GP(a0, q, n);
        }
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Введіть координати для геометричної прогресії" + (i + 1));
            Console.WriteLine("Введіть перший: ");
            va0 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть другий: ");
            vq = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть третій: ");
            vn = Convert.ToInt32(Console.ReadLine());
            v[i].InputCoord(va0, vq, vn);

            Console.WriteLine("\nГеометрична прогресія " + (i + 1) + ": ");
            v[i].DisplayProgression();
        }



        double max = v[0].GetLast();
        for (int i = 0; i < count; i++)
        {
            if (max < v[i].GetLast())
            {
                max = v[i].GetLast();
                k = i;
            }
        }
        Console.WriteLine("Найбільший останній член в геометричної прогресії № " + (k + 1));

        GP gp = new GP();

        for (int i = 0; i < 10; ++i)
        {
            gp.data = new byte[100000000];
            gp = new GP();
            GC.Collect();
        }

    }
}
