using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace XIPPLG6PROJECT
{
    public partial class Form1 : Form
    {
        List<barang> listbarang = new List<barang>();
        public int barangID = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            RefreshDataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void RefreshDataGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (barang getbarang in listbarang)
            {
                string[] newRow = { "", "", "", "","" };
                newRow[0] = getbarang.ID.ToString();
                newRow[1] = getbarang.Nama1;
                newRow[2] = getbarang.Berat1.ToString();
                newRow[3] = getbarang.Isi1.ToString();
                newRow[4] = getbarang.Kadaluarsa1.ToString();
                dataGridView1.Rows.Add(newRow);
            }
        }

        private int GetFreeID()
        {
            int nowID = 0;
            while (true)
            {
                bool adaYgSama = false;
                foreach (barang checkBarang in listbarang)
                {
                    if (checkBarang.ID == nowID)
                        adaYgSama = true;
                }
                if (adaYgSama)
                    nowID += 1;
                else
                    break;
            }
            return nowID;
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            barang barangBaru = new barang();
            barangID = GetFreeID();
            barangBaru.IsiBarang(barangID, EditNamaBarang.Text, (int)NumericEditBerat.Value,
                (int)NumericEditIsi.Value, DateEdit.Value);
            listbarang.Add(barangBaru);
            barangID += 1;
            RefreshDataGrid();
            SaveData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            barang getBarang = SelectBarang();
            if (listbarang.Contains(getBarang))
                listbarang.Remove(getBarang);
            RefreshDataGrid();
            SaveData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            barang getBarang = SelectBarang();
            groupBox1.Enabled = true;
            EditNamaBarang.Text = getBarang.Nama1;
            NumericEditBerat.Value = getBarang.Berat1;
            NumericEditIsi.Value = getBarang.Isi1;
            DateEdit.Value = getBarang.Kadaluarsa1;
        }

        private barang SelectBarang()
        {
            int getID = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i += 1)
            {
                if (dataGridView1.Rows[i].Selected)
                {
                    getID = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    break;
                }
            }
            barang getBarang = new barang();
            foreach(barang checkBarang in listbarang)
            {
                if (checkBarang.ID == getID)
                    getBarang = checkBarang;
            }
            return getBarang;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            barang getBarang = SelectBarang();
            getBarang.EditBarang(textBox2.Text, (int) numericUpDown3.Value, (int) numericUpDown4.Value, dateTimePicker2.Value);
            RefreshDataGrid();
            groupBox1.Enabled = false;
            SaveData();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void RefreshDataGridKadaluarsa()
        {
            dataGridView1.Rows.Clear();
            foreach (barang getBarang in listbarang)
            {
                if ((getBarang.Kadaluarsa1 - DateTime.Now).TotalDays <= 30)
                {
                    string[] newRow = { " ", " ", " ", " ", " ", };
                    newRow[0] = getBarang.ID.ToString();
                    newRow[1] = getBarang.Nama1;
                    newRow[2] = getBarang.Berat1.ToString();
                    newRow[3] = getBarang.Isi1.ToString();
                    newRow[4] = getBarang.Kadaluarsa1.ToString();
                    dataGridView1.Rows.Add(newRow);
                }
            }
        }

        private void cbKadaluarsa_CheckedChanged(object sender, EventArgs e)
        {
            if (cbKadaluarsa.Checked)
                RefreshDataGridKadaluarsa();
            else
                RefreshDataGrid();
        }

        private void SaveData()
        {
            if (File.Exists("data.csv"))
                File.Delete("data.csv");
            StreamWriter sw = new StreamWriter("data.csv");
            sw.WriteLine("#barangID,  barangNama, barangBerat, BarangIsi, barangKadaluarsa");
            foreach (barang getBarang in listbarang)
                sw.WriteLine(getBarang.ID.ToString() + "," +
                    getBarang.Nama1.ToString() + "," +
                    getBarang.Berat1.ToString() + "," +
                    getBarang.Isi1.ToString() + "," +
                    getBarang.Kadaluarsa1.ToString() + ""); 
            sw.Close();
        }

        private void LoadData()
        {
            if (File.Exists("data.csv)"))
            {
                StreamReader sr = new StreamReader("data.csv");
                string line = sr.ReadLine();
                while (line != null)
                {
                    if (!line.Contains("#"))
                    {
                        string[] strSplit = line.Split(' ');
                        int id = int.Parse(strSplit[0]);
                        string nama = strSplit[1];
                        int berat = int.Parse(strSplit[2]);
                        int isi = int.Parse(strSplit[3]);
                        DateTime kadaluarsa = DateTime.Parse(strSplit[4]);
                        barang newBarang = new barang();
                        newBarang.IsiBarang(id, nama, berat, isi, kadaluarsa); 
                        listbarang.Add(newBarang);
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void NumericEditBerat_ValueChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
