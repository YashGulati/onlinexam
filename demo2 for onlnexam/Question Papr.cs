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
    public partial class qusppr : Form
    {
        public qusppr()
        {
            InitializeComponent();
        }

        int mxq;
        int r;
        int count = 1;
        
        

        public void max_Qid()
        {
            string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
            OleDbConnection sqc = new OleDbConnection(conn);
            OleDbCommand cmd = new OleDbCommand("select max(qId) from questionPaper", sqc);

            OleDbDataReader myReader;
            sqc.Open();
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                mxq = Convert.ToInt32(myReader[0].ToString());

            }
            sqc.Close();
        }

        public void rand()
        {
           
            Random rnd = new Random();
            int x = Convert.ToInt32(listBox2.Items.Count);
            r = rnd.Next(0, x-1);
            
        }

        public void counter()
        {
            if (count <= Convert.ToInt32(mxq))
            {
                label1.Text = count.ToString();
                count++;
            }
            else
            {

            }

        }

        public void addTolist()
        {

            if (listBox2.Items.Count == 0)
            { MessageBox.Show("Question is completed."); }
            else
            {
                rand();
                int x = Convert.ToInt32(listBox2.Items[r]);
                listBox1.Items.Add(x);
                listBox2.Items.Remove(x);
                counter();
                LoadIt();
                option1();
                option2();
                option3();
                option4();
            }
        }


        public void LoadIt()
        {
            string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
            OleDbConnection sqc = new OleDbConnection(conn);
            OleDbCommand cmd = new OleDbCommand("select qus from questionPaper where qId=" + r, sqc);

            OleDbDataReader myReader;
            sqc.Open();
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                label2.Text = myReader[0].ToString();

            }
            sqc.Close();
        }


        public void option1()
        {
            string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
            OleDbConnection sqc = new OleDbConnection(conn);
            OleDbCommand cmd = new OleDbCommand("select opt1 from questionPaper where qId=" + r, sqc);
            OleDbDataReader myReader;
            sqc.Open();
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                radioButton1.Text = myReader[0].ToString();

            }
            sqc.Close();
        }


        public void option2()
        {
            string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
            OleDbConnection sqc = new OleDbConnection(conn);
            OleDbCommand cmd = new OleDbCommand("select opt2 from questionPaper where qId=" + r, sqc);
            OleDbDataReader myReader;
            sqc.Open();
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                radioButton2.Text = myReader[0].ToString();

            }
            sqc.Close();
        }


        public void option3()
        {
            string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
            OleDbConnection sqc = new OleDbConnection(conn);
            OleDbCommand cmd = new OleDbCommand("select opt3 from questionPaper where qId=" + r, sqc);
            OleDbDataReader myReader;
            sqc.Open();
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                radioButton3.Text = myReader[0].ToString();

            }
            sqc.Close();
        }


        public void option4()
        {
            string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
            OleDbConnection sqc = new OleDbConnection(conn);
            OleDbCommand cmd = new OleDbCommand("select opt4 from questionPaper where qId=" + r, sqc);
            OleDbDataReader myReader;
            sqc.Open();
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                radioButton4.Text = myReader[0].ToString();

            }
            sqc.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            addTolist();
        }

        private void qusppr_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to exit?", "exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void qusppr_Load(object sender, EventArgs e)
        {
            max_Qid();
            for (int i = 1; i <= mxq; i++)
                listBox2.Items.Add(i);
            addTolist();
        }
    }
}