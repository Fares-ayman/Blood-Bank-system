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
    public partial class LoginAsAdmin : Form
    {
        static string sql = "Data Source=DESKTOP-CTASUB2;Initial Catalog=project 2;Integrated Security=True";
        SqlConnection con = new SqlConnection(sql);
        int result;
        public LoginAsAdmin()
        {
            InitializeComponent();
        }

        private void BackA_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void login2admin_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "select dbo.login_admin('"+UsernameAdmin.Text+"','"+PasswordAdmin.Text+"')";
                SqlCommand cmd = new SqlCommand(query, con);
                result = (int)cmd.ExecuteScalar();
                con.Close();
                if (result >= 1)
                {
                    MessageBox.Show("login success");
                }
                HomeForAdmin.Visible = true;
                BackgroundHome2.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpexted error :" + ex.Message);
            }
        }

        private void BackA_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void LogOutA_Click(object sender, EventArgs e)
        {
            HomeForAdmin.Visible = false;
            BackgroundHome2.Visible = false;
        }

         public DataTable donor()
        {
            DataTable dt = new DataTable();
            con.Open();
            string query = "execute Display_donor";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        private void DonorAdmin_Click(object sender, EventArgs e)
        {
            Admindonor.Visible = true;
            BackgroundHome2.Visible = true;
            dataGridView1.DataSource = donor();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
       

        private void RecipientAdmin_Click(object sender, EventArgs e)
        {
            AdmindonorAdd.Visible = true;
            Admindonor.Visible = true;
            AdminRecipient.Visible = true;
        }

        private void AddRecbyAdmin_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Done !");
        }

        private void SearchDonorAdmin_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void AddDonorbyAdmin_Click_1(object sender, EventArgs e)
        {
            AdmindonorAdd.Visible = true;
            BackgroundHome2.Visible = true;
        }

        private void DeleteDonor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Done !");
        }

        private void ExitDonor2_Click(object sender, EventArgs e)
        {
            Admindonor.Visible = false;
            BackgroundHome2.Visible = false;
        }

        private void ExitDonor_Click(object sender, EventArgs e)
        {
            AdmindonorAdd.Visible = false;
            Admindonor.Visible = false;
            BackgroundHome2.Visible = false;
        }

        private void AddDonorbyAdmin2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Done !");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddQuantityAdmin_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DeleteRec_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Done !");
        }

        private void ExitAdminRec_Click(object sender, EventArgs e)
        {
            AdminRecipient.Visible = false;
            AdmindonorAdd.Visible = false;
            Admindonor.Visible = false;
        }

        private void BloodInventory_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SearchRcipientbyAdmin_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddRecAdmin_Click(object sender, EventArgs e)
        {
            AdmindonorAdd.Visible = true;
            Admindonor.Visible = true;
            AdminRecipient.Visible = true;
            
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ExitBldInv_Click(object sender, EventArgs e)
        {
            Admindonor.Visible = false;
            AdmindonorAdd.Visible = false;
            AdminRecipient.Visible = false;
            BloodInventory.Visible = false;
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SearchBloodInv_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeleteBldinv_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Done !");
        }

        private void Bloodinv_Click(object sender, EventArgs e)
        {
            Admindonor.Visible = true;
            AdmindonorAdd.Visible = true;
            AdminRecipient.Visible = true;
            BloodInventory.Visible = true;
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView6_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RequestForm f2 = new RequestForm();
            f2.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            f2.textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            f2.textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            f2.textBox4.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            f2.textBox5.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            f2.textBox6.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            f2.ShowDialog();

        }

        private void RequestAdmin_Click(object sender, EventArgs e)
        {
            Admindonor.Visible = true;
            AdmindonorAdd.Visible = true;
            AdminRecipient.Visible = true;
            BloodInventory.Visible = true;
            RequestPanel.Visible = true;
        }

        private void ExitRequest_Click(object sender, EventArgs e)
        {
            Admindonor.Visible = false;
            AdmindonorAdd.Visible = false;
            AdminRecipient.Visible = false;
            BloodInventory.Visible = false;
            RequestPanel.Visible = false;
        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer3_Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
