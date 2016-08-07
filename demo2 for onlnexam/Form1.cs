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
    public partial class Form1 : Form
    {
        string str;
        public Form1()
        {
            InitializeComponent();
            textBox3.PasswordChar = '*';
            textBox3.MaxLength = 10;
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 10;
        }
        public void checkAdminpass()
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Please type your Username");
                textBox4.Focus();
                return;
            }

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please type your Password");
                textBox3.Focus();
                return;
            }
            try
            {
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
                OleDbConnection sqc = new OleDbConnection(conn);
                OleDbCommand cmd = new OleDbCommand("select * from admin where ID='" + this.textBox4.Text + "'and pass='" + this.textBox3.Text + "';", sqc);
                OleDbDataReader myReader;
                sqc.Open();
                myReader = cmd.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    MessageBox.Show("Username and password is correct.");
                    this.Hide();
                    adminform f2 = new adminform();
                    f2.ShowDialog();
                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate username and password..access denied");
                }
                else
                {
                    MessageBox.Show("Username and password is incorrect.");
                }
                sqc.Close();
            }
            catch (Exception)
            {

            }
        }
        public void checkExamDate()
        {
            
            string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
            OleDbConnection sqc = new OleDbConnection(conn);
            OleDbCommand cmd = new OleDbCommand("select date from arrangeExam where stuId='" + this.textBox1.Text +"';", sqc);
            OleDbDataReader myReader;
            sqc.Open();
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                str = myReader[0].ToString();

            }
            sqc.Close();
            
            if (str == DateTime.Now.ToString().Substring(0, 10))
            {
                MessageBox.Show("\tYour Exam is Start\n\tAll the best");
            }
            else
            {
                MessageBox.Show("Your Exam Date is not yet declared.");
            }

        }
        public void checkStudentpass()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please type your Username");
                textBox1.Focus();
                return;
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please type your Password");
                textBox2.Focus();
                return;
            }
            try
            {
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
                OleDbConnection sqc = new OleDbConnection(conn);
                OleDbCommand cmd = new OleDbCommand("select * from arrangeExam where stuId='" + this.textBox1.Text + "'and password='" + this.textBox2.Text + "';", sqc);
                OleDbDataReader myReader;
                sqc.Open();
                myReader = cmd.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    MessageBox.Show("Username and password is correct.");
                    this.Hide();
                    Instruction i2 = new Instruction();
                    i2.Show();
                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate username and password..access denied");
                }
                else
                {
                    MessageBox.Show("Username and password is incorrect.");
                }
                sqc.Close();
            }
            catch (Exception)
            {

            }
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void pass_Click(object sender, EventArgs e)
        {

        }

      

        private void button2_Click(object sender, EventArgs e)
        {

            checkAdminpass();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkStudentpass();
            checkExamDate();
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}



