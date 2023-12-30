public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
        double p = 3.14;
        double d;
        double rezult = 0;
        d = double.Parse(textBox1.Text.ToString());
        double r = d / 2;
        rezult = p * Math.Pow(r, 2);
        label3.Text = rezult.ToString();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }
}
