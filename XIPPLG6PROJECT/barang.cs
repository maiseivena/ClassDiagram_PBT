using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XIPPLG6PROJECT
{
    public class barang
    {
        private int iD;
        private String nama;
        private System.DateTime kadaluarsa;
        private int isi;
        private int berat;

        public string Nama1 { get => nama; }
        public DateTime Kadaluarsa1 { get => kadaluarsa; }
        public int Isi1 { get => isi; }
        public int Berat1 { get => berat; }
        public int ID { get => iD;}

        public void CheckKadaluarsa()
        {
            //throw new System.NotImplementedException();
        }

        public void EditBarang(string getNama, int getBerat, int getIsi, DateTime getKadaluarsa)
        {
            this.nama = getNama;
            this.berat = getBerat;
            this.isi = getIsi;
            this.kadaluarsa = getKadaluarsa;

        }

        public void IsiBarang(int getId, string getNama, int getBerat, int getIsi,DateTime getKadaluarsa)
        {
            this.iD = getId;
            this.nama = getNama;
            this.isi = getIsi;
            this.kadaluarsa=getKadaluarsa;
            this.berat =getBerat;
        }

        public void GetFreeID()
        {
            //throw new System.NotImplementedException();
        }

        public void EditBarang()
        {
            throw new System.NotImplementedException();
        }
    }
}