using System;

class Kendaraan
{
    public string Nama;
    private double kecepatan;

    public double Kecepatan
    {
        get { return kecepatan; }
        set
        {
            if (value >= 0)
                kecepatan = value;
            else
                Console.WriteLine("Kecepatan tidak boleh negatif!");
        }
    }

    public bool LampuMerah;

    public Kendaraan(string nama, double kecepatan)
    {
        Nama = nama;
        Kecepatan = kecepatan;
        LampuMerah = false;
    }

    public virtual void Bergerak()
    {
        if (LampuMerah)
        {
            Console.WriteLine(Nama + " berhenti karena lampu merah.");
        }
        else
        { 
            Console.WriteLine(Nama + " bergerak dengan kecepatan " + Kecepatan + " km/h");
        }
    }
}

class Mobil : Kendaraan
{
    public string Warna;

    public Mobil(string nama, double kecepatan, string warna) : base(nama, kecepatan)
    {
        Warna = warna;
    }

    public override void Bergerak()
    {
        if (LampuMerah)
        {
            Console.WriteLine("Mobil " + Nama + " (" + Warna + ") berhenti di lampu merah.");
        }
        else
        { 
            Console.WriteLine("Mobil " + Nama + " (" + Warna + ") melaju " + Kecepatan + " km/h");
        }
    }
}

class Ambulans : Kendaraan
{
    public bool SireneMenyala;

    public Ambulans(string nama, double kecepatan) : base(nama, kecepatan)
    {
        SireneMenyala = false;
    }

    public void NyalakanSirene()
    {
        SireneMenyala = true;
        Console.WriteLine("Sirene " + Nama + " dinyalakan!");
    }

    public override void Bergerak()
    {
        if (LampuMerah && SireneMenyala)
        { 
            Console.WriteLine("Ambulans " + Nama + " TETAP MELAJU meski lampu merah - sirene aktif!");
        }
        else if (LampuMerah)
        { 
            Console.WriteLine("Ambulans " + Nama + " berhenti di lampu merah.");
        }
        else
        {
            Console.WriteLine("Ambulans " + Nama + " melaju " + Kecepatan + " km/h");
        }
    }
}

class Bus : Kendaraan
{
    private int kapasitas;

    public int Kapasitas
    {
        get { return kapasitas; }
        set
        {
            if (value >= 1)
                kapasitas = value;
            else
                Console.WriteLine("Kapasitas minimal 1 orang!");
        }
    }

    public Bus(string nama, double kecepatan, int kapasitas) : base(nama, kecepatan)
    {
        Kapasitas = kapasitas;
    }

    public override void Bergerak()
    {
        if (LampuMerah)
        { 
            Console.WriteLine("Bus " + Nama + " berhenti di lampu merah. Penumpang menunggu...");
        }
        else
        { 
            Console.WriteLine("Bus " + Nama + " berjalan " + Kecepatan + " km/h | Kapasitas: " + Kapasitas + " orang");
        }
    }
}

class Program
{
    static void Main()
    {
        Mobil mobil = new Mobil("Avanza", 60, "Putih");
        Ambulans ambulans = new Ambulans("RSU Surabaya", 90);
        Bus bus = new Bus("Bus Kota 1", 50, 40);

        ambulans.NyalakanSirene();

        Console.WriteLine("\n=== Lampu Hijau ===");
        mobil.Bergerak();
        ambulans.Bergerak();
        bus.Bergerak();

        Console.WriteLine("\n=== Lampu Merah ===");
        mobil.LampuMerah = true;
        ambulans.LampuMerah = true;
        bus.LampuMerah = true;

        mobil.Bergerak();
        ambulans.Bergerak();
        bus.Bergerak();
    }
}