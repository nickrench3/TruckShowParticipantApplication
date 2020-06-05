using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TruckShowParticipants
{
    public partial class Form1 : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=NICKRENTSCHLER\SQLEXPRESS01;Initial Catalog=TruckShow;Integrated Security=True;Pooling=False");
        private SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
            con.Open();
            int count = 0;
            TotalTextBox.Clear();
            cmd = new SqlCommand("Select count(*) FROM TruckShowParticipants", con);
            count = (int)cmd.ExecuteScalar();
            TotalTextBox.AppendText(count.ToString());
            con.Close();
        }

        private void EnterButton1_Click(object sender, EventArgs e)
        {
            TotalTextBox.Clear();

            string message = "Entry Added";
            string title = "Truck Show Participant";
            MessageBox.Show(message, title);
            con.Open();
            cmd = new SqlCommand("INSERT INTO TruckShowParticipants (ShowEntryNumber, Name, PhoneNumber, TruckYear, Make, Model)" +
                " Values('"+NumberTextBox1.Text+"','"+NameTextBox1.Text+"','"+PhoneTextBox1.Text+"','"+YearTextBox1.Text+"','"+MakeTextBox1.Text+"','"+ModelTextBox1.Text+"')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            TotalTextBox.Clear();
            int count = 0;
            cmd = new SqlCommand("Select count(*) FROM TruckShowParticipants", con);
            count = (int)cmd.ExecuteScalar();
            TotalTextBox.AppendText(count.ToString());
            con.Close();
        }

        private void ClearButton1_Click(object sender, EventArgs e)
        {
            NumberTextBox1.Text = "";
            NameTextBox1.Text = "";
            PhoneTextBox1.Text = "";
            YearTextBox1.Text = "";
            MakeTextBox1.Text = "";
            ModelTextBox1.Text = "";
            con.Open();
            TotalTextBox.Clear();
            int count = 0;
            cmd = new SqlCommand("Select count(*) FROM TruckShowParticipants", con);
            count = (int)cmd.ExecuteScalar();
            TotalTextBox.AppendText(count.ToString());
            con.Close();
        }

        private void EnterButton2_Click(object sender, EventArgs e)
        {
            
            NameTextBox2.Clear();
            PhoneTextBox2.Clear();
            YearTextBox2.Clear();
            MakeTextBox2.Clear();
            ModelTextBox2.Clear();
            TotalTextBox.Clear();

            string number = NumberTextBox2.Text;
            number = number.Trim();
            con.Open();
            cmd = new SqlCommand("SELECT * FROM TruckShowParticipants WHERE ShowEntryNumber= '"+NumberTextBox2.Text+"'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string Name = (dr["Name"].ToString());
                Name = Name.Trim();
                NameTextBox2.AppendText(Name);

                string phoneNum = (dr["PhoneNumber"].ToString());
                phoneNum = phoneNum.Trim();
                PhoneTextBox2.AppendText(phoneNum);

                string year = (dr["TruckYear"].ToString());
                year = year.Trim();
                YearTextBox2.AppendText(year);

                string make = (dr["Make"].ToString());
                make = make.Trim();
                MakeTextBox2.AppendText(make);

                string model = (dr["Model"].ToString());
                model = model.Trim();
                ModelTextBox2.AppendText(model);
            }
            con.Close();
            con.Open();
            int count = 0;
            TotalTextBox.Clear();
            cmd = new SqlCommand("Select count(*) FROM TruckShowParticipants", con);
            count = (int)cmd.ExecuteScalar();
            TotalTextBox.AppendText(count.ToString());
            con.Close();
        }

        private void ClearButton2_Click(object sender, EventArgs e)
        {
            NumberTextBox2.Text = "";
            NameTextBox2.Text = "";
            PhoneTextBox2.Text = "";
            YearTextBox2.Text = "";
            MakeTextBox2.Text = "";
            ModelTextBox2.Text = "";
            con.Open();
            int count = 0;
            TotalTextBox.Clear();
            cmd = new SqlCommand("Select count(*) FROM TruckShowParticipants", con);
            count = (int)cmd.ExecuteScalar();
            TotalTextBox.AppendText(count.ToString());
            con.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string message = "All records deleted";
            string title = "Truck Show Records";
            MessageBox.Show(message, title);
            con.Open();
            cmd = new SqlCommand("DELETE FROM TruckShowParticipants", con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            TotalTextBox.Clear();
            int count = 0;
            cmd = new SqlCommand("Select count(*) FROM TruckShowParticipants", con);
            count = (int)cmd.ExecuteScalar();
            TotalTextBox.AppendText(count.ToString());
            con.Close();
        }
    }
}
