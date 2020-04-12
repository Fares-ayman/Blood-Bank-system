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
    public partial class LoginAsDonor : Form
    {
        static string sql = "Data Source=DESKTOP-CTASUB2;Initial Catalog=project 2;Integrated Security=True";
        SqlConnection con = new SqlConnection(sql);
        int result;
        public LoginAsDonor()
        {
            InitializeComponent();
        }
  
        private void backD_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void registerforDonor_Click(object sender, EventArgs e)
        {
            RegisterDonor r1 = new RegisterDonor();

            r1.Show();
        }

        private void login2donor_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "select dbo.login_doner('"+UsernameDonor.Text+"','"+PasswordDonor.Text+"')";
                SqlCommand cmd = new SqlCommand(query, con);
                result = (int)cmd.ExecuteScalar();
                con.Close();
                if (result >= 1)
                {
                    MessageBox.Show("login success");
                }
                HomeForDonor.Visible = true;
                backgroundhome1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpexted error :" + ex.Message);
            }

           
        }

        private void backgroundhome1_Paint(object sender, PaintEventArgs e)
        {

        }

          private void Donate_Click_1(object sender, EventArgs e)
        {
            DonateForm.Visible = true;
            dataGridViewDonor.DataSource = blood();
        }

         public DataTable blood()
        {
            DataTable dt = new DataTable();
            con.Open();
            string query = "execute Display_blood";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        private void logoutD_Click_1(object sender, EventArgs e)
        {
            HomeForDonor.Visible = false;
            backgroundhome1.Visible = false;
        }

        private void add_Click_2(object sender, EventArgs e)
        {
            con.Open();
            string query = "execute count_bloodqty '" + result+"','"+QuantityD.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Done ✔");
            dataGridViewDonor.DataSource = blood();
            //DonateForm.Visible = false;
        }

        private void QuantityD_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridViewDonor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
