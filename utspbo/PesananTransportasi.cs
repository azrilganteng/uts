using System;
using System.Collections.Generic;
using System.Text;

namespace utspbo
{
    abstract class PesananTransportasi
    {
        private string namaPenumpang { get; set; }
        private int idPesanan { get; set; }
        private string lokasiTujuan { get; set; }

        public string GetNama
        {
            get { return namaPenumpang; }
            set { namaPenumpang = value; }
        }
        public int GetId
        {
            get { return idPesanan; }
            set { idPesanan = value; }
        }
        public string GetLok
        {
            get { return lokasiTujuan; }
            set { lokasiTujuan = value; }
        }
        public PesananTransportasi(string namaPenumpang, int idPesanan, string lokasiTujuan)
        {
            this.GetNama = namaPenumpang;
            this.GetId = idPesanan;
            this.GetLok = lokasiTujuan;
        }

        public void tampilInfo()
        {
            Console.WriteLine($"Nama{namaPenumpang} | ID:{idPesanan} | Tujuan{lokasiTujuan}\nTotal={HitungTarif()}");
        }

        public abstract double HitungTarif();
    }

    class LayananMotor : PesananTransportasi
    {
        public double tarifPerKm;
        public int jarak;
        public LayananMotor (double tarifPerKm, int jarak,string namaPenumpang, int idPesanan, string lokasiTujuan) : base(namaPenumpang,  idPesanan,  lokasiTujuan)
        {
            this.tarifPerKm = tarifPerKm;
            this.jarak = jarak;
        }
        public override double HitungTarif()
        {
            return jarak * tarifPerKm;
        }
    }
    class LayananMobil : PesananTransportasi
    {
        public double tarifPerKm;
        public double biayaTol;
        public int jarak;
        public LayananMobil(double Tarif,int jarak, double Tol, string namaPenumpang, int idPesanan, string lokasiTujuan) : base(namaPenumpang, idPesanan, lokasiTujuan)
        {
            this.tarifPerKm = Tarif;
            this.jarak = jarak;
            this.biayaTol = Tol;
        }
        public override double HitungTarif()
        {
            return (jarak * tarifPerKm)+biayaTol;
        }
    }
    class RiwayatPerjalanan
    {
        private string jenisLayanan;
        private double jarakKm;
        private string tanggalPesan;

        public RiwayatPerjalanan(string jenisLayanan, double jarakKm, string tanggalPesan)
        {
            this.jenisLayanan = jenisLayanan;
            this.jarakKm = jarakKm;
            this.tanggalPesan = tanggalPesan;
        }

        public string GetJenisLayanan() => jenisLayanan;
        public double GetJarakKm() => jarakKm;
        public string GetTanggalPesan() => tanggalPesan;
    }

    class ManajemenPerjalanan
    {
        private PesananTransportasi pesanan;
        private List<RiwayatPerjalanan> daftarRiwayat = new List<RiwayatPerjalanan>();

        public ManajemenPerjalanan(PesananTransportasi pesanan)
        {
            this.pesanan = pesanan;
        }

        public void TambahPerjalanan(RiwayatPerjalanan riwayat)
        {
            daftarRiwayat.Add(riwayat);
        }

        public void CetakRiwayat()
        {
            pesanan.tampilInfo();
            for (int i = 0; i < daftarRiwayat.Count; i++)
            {
                var r = daftarRiwayat[i];
                Console.WriteLine($"{i + 1}. {r.GetJenisLayanan()} | {r.GetJarakKm()} km | {r.GetTanggalPesan()}");
            }
        }
    }
}

