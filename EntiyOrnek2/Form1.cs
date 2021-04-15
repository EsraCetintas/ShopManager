using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntiyOrnek2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            NewMethod();
        }

        private void NewMethod()
        {
            dataGridView1.DataSource = productDal.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            productDal.Add(new Product
            {
                Name = textBox1name.Text,
                UnitPrice = Convert.ToDecimal(textBox3fiyat.Text),
                StockAmount=Convert.ToInt32(textBox2tur.Text),

            });
            NewMethod();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3nameupdate.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1fiyatupdate.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2stockpdate.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            productDal.Update(new Product
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                Name = textBox3nameupdate.Text,
                UnitPrice = Convert.ToDecimal(textBox1fiyatupdate.Text),
                StockAmount = Convert.ToInt32(textBox2stockpdate.Text)
            }); 
            NewMethod();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
               
            });
            NewMethod();
        }

        private void Arama(String key)
        {
            var result = productDal.Sorgu(key);
            dataGridView1.DataSource = result;
        }

        private void FiyatArama(decimal price)
        {
            var result = productDal.Fiyat(price);
            dataGridView1.DataSource = result;
        }
        private void AralikArama(decimal min,decimal max)
        {
            var result = productDal.Aralik(min,max);
            dataGridView1.DataSource = result;
        }
        private void textBox1arama_TextChanged(object sender, EventArgs e)
        {
            // Arama(textBox1arama.Text);
           // FiyatArama(Convert.ToDecimal(textBox1arama.Text));
        }
        private void IdArama(int id)
        {
            var result = productDal.GetId(id);
            dataGridView1.DataSource = result;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            // AralikArama(Convert.ToDecimal(textBox1arama.Text), Convert.ToDecimal(textBox1.Text));
            IdArama(Convert.ToInt32(textBox1arama.Text));
        }
    }
}
