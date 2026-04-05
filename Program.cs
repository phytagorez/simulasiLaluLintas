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

    public string StatusLampu;

    public Kendaraan(string nama, double kecepatan)
    {
        Nama = nama;
        Kecepatan = kecepatan;
        StatusLampu = "hijau";
    }

    public virtual void Bergerak()
    {
        if (StatusLampu == "merah")
        {
            Console.WriteLine($"{Nama} berhenti karena lampu merah.");
        }
        else if (StatusLampu == "kuning")
        {
            Console.WriteLine($"{Nama} melambat karena lampu kuning, hati-hati...");
        }
        else
        {
            Console.WriteLine($"{Nama} bergerak dengan kecepatan {Kecepatan} km/h");
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
        if (StatusLampu == "merah")
        {
            Console.WriteLine($"Mobil {Nama} ({Warna}) berhenti di lampu merah.");
        }
        else if (StatusLampu == "kuning")
        {
            Console.WriteLine($"Mobil {Nama} ({Warna}) melambat, siap berhenti...");
        }
        else
        {
            Console.WriteLine($"Mobil {Nama} ({Warna}) melaju {Kecepatan} km/h");
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
        Console.WriteLine($"Sirene {Nama} dinyalakan!");
    }

    public override void Bergerak()
    {
        if (SireneMenyala)
        {
            Console.WriteLine($"Ambulans {Nama} TETAP MELAJU {Kecepatan} km/h - sirene aktif! (prioritas darurat)");
        }
        else if (StatusLampu == "merah")
        {
            Console.WriteLine($"Ambulans {Nama} berhenti di lampu merah.");
        }
        else if (StatusLampu == "kuning")
        {
            Console.WriteLine($"Ambulans {Nama} melambat karena lampu kuning.");
        }
        else
        {
            Console.WriteLine($"Ambulans {Nama} melaju {Kecepatan} km/h");
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

    public int Penumpang;

    public Bus(string nama, double kecepatan, int kapasitas) : base(nama, kecepatan)
    {
        Kapasitas = kapasitas;
        Penumpang = 0;
    }

    public void NaikPenumpang(int jumlah)
    {
        if (Penumpang + jumlah <= Kapasitas)
        {
            Penumpang += jumlah;
            Console.WriteLine($"{jumlah} penumpang naik. Total: {Penumpang}/{Kapasitas}");
        }
        else
        {
            Console.WriteLine($"Bus penuh! Tidak bisa menampung {jumlah} penumpang lagi.");
        }
    }

    public override void Bergerak()
    {
        if (StatusLampu == "merah")
        {
            Console.WriteLine($"Bus {Nama} berhenti, penumpang menunggu... ({Penumpang}/{Kapasitas})");
        }
        else if (StatusLampu == "kuning")
        {
            Console.WriteLine($"Bus {Nama} melambat karena lampu kuning ({Penumpang}/{Kapasitas} penumpang)");
        }
        else
        {
            Console.WriteLine($"Bus {Nama} berjalan {Kecepatan} km/h ({Penumpang}/{Kapasitas} penumpang)");
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
        bus.NaikPenumpang(25);
        bus.NaikPenumpang(20);

        Console.WriteLine("\n=== Lampu Hijau ===");
        mobil.Bergerak();
        ambulans.Bergerak();
        bus.Bergerak();

        Console.WriteLine("\n=== Lampu Kuning ===");
        mobil.StatusLampu = "kuning";
        ambulans.StatusLampu = "kuning";
        bus.StatusLampu = "kuning";
        mobil.Bergerak();
        ambulans.Bergerak();
        bus.Bergerak();

        Console.WriteLine("\n=== Lampu Merah ===");
        mobil.StatusLampu = "merah";
        ambulans.StatusLampu = "merah";
        bus.StatusLampu = "merah";
        mobil.Bergerak();
        ambulans.Bergerak();
        bus.Bergerak();

        Console.WriteLine("\n=== Demo Setter ===");
        mobil.Kecepatan = -10;
        bus.Kapasitas = 0;
    }
}