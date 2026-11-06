using System;
using System.Collections.Generic;

namespace MafiaGalon
{
    class Produk
    {
        public string Nama { get; set; }
        public double Harga { get; set; }

        public Produk(string nama, double harga)
        {
            Nama = nama;
            Harga = harga;
        }
        public virtual double HitungHargaGalon()
        {
            return 0;
        }
    }

    class GalonAQua : Produk
    {
        public double Jumlah { get; set; }
        public GalonAQua(string nama, double harga, double jumlah) : base(nama, harga)
        {
            Jumlah = jumlah;
        }

        public override double HitungHargaGalon()
        {
            return Jumlah * 20000;
        }
    }


    class GalonKeran : Produk
    {
        public double Jumlah { get; set; }

        public GalonKeran(string nama, double harga, double jumlah) : base(nama, harga)
        {
            Jumlah = jumlah; // nilai Y
        }

        public override double HitungHargaGalon()
        {
            return Jumlah * 12000;
        }
    }

    // Class Keranjang Belanja
    class Keranjang
    {
        private List<Produk> daftarProduk = new List<Produk>();
        public void TambahProduk(Produk produk)
        {
            daftarProduk.Add(produk);
        }

        public void TampilkanDanHitungTotal()
        {
            double totalHargaBarang = 0;
            double totaljumlah = 0;

            Console.WriteLine("=== ISI KERANJANG BELANJA ===");
            foreach (var item in daftarProduk)
            {
                double jumlah = item.HitungHargaGalon();
                Console.WriteLine($"- {item.Nama} | Harga: Rp{item.Harga:N0} | Jumlah: Rp{jumlah:N0}");

                totalHargaBarang += item.Harga;
                totaljumlah += jumlah;
            }

            double grandTotal = totalHargaBarang + totaljumlah;

            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Total Harga Barang : Rp{totalHargaBarang:N0}");
            Console.WriteLine($"Total jumlah barang : Rp{totaljumlah:N0}");
            Console.WriteLine($"Total Pembayaran   : Rp{grandTotal:N0}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Keranjang keranjang = new Keranjang();
            keranjang.TambahProduk(new GalonAQua("Tem", 20000, 2));
            keranjang.TambahProduk(new GalonKeran("Pak Ahmad", 12000, 3));

            keranjang.TampilkanDanHitungTotal();
        }
    }
}

