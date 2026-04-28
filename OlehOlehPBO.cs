using System;
using System.Numerics;

namespace RumahSakit
{
    class Orang
    {
        public string Nama { get; set; }
        public int Umur {  get; set; }

        public Orang(string nama, int umur)
        {
            Nama = nama;
            Umur = umur;
        }

        public virtual void Aktivitas()
        {
            Console.WriteLine($"{Nama} sedang beraktivitas");
        }

        public virtual void InfoOrang()
        {
            Console.WriteLine($"Nama : {Nama}");
            Console.WriteLine($"Usia : {Umur}");
        }
    }

    class Pasien : Orang
    {
        public string Keluhan { get; set; }

        public Pasien(string nama, int umur, string keluhan) : base(nama, umur)
        {
            Keluhan = Keluhan;
        }

        public void CekKeluhan()
        {
            Console.WriteLine($"{Nama} memiliki keluhan : {Keluhan}");
        }

        public override void Aktivitas()
        {
            Console.WriteLine($"{Nama} sedang menunggu pemeriksaan");
        }
    }

    class TenagaMedis : Orang
    {
        public string Spesialisasi { get; set; }

        public TenagaMedis(string nama, int umur, string spesialisasi) : base(nama, umur)
        {
            Spesialisasi = spesialisasi;
        }

        public void CekSpesialis()
        {
            Console.WriteLine($"{Nama} memiliki spesialisasi {Spesialisasi}");
        }

        public override void Aktivitas()
        {
            Console.WriteLine($"{Nama} sedang bekerja di rumah sakit");
        }
    }

    class Dokter : TenagaMedis
    {
        public Dokter(string nama, int umur, string spesialisasi) : base(nama, umur, spesialisasi)
        {
        }

        public void Diagnosa()
        {
            Console.WriteLine($"{Nama} sedang mendiagnosa pasien");
        }

        public override void Aktivitas()
        {
            Console.WriteLine($"{Nama} sedang berada di ruangan dokter");
        }
    }

    class Perawat : TenagaMedis
    {
        public Perawat(string nama, int umur, string spesialisasi) : base(nama, umur, spesialisasi)
        {
        }

        public void CekPasien()
        {
            Console.WriteLine($"{Nama} sedang mengecek keadaan pasien");
        }

        public override void Aktivitas()
        {
            Console.WriteLine($"{Nama} sedang membantu dokter");
        }
    }

    class PasienAnak : Pasien
    {
        public PasienAnak(string nama, int umur, string keluhan) : base(nama, umur, keluhan)
        {
        }

        public void Menangis()
        {
            Console.WriteLine($"{Nama} sedang menangis");
        }

        public override void Aktivitas()
        {
            Console.WriteLine($"{Nama} sedang bermain di ruangan anak");
        }
    }

    class PasienDewasa : Pasien
    {
        public PasienDewasa(string nama, int umur, string keluhan) : base(nama, umur, keluhan)
        {
        }

        public void Konsultasi()
        {
            Console.WriteLine($"{Nama} sedang melakukan konsultasi kepada dokter");
        }

        public override void Aktivitas()
        {
            Console.WriteLine($"{Nama} sedang melakukan pemeriksaan");
        }
    }

    class RumahSakit
    {
        private List<Orang> daftarOrang = new List<Orang>();

        public void TambahOrang(Orang orang)
        {
            daftarOrang.Add(orang);
        }

        public void DaftarOrang()
        {
            foreach(Orang orang in daftarOrang)
            {
                orang.InfoOrang();
                orang.Aktivitas();
                Console.WriteLine("------------------");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RumahSakit rs = new RumahSakit();
            Dokter dr = new Dokter("Dr. Bintang", 19, "Otak");
            Perawat pr = new Perawat("Qiqi", 19, "Rawat Inap");
            PasienAnak pa = new PasienAnak("Tutung", 7, "Flu");
            PasienDewasa pd = new PasienDewasa("Yupi", 25, "Sakit Dada");

            rs.TambahOrang(dr);
            rs.TambahOrang(pr);
            rs.TambahOrang(pa);
            rs.TambahOrang(pd);

            Console.WriteLine("=====DAFTAR ORANG DI RUMAH SAKIT=====");
            rs.DaftarOrang();

            Console.WriteLine("=====POLYMORPHISM=====");
            Orang[] orangArray = { dr, pr,pa, pd };

            foreach (Orang o in orangArray)
            {
                o.Aktivitas();
            }

            Console.WriteLine("=====METHOD KHUSUS=====");
            dr.Diagnosa();
            pr.CekPasien();
            pa.Menangis();
            pd.Konsultasi();

            Console.ReadLine();
        }
    }
}