using System;
using System.Collections.Generic;
using System.Text;

namespace utspbo
{
    class Program
    {
        public static void Main(string[] args)
        {
            LayananMotor p1 = new LayananMotor(4000.0, 3, "abdi", 01, "Jayapura");
            p1.tampilInfo();

            RiwayatPerjalanan riwayat = new RiwayatPerjalanan("Mobil", 10, "10-10-2025");

            ManajemenPerjalanan manajemen = new ManajemenPerjalanan(p1);
            manajemen.TambahPerjalanan(riwayat);
            manajemen.CetakRiwayat();
        }
    }
}
