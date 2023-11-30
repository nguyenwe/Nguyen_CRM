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
using System.Windows.Forms.DataVisualization.Charting;
using CRM.Models;

namespace Nguyen_CRM
{
    public partial class Bieudo : Form
    {
        private DBBieudo model;

        public Bieudo()
        {
            InitializeComponent();
            //default - last 7 days
            dtpstartDate.Value = DateTime.Today.AddDays(-7);
            dtpendDate.Value = DateTime.Now;
            btnLast7Days.Select();

            model = new DBBieudo();
            LoadData();
        }

        private void LoadData()
        {
            var refreshData = model.LoadData(dtpstartDate.Value, dtpendDate.Value);
            if (refreshData == true)
            {
                labelSoHD.Text = model.NumOrders.ToString();
                labelHDhoanthanh.Text = model.NumOrderhasSigned.ToString();
                labelTongdoanhthu.Text =  model.TotalRevevue.ToString() + "VND";
                labelLead.Text = model.NumLeads.ToString();
                labelKhachhang.Text = model.Numcustomers.ToString();
                labelSobaogia.Text = model.NumQuote.ToString();
                labelSobaidang.Text = model.NumPost.ToString();

                chartDTtheoThang.DataSource = model.GrossRevenueList;
                chartDTtheoThang.Series[0].XValueMember = "Date";
                chartDTtheoThang.Series[0].YValueMembers = "TotalAmount";
                chartDTtheoThang.DataBind();

                chartSanPham.DataSource = model.TopProductsList;
                chartSanPham.Series[0].XValueMember = "Key";
                chartSanPham.Series[0].YValueMembers = "Value";
                chartSanPham.DataBind();

                chartDoanhthu.DataSource = model.DoanhthuNhanvien;
                chartDoanhthu.Series[0].XValueMember = "Key";
                chartDoanhthu.Series[0].YValueMembers = "Value";
                chartDoanhthu.DataBind();

                chartGThopdong.DataSource = model.DoanhthutheoKhachhang;
                chartGThopdong.Series[0].XValueMember = "Key";
                chartGThopdong.Series[0].YValueMembers = "Value";
                chartGThopdong.DataBind();

                Console.WriteLine("Loaded view :)");
            }
            else Console.WriteLine("View not loaded, same query");
        }

        private void DisableCustomeDates()
        {
            dtpstartDate.Enabled = false;
            dtpendDate.Enabled = false;
            btnOKCustomDate.Visible = false;
        }

        private void btnOKCustomDate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnCustomDate_Click(object sender, EventArgs e)
        {
            dtpstartDate.Enabled = true;
            dtpendDate.Enabled = true;
            btnOKCustomDate.Visible = true;
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpstartDate.Value = DateTime.Today;
            dtpendDate.Value = DateTime.Now;
            LoadData();
            DisableCustomeDates();
        }

        private void btnLast7Days_Click(object sender, EventArgs e)
        {
            dtpstartDate.Value = DateTime.Today.AddDays(-7);
            dtpendDate.Value = DateTime.Now;
            LoadData();
            DisableCustomeDates();
        }

        private void btnLast30Days_Click(object sender, EventArgs e)
        {
            dtpstartDate.Value = DateTime.Today.AddDays(-30);
            dtpendDate.Value = DateTime.Now;
            LoadData();
            DisableCustomeDates();
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            dtpstartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpendDate.Value = DateTime.Now;
            LoadData();
            DisableCustomeDates();
        }
    }
}
