using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-49PGGOU;Initial Catalog=human; Integrated Security=True");
        private void btnInsert_Click(object sender, EventArgs e)
        {
            string studentId = txtStudentId.Text;
            string name = txtName.Text;
            string gender =groupBox1.Visible.ToString();
           
                //||Female.Name||Others.Name) ;
            string department = comboBox1.SelectedItem.ToString();

            SqlCommand cmd = new SqlCommand("insert into child values('" + studentId + "','" + name + "','" + gender + "','" + department + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            LoadData();
            ClearAll();

        }
        private void LoadData()
        {
         
            SqlDataAdapter sda = new SqlDataAdapter("select * from child", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


        }
        private void ClearAll()
        {
            txtStudentId.Focus();
            txtName.Clear();
            comboBox1.SelectedIndex = - 1;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string studentId = txtStudentId.Text;
          

            SqlDataAdapter sda = new SqlDataAdapter("select * from child where studentId ='" +studentId+ "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0][1].ToString();
                Male.Name = dt.Rows[0][2].ToString();
                comboBox1.Text = dt.Rows[0][3].ToString();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string studentId = txtStudentId.Text;
            string name = txtName.Text;
            string gender = groupBox1.Capture.ToString(); //||Female.Name||Others.Name) ;
            string department = comboBox1.SelectedItem.ToString();


            SqlCommand cmd = new SqlCommand("update child set name='" + name + "',gender='" +gender + "',department='" + department + "'where studentId='" +studentId + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            LoadData();
            ClearAll();

        }

       
    }
}
