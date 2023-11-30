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

namespace Nguyen_CRM
{
    public partial class Dashboard : Form
    {

        //string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        //SqlDataAdapter adapter = new SqlDataAdapter();//docdulieu
        //DataTable table = new DataTable();

        public Dashboard()
        {
            InitializeComponent();
        }
        private Form currentFormChild;

        private void OpenChildForm(Form childForm)
        {
            if(currentFormChild != null)
            {
                currentFormChild.Close();

            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_body.Controls.Add(childForm);
            panel_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void btnCampaign_Click(object sender, EventArgs e)
        {
            OpenChildForm(new campaign());
            label1.Text = btnQLmarketing.Text +" | "+ btnCampaign.Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Bieudo());
            label1.Text = btnDashboard.Text;
        }

        private void btnQLmarketing_Click(object sender, EventArgs e)
        {
            OpenChildForm(new lead());
            label1.Text = btnQLmarketing.Text +" | "+ btnLead.Text;
        }

        private void btnLead_Click(object sender, EventArgs e)
        {
            OpenChildForm(new lead());
            label1.Text = btnQLmarketing.Text + " | " + btnLead.Text;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Bieudo());
            label1.Text = btnDashboard.Text;
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            OpenChildForm(new group());
            label1.Text = btnQLmarketing.Text + " | " + btnGroup.Text;
        }

        // Email
        //    OpenChildForm(new Email());
        //    label1.Text = btnQLmarketing.Text + " | " + btnEmail.Text;
  

        private void btnPost_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Post());
            label1.Text = btnQLmarketing.Text + " | " + btnPost.Text;
        }

        private void btnQLbanhang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Contract());
            label1.Text = btnQLbanhang.Text + " | "+ btnContract.Text;
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Customer());
            label1.Text = btnQLbanhang.Text + " | " + btnCustomer.Text;
        }

        private void btnContract_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Contract());
            label1.Text = btnQLbanhang.Text + " | " + btnContract.Text;
        }

        private void btnLienhe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Contact());
            label1.Text = btnQLbanhang.Text + " | " + btnLienhe.Text;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Product());
            label1.Text = btnQLbanhang.Text + " | " + btnProduct.Text;
        }

        private void btnQuote_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Quote());
            label1.Text = btnQLbanhang.Text + " | " + btnQuote.Text;
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            OpenChildForm(new service_history());
            label1.Text = btnQLcskh.Text + " | " + btnService.Text;
        }

        private void btnQLcskh_Click(object sender, EventArgs e)
        {
            OpenChildForm(new service_history());
            label1.Text = btnQLcskh.Text + " | " + btnService.Text;
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            OpenChildForm(new feedback());
            label1.Text = btnQLcskh.Text + " | " + btnFeedback.Text;
        }

        private void btnPlan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new plan());
            label1.Text = btnQLcongviec.Text + " | " + btnPlan.Text;
        }

        private void btnQLcongviec_Click(object sender, EventArgs e)
        {
            OpenChildForm(new plan());
            label1.Text = btnQLcongviec.Text + " | "+ btnPlan.Text;
        }

        private void btnMeeting_Click(object sender, EventArgs e)
        {
            OpenChildForm(new meeting());
            label1.Text = btnQLcongviec.Text + " | " + btnMeeting.Text;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Report());
            label1.Text = btnReport.Text;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            btnDashboard.PerformClick();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmEmail());
            label1.Text = btnQLmarketing.Text + " | " + btnEmail.Text;
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                Login f = new Login();
                this.Close();
                f.Show();
            }
        }

    }
}
