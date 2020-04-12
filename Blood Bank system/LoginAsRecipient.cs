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

namespace Blood_Bank_system
{
    public partial class LoginAsRecipient : Form
    {
        static string sql = "Data Source=DESKTOP-CTASUB2;Initial Catalog=project 2;Integrated Security=True";
        SqlConnection con = new SqlConnection(sql);
        int result;
        public LoginAsRecipient()
        {
            InitializeComponent();
        }

        private void backR_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void registerforRecipient_Click(object sender, EventArgs e)
        {
            RegisterRecipient r2 = new RegisterRecipient();
            r2.Show();
        }

        private void login2recipient_Click(object sender, EventArgs e)
        {
            
            try
            {
                con.Open();
                string query = "select dbo.login_recipient ('" + UsernameRecipient.Text + "','" + PasswordRecipient.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                result = (int)cmd.ExecuteScalar();
                con.Close();
                if (result >= 1)
                {
                    MessageBox.Show("login success");
                }
                HomeForRecipient.Visible = true;
                backgroundhome.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpexted error :" + ex.Message);
            }

        }

          

        //private void Send_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("your request Successfully sent");
        //    sendRequestForm.Visible = false;
        //    searchForm.Visible = false;
        //    backgroundhome.Visible = true;
        //    HomeForRecipient.Visible = true;
        //}

       

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchR_Click_1(object sender, EventArgs e)
        {
            searchForm.Visible = true;
            backgroundhome.Visible = true;
           // dataGridView1.DataSource = blood_inventory();
        }

        private void logoutR_Click(object sender, EventArgs e)
        {
            HomeForRecipient.Visible = false;
            backgroundhome.Visible = false;
        }

       /* public DataTable blood_inventory()
        {
            DataTable dt = new DataTable();
            con.Open();
            string query = "select * from Blood_Inventory";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }*/

        private void Display_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con.Open();
            string query = "select * from rec_blood_inv ('"+BloodtypeRecipient.Text+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void sendR_Click(object sender, EventArgs e)
        {
            sendRequestForm.Visible = true;
            backgroundhome.Visible = true;
         
        }

        private void finalSend_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "execute insert_request '" + hospitalname.Text + "','" + hospitaladd.Text + "','" + QuantityR.Text + "','" + result.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("your request Successfully sent");
            sendRequestForm.Visible = false;
            searchForm.Visible = false;
            backgroundhome.Visible = true;
            HomeForRecipient.Visible = true;
        }

        private void QuantityR_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void hospitalname_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void hospitaladd_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void sendRequestForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
