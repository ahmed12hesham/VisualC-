using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fstack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlDataAdapter1.Fill(dataSet11);
            sqlConnection1.Close();
            dataGridView1.DataSource = dataSet11.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int InsertedId = int.Parse(textBox2.Text);
            DataRow dRow = dataSet11.Tables[0].Rows.Find(InsertedId);
            if(dRow == null)
            {
                dRow = dataSet11.Tables[0].NewRow();
                dRow[0] = textBox1.Text;
                dRow[1] = int.Parse(textBox2.Text);
                dRow[2] = textBox3.Text;
                dataSet11.Tables[0].Rows.Add(dRow);
                textBox1.Text = textBox2.Text = textBox3.Text = "";
            }
            else
            {
                MessageBox.Show("ID is found !");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int UpdateId = int.Parse(textBox2.Text);
            DataRow dRow = dataSet11.Tables[0].Rows.Find(UpdateId);
            if (dRow != null)
            {
                dRow[0] = textBox1.Text;
                dRow[2] = textBox3.Text;
                textBox1.Text = textBox2.Text = textBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Recorded not found !");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlDataAdapter1.Update(dataSet11);
            sqlConnection1.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            int DeleteId = int.Parse(textBox2.Text);
            DataRow dRow = dataSet11.Tables[0].Rows.Find(DeleteId);
            dataSet11.Tables[0].Rows.Remove(dRow);
            textBox1.Text = textBox2.Text = textBox3.Text = "";
            sqlConnection1.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
