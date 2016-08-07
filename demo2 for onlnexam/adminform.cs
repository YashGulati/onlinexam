using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace demo2_for_onlnexam
{
    public partial class adminform : Form
    {
        public adminform()
        {
            InitializeComponent();
            
        }
        public void arrangeExam()
        {
            try
            {
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
                OleDbConnection sqc = new OleDbConnection(conn);
                OleDbCommand cmd = new OleDbCommand("insert into arrangeExam ([stuId],[password],[date]) values ('" + this.sid.Text + "','" + this.pass.Text + "','" + this.dateTimePicker1.Text + "')", sqc);

                sqc.Open();

                int a = cmd.ExecuteNonQuery();
                sqc.Close();

                if (a > 0)
                {
                    MessageBox.Show("Exam is Arranged");
                }
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message);
            }  
        }
        public void showDatabase()
        {
            string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
            OleDbConnection sqc = new OleDbConnection(conn);
            OleDbCommand cmd = new OleDbCommand("select * from questionPaper;", sqc);
            try
            {
                OleDbDataAdapter sdr = new OleDbDataAdapter();
                sdr.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sdr.Fill(dbdataset);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dbdataset;
                dataGridView1.DataSource = bsource;
                sdr.Update(dbdataset);
            }
            catch (Exception)
            {
            }
        }
        public void showStudentdetail()
        {
            string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
            OleDbConnection sqc = new OleDbConnection(conn);
            OleDbCommand cmd = new OleDbCommand("select * from arrangeExam;", sqc);
            try
            {
                OleDbDataAdapter sdr = new OleDbDataAdapter();
                sdr.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sdr.Fill(dbdataset);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dbdataset;
                dataGridView2.DataSource = bsource;
                sdr.Update(dbdataset);
            }
            catch (Exception)
            {
            }

        }
        public void maxQID()
        {
            try
            {
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
                OleDbConnection sqc = new OleDbConnection(conn);
                OleDbCommand cmd = new OleDbCommand("select max(qId)+1 from questionPaper", sqc);
                OleDbDataReader myReader;
                sqc.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    textBox1.Text = myReader[0].ToString();
                }
                sqc.Close();
            }
            catch (Exception)
            {

            }
        }
        public void savequs()
        {
            try
            {
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
                OleDbConnection sqc = new OleDbConnection(conn);
                OleDbCommand cmd = new OleDbCommand("insert into questionPaper ([qId],[qus],[opt1],[opt2],[opt3],[opt4],[ans]) values ('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "')", sqc);

                sqc.Open();

                int a = cmd.ExecuteNonQuery();
                sqc.Close();

                if (a > 0)
                {
                    MessageBox.Show("Question is Saved");
                }
            }
            catch (Exception)
            {

            }
        }
        public void updatequs()
        {
            try
            {
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
                OleDbConnection sqc = new OleDbConnection(conn);
                OleDbCommand cmd = new OleDbCommand("update questionPaper set [qId]='" + this.textBox1.Text + "',[qus]='" + this.textBox2.Text + "',[opt1]='" + this.textBox3.Text + "',[opt2]='" + this.textBox4.Text + "',[opt3]='" + this.textBox5.Text + "',[opt4]='" + this.textBox6.Text + "' ,[ans]='" + this.textBox7.Text + "' where [qId]='" + textBox1.Text + "'", sqc);

                sqc.Open();

                int b = cmd.ExecuteNonQuery();
                sqc.Close();

                if (b > 0)
                {
                    MessageBox.Show("Question is Updated");
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        public void deletequs()
        {

            string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
            OleDbConnection sqc = new OleDbConnection(conn);
            OleDbCommand cmd = new OleDbCommand("delete from questionPaper where qId=" + this.textBox1.Text, sqc);

            sqc.Open();

            int c = cmd.ExecuteNonQuery();
            sqc.Close();

            if (c > 0)
            {
                MessageBox.Show("Question is Deleted.");
            }
        }
        public void textboxclear()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void adminform_Load(object sender, EventArgs e)
        {
            maxQID();
            showDatabase();
            showStudentdetail();
        }

        private void adminform_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to exit", "exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void arrangebtn_Click(object sender, EventArgs e)
        {
            arrangeExam();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                
                textBox1.Text = row.Cells["qId"].Value.ToString();
                textBox2.Text = row.Cells["qus"].Value.ToString();
                textBox3.Text = row.Cells["opt1"].Value.ToString();
                textBox4.Text = row.Cells["opt2"].Value.ToString();
                textBox5.Text = row.Cells["opt3"].Value.ToString();
                textBox6.Text = row.Cells["opt4"].Value.ToString();
                textBox7.Text = row.Cells["ans"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            savequs();
            showDatabase();
            textboxclear();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            updatequs();
            showDatabase();
            textboxclear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deletequs();
            showDatabase();
            textboxclear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
