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
    public partial class RegisterDonor : Form
    {
        static string sql = "Data Source=DESKTOP-CTASUB2;Initial Catalog=project 2;Integrated Security=True";
        SqlConnection con = new SqlConnection(sql);
        int result;
        public RegisterDonor()
        {
            InitializeComponent();
        }

        private void nextD_Click(object sender, EventArgs e)
        {

            MessageBox.Show("welcome to our system ");
            this.Hide();
        }

        private void nextD_Click_1(object sender, EventArgs e)
        {
            string gender = "Not_found";
            if (checkBox1.CheckState == CheckState.Checked)
            {
                gender = "male";
            }
            if (checkBox2.CheckState == CheckState.Checked)
            {
                gender = "female";
            }
            con.Open();
            string query = "execute insert_donor '"+FullnameRD.Text+"','"+PasswordRD.Text+"','"+nameRD.Text+"','"+AgeRD.Text+"','"+gender+"','"+address_text.Text+"','"+ContactnumberRD.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            string query2 = "select * from [Donor Credetials]";
            cmd = new SqlCommand(query2, con);
            cmd.ExecuteNonQuery();
            string query3 = "select dbo.login_doner('" + FullnameRD.Text + "','" + PasswordRD.Text + "')";
            cmd = new SqlCommand(query3, con);
            result = (int)cmd.ExecuteScalar();
            string query1 = "execute insert_blood '" + BloodtypeRD.Text + "','"+result+"'";
            cmd = new SqlCommand(query1, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("welcome to our system ");
            this.Hide();
        }
    }
}
