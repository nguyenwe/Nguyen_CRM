using CRM.Db;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models
{

    public struct RevenueByDate
    {
        public string Date { get; set; }
        public decimal TotalAmount { get; set; }

    }
    public class DBBieudo : Dbconnection
    {
        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;

        public int Numcustomers { get; private set; } // so luong khach hang
        public int Numproducts { get; private set; } // soluong san pham
        public int NumLeads { get; private set; } // soluong khach hang tiem nang
        public int NumOrderhasSigned { get; private set; }// hop dong da ky
        public int NumOrders { get; private set; } // so luong hop dong
        public int NumQuote { get; private set; } // so luong bao gia
        public int NumPost { get; private set; } // so luong bai dang

        public List<KeyValuePair<string, int>> TopProductsList { get; private set; } // top san pham
        public List<RevenueByDate> GrossRevenueList { get; private set; } // Doanh thu theo thang
        public List<KeyValuePair<string, decimal>> DoanhthuNhanvien { get; private set; } // Doanh thu theo nhan vien
        public List<KeyValuePair<string, decimal>> DoanhthutheoKhachhang { get; private set; } // Doanh thu theo khach hang

        public decimal TotalRevevue { get; private set; } // tong doanh thu
        public decimal TotalProfit { get; private set; }

        //Constructor
        public DBBieudo()
        {

        }

        private void getnumberItems()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    //Get total number of customer 
                    command.CommandText = @"select count(customer_id) from customers";
                    Numcustomers = (int)command.ExecuteScalar();

                    // products
                    command.CommandText = @"select count(product_id) from products";
                    Numproducts = (int)command.ExecuteScalar();

                    // leads
                    command.CommandText = @"select count(lead_id) from leads";
                    NumLeads = (int)command.ExecuteScalar();

                    //so luong hop dong
                    command.CommandText = @"select count(contract_id) from contracts where signed_at between @fromDate and @toDate";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    NumOrders = (int)command.ExecuteScalar();

                    //so luong hop dong da ky
                    command.CommandText = @"select count(contract_id) 
                                            from contracts 
                                            where status = N'Đã ký' and signed_at between @from and @to";
                    command.Parameters.Add("@from", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@to", System.Data.SqlDbType.DateTime).Value = endDate;
                    NumOrderhasSigned = (int)command.ExecuteScalar();

                    //so luong bao gia
                    command.CommandText = @"select count(quote_id) from quotes where quote_day between @fromD and @toD";
                    command.Parameters.Add("@fromD", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toD", System.Data.SqlDbType.DateTime).Value = endDate;
                    NumQuote = (int)command.ExecuteScalar();

                    //so luong bai dang
                    command.CommandText = @"select count(post_id) 
                                            from posts 
                                            where submitted_day between @fro and @t";
                    command.Parameters.Add("@fro", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@t", System.Data.SqlDbType.DateTime).Value = endDate;
                    NumPost = (int)command.ExecuteScalar();
                }
            }
        }

        private void GetOrderAnalysis() // Doanh thu theo thang
        {
            GrossRevenueList = new List<RevenueByDate>();
            TotalProfit = 0;
            TotalRevevue = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"select c.signed_at, sum(ct.quantity*p.unit_price) as Total
                                            from contracts c inner
                                            join contract_detail ct on c.contract_id = ct.contract_id
                                            inner join products p on ct.product_id = p.product_id
                                            where c.signed_at between @fromDate and @toDate
                                            group by c.signed_at";

                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    var reader = command.ExecuteReader();
                    var ResultTable = new List<KeyValuePair<DateTime, decimal>>();

                    while (reader.Read())
                    {
                        ResultTable.Add(
                            new KeyValuePair<DateTime, decimal>((DateTime)reader[0], (decimal)reader[1]));
                        TotalRevevue += (decimal)reader[1];
                    }
                    TotalProfit = TotalRevevue * 0.2m;
                    reader.Close();

                    // group by days
                    if (numberDays <= 30)
                    {
                        foreach (var item in ResultTable)
                        {
                            GrossRevenueList.Add(new RevenueByDate()
                            {
                                Date = item.Key.ToString("dd MMM"),
                                TotalAmount = item.Value
                            });
                        }
                    }

                    //group by Week
                    else if (numberDays <= 92)
                    {
                        GrossRevenueList = (from orderList in ResultTable
                                            group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                                orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                            into order
                                            select new RevenueByDate
                                            {
                                                Date = "Week " + order.Key.ToString(),
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }

                    //Group by Month
                    else if (numberDays <= 365 * 2)
                    {
                        bool isYear = numberDays <= 365 ? true : false;
                        GrossRevenueList = (from orderList in ResultTable
                                            group orderList by orderList.Key.ToString("MMM yyyy")
                                          into order
                                            select new RevenueByDate
                                            {
                                                Date = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }

                    //Group by year
                    else
                    {
                        GrossRevenueList = (from orderList in ResultTable
                                            group orderList by orderList.Key.ToString("yyyy")
                                            into order
                                            select new RevenueByDate
                                            {
                                                Date = order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }

                }
            }
        }

        private void GetProductAnalysis()
        {
            TopProductsList = new List<KeyValuePair<string, int>>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;

                    //get top 3 products
                    command.CommandText = @"select top 10 p.name, sum(ct.quantity) as Q
                                            from contracts c inner join contract_detail ct on c.contract_id = ct.contract_id
                                                     inner join products p on ct.product_id = p.product_id
                                            where c.signed_at between @fromDate and @toDate
                                            group by p.name
                                            order by Q desc";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TopProductsList.Add(
                            new KeyValuePair<string, int>(reader[0].ToString(), (int)reader[1]));
                    }
                    reader.Close();
                }
            }
        }

        private void GetStaffDoanhthu()
        {
            DoanhthuNhanvien = new List<KeyValuePair<string, decimal>>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;

                    command.CommandText = @"select max(nv.name) as TenNV, sum(ct.quantity*p.unit_price) as Doanhthu
                                            from staffs nv left join contracts hd on nv.staff_id = hd.staff_id
				                            inner join contract_detail ct on hd.contract_id = ct.contract_id
				                            inner join products p on ct.product_id = p.product_id
                                            where (nv.title_id = 'KD' or nv.title_id = 'QL') and signed_at between @fromDate and @toDate
                                            group by nv.staff_id";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DoanhthuNhanvien.Add(
                            new KeyValuePair<string, decimal>(reader[0].ToString(), (decimal)reader[1]));
                    }
                    reader.Close();
                }
            }
        }

        private void GetCustomerDoanhthu()
        {
            DoanhthutheoKhachhang = new List<KeyValuePair<string, decimal>>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;

                    command.CommandText = @"select max(kh.name) as TenKH, sum(ct.quantity*p.unit_price) as Thanhtien
                                            from contract_detail ct inner join contracts hd on ct.contract_id = hd.contract_id
						                                right join customers kh on hd.customer_id = kh.customer_id
						                        inner join products p on ct.product_id = p.product_id
                                            where hd.signed_at between @fromDate and @toDate
                                            group by kh.customer_id";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DoanhthutheoKhachhang.Add(
                            new KeyValuePair<string, decimal>(reader[0].ToString(), (decimal)reader[1]));
                    }
                    reader.Close();
                }
            }
        }

        //public methods
        public bool LoadData(DateTime startDate, DateTime endDate)
        {
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day,
                endDate.Hour, endDate.Minute, 59);
            if (startDate != this.startDate || endDate != this.endDate)
            {
                this.startDate = startDate;
                this.endDate = endDate;
                this.numberDays = (endDate - startDate).Days;

                getnumberItems();
                GetProductAnalysis();
                GetOrderAnalysis();
                GetStaffDoanhthu();
                GetCustomerDoanhthu();
                Console.WriteLine("Data Refreshed: {0} - {1}", startDate.ToString(), endDate.ToString());
                return true;
            }
            else
            {
                Console.WriteLine("Data not Refreshed, same query: {0} - {1}", startDate.ToString(), endDate.ToString());
                return false;
            }
        }

    }
}
