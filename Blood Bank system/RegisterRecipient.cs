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
    public partial class RegisterRecipient : Form
    {
        static string sql = "Data Source=DESKTOP-CTASUB2;Initial Catalog=project 2;Integrated Security=True";
        SqlConnection con = new SqlConnection(sql);
        public RegisterRecipient()
        {
            InitializeComponent();
        }

        private void nextR_Click(object sender, EventArgs e)
        {
            MessageBox.Show("welcome to our system ");
            this.Hide();
        }

        private void nextR_Click_1(object sender, EventArgs e)
        {
            string gender="Not_found";
            if (checkBox1.CheckState==CheckState.Checked)
            {
                gender = "male";
            }
            if (checkBox2.CheckState == CheckState.Checked)
            {
                gender = "female";
            }
            con.Open();
            string query = "execute insert_recipient '" + FullnameRr.Text + "','" + PasswordRr.Text + "','" + nameRr.Text + "','" + BloodtypeRr.Text + "','" + AgeRr.Text + "','" + gender + "','" + ContactnumberRr.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            string query2 = "SELECT * FROM [project_1].[dbo].[Recipient Credetials]";
            cmd = new SqlCommand(query2, con);
            con.Close();
            MessageBox.Show("welcome to our system ");
            this.Hide();
        }

        private void BloodtypeRr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
 