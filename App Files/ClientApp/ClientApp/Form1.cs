using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string q = "select * from Product";
            Program.FillDataGridView(dataGridView1, q);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string q1 = "insert into Product values('" + textBox1.Text + "','" + textBox2.Text + "')";
            string q2 = "select * from Product";
            Program.Excute(q1);
            Program.FillDataGridView(dataGridView1,q2);
        }
    }
}
