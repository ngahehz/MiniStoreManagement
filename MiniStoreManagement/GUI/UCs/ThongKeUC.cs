using MiniStoreManagement.BUS;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStoreManagement.GUI.UCs
{
    public partial class ThongKeUC : UserControl
    {
        private SalesInvoiceBUS salesInvoiceBUS = new SalesInvoiceBUS();
        private PurchaseInvoiceBUS purchaseInvoiceBUS = new PurchaseInvoiceBUS();
        private SalesInvoiceDetailBUS salesInvoiceDetailBUS = new SalesInvoiceDetailBUS();
        private ProductBUS productBUS = new ProductBUS();
        private DataTable dt1;
        private DataTable dt2;
        private DataTable dt3;
        private bool flag = false;
        public ThongKeUC()
        {
            InitializeComponent();
        }

        private void ThongKeUC_Load(object sender, EventArgs e)
        {
            if (SalesInvoiceBUS.SalesInvoiceList == null)
                salesInvoiceBUS.getInvoice();
            if (PurchaseInvoiceBUS.PurchaseInvoiceList == null)
                purchaseInvoiceBUS.getInvoice();
            if (SalesInvoiceDetailBUS.SalesInvoiceDetailList == null)
                salesInvoiceDetailBUS.getInvoiceDetail();
            if (ProductBUS.ProductList == null)
                productBUS.getProduct();

            cbb_tab3.SelectedIndex = 0;

            tabThuChi1();
            tabSanPham1();
            tabHoaDon1();
        }

        private void ThongKeThuChi()
        {
            DataTable dataTable = (DataTable)dataGridView1.DataSource;

            var sumDt1 = from row in PurchaseInvoiceBUS.PurchaseInvoiceList.AsEnumerable()
                         group row by new { Month = row.Field<DateTime>("DATE").Month, Year = row.Field<DateTime>("DATE").Year } into grp
                         select new
                         {
                             Tháng = $"{grp.Key.Month}/{grp.Key.Year}",
                             Chi = grp.Sum(r => r.Field<decimal>("TOTAL_PAYMENT"))
                         };

            var sumDt2 = from row in SalesInvoiceBUS.SalesInvoiceList.AsEnumerable()
                         group row by new { Month = row.Field<DateTime>("DATE").Month, Year = row.Field<DateTime>("DATE").Year } into grp
                         select new
                         {
                             Tháng = $"{grp.Key.Month}/{grp.Key.Year}",
                             Thu = grp.Sum(r => r.Field<decimal>("TOTAL_PAYMENT"))
                         };


            var allMonths = sumDt1.Select(s => s.Tháng).Union(sumDt2.Select(s => s.Tháng));

            foreach (var month in allMonths)
            {
                var rowDt1 = sumDt1.FirstOrDefault(r => r.Tháng == month);
                var chi = (rowDt1 != null) ? rowDt1.Chi : 0;
                var rowDt2 = sumDt2.FirstOrDefault(r => r.Tháng == month);
                var thu = (rowDt2 != null) ? rowDt2.Thu : 0;
                var rowTotal = thu - chi;

                dataTable.Rows.Add(month, (rowDt1 != null) ? rowDt1.Chi : 0, (rowDt2 != null) ? rowDt2.Thu : 0, rowTotal);
            }

            dataTable.Columns.Add("ThangNamDateTime", typeof(DateTime));

            // Chuyển đổi dữ liệu từ cột "Tháng" sang cột "ThangNamDateTime"
            foreach (DataRow row in dataTable.Rows)
            {
                DateTime thangNam = DateTime.ParseExact(row["Tháng"].ToString(), "M/yyyy", CultureInfo.InvariantCulture);
                row["ThangNamDateTime"] = thangNam;
            }

            // Sắp xếp DataView theo cột "Tháng"
            dataTable.DefaultView.Sort = "ThangNamDateTime ASC";

            // Cập nhật DataGridView
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns["ThangNamDateTime"].Visible = false;
            dt1 = dataTable;
        }

        private void tabThuChi1()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Tháng", typeof(string));
            dataTable.Columns.Add("Tiền Chi", typeof(decimal));
            dataTable.Columns.Add("Tiền Thu", typeof(decimal));
            dataTable.Columns.Add("Tổng", typeof(decimal));

            dataGridView1.DataSource = dataTable;

            ThongKeThuChi();
        }

        private void ThongKeSanPham()
        {
            DataTable dataTable = (DataTable)dataGridView2.DataSource;

            var result = from ct in SalesInvoiceDetailBUS.SalesInvoiceDetailList.AsEnumerable()
                         join h in SalesInvoiceBUS.SalesInvoiceList.AsEnumerable() on ct.Field<string>("INVOICE_ID") equals h.Field<string>("ID")
                         join sp in ProductBUS.ProductList.AsEnumerable() on ct.Field<string>("PRODUCT_ID") equals sp.Field<string>("ID")
                         group new
                         {
                             PRODUCT_ID = sp.Field<string>("ID"),
                             PRODUCT_NAME = sp.Field<string>("NAME"),
                             QUANTITY = ct.Field<int>("QUANTITY"),
                             ThanhTien = ct.Field<decimal>("PRICE") * ct.Field<int>("QUANTITY")
                         } by new
                         {
                             Month = h.Field<DateTime>("DATE").Month,
                             Year = h.Field<DateTime>("DATE").Year,
                             PRODUCT_ID = sp.Field<string>("ID"),
                             PRODUCT_NAME = sp.Field<string>("NAME")
                         } into g
                         select new
                         {
                             Tháng = $"{g.Key.Month}/{g.Key.Year}",
                             PRODUCT_ID = g.Key.PRODUCT_ID,
                             PRODUCT_NAME = g.Key.PRODUCT_NAME,
                             QUANTITY = g.Sum(x => x.QUANTITY),
                             TongGiaTri = g.Sum(x => x.ThanhTien)
                         };

            foreach (var item in result)
            {
                dataTable.Rows.Add(item.Tháng, item.PRODUCT_ID, item.PRODUCT_NAME, item.QUANTITY, item.TongGiaTri);
            }


            dataTable.Columns.Add("ThangNamDateTime", typeof(DateTime));

            // Chuyển đổi dữ liệu từ cột "Tháng" sang cột "ThangNamDateTime"
            foreach (DataRow row in dataTable.Rows)
            {
                DateTime thangNam = DateTime.ParseExact(row["Tháng"].ToString(), "M/yyyy", CultureInfo.InvariantCulture);
                row["ThangNamDateTime"] = thangNam;
            }

            // Sắp xếp DataView theo cột "Tháng"
            dataTable.DefaultView.Sort = "ThangNamDateTime ASC";

            // Cập nhật DataGridView
            dataGridView2.DataSource = dataTable;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns["ThangNamDateTime"].Visible = false;
            dt2 = dataTable;
        }

        private void tabSanPham1()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Tháng", typeof(string));
            dataTable.Columns.Add("ID sản phẩm", typeof(string));
            dataTable.Columns.Add("Tên sản phẩm", typeof(string));
            dataTable.Columns.Add("Số lượng", typeof(int));
            dataTable.Columns.Add("Tổng tiền", typeof(decimal));

            dataGridView2.DataSource = dataTable;
            ThongKeSanPham();
        }

        private void ThongKeHoaDon()
        {
            DataTable dataTable = (DataTable)dataGridView3.DataSource;

            switch (cbb_tab3.SelectedIndex)
            {
                case 0:
                    var result0 = from row in SalesInvoiceBUS.SalesInvoiceList.AsEnumerable()
                                  group row by row.Field<DateTime>("DATE") into grp
                                  select new
                                  {
                                      DATE = $"{grp.Key.Day}/{grp.Key.Month}/{grp.Key.Year}",
                                      QUANTITY = grp.Count(r => r.Field<string>("ID") != null),
                                      TOTAL = grp.Sum(r => r.Field<decimal>("TOTAL_PAYMENT"))
                                  };

                    foreach (var item in result0)
                        dataTable.Rows.Add(item.DATE, item.QUANTITY, item.TOTAL);

                    dataTable.Columns.Add("ThangNamDateTime", typeof(DateTime));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        DateTime thangNam = DateTime.ParseExact(row["Ngày tháng năm"].ToString(), "d/M/yyyy", CultureInfo.InvariantCulture);
                        row["ThangNamDateTime"] = thangNam;
                    }

                    dataTable.DefaultView.Sort = "ThangNamDateTime ASC";
                    //dataGridView3.Columns["ThangNamDateTime"].Visible = false;
                    break;

                case 1:
                    var result1 = from row in SalesInvoiceBUS.SalesInvoiceList.AsEnumerable()
                                  group row by new { Month = row.Field<DateTime>("DATE").Month, Year = row.Field<DateTime>("DATE").Year } into grp
                                  select new
                                  {
                                      Tháng = $"{grp.Key.Month}/{grp.Key.Year}",
                                      QUANTITY = grp.Count(r => r.Field<string>("ID") != null),
                                      TOTAL = grp.Sum(r => r.Field<decimal>("TOTAL_PAYMENT"))
                                  };

                    foreach (var item in result1)
                        dataTable.Rows.Add(item.Tháng, item.QUANTITY, item.TOTAL);

                    dataTable.Columns.Add("ThangNamDateTime", typeof(DateTime));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        DateTime thangNam = DateTime.ParseExact(row["Ngày tháng năm"].ToString(), "M/yyyy", CultureInfo.InvariantCulture);
                        row["ThangNamDateTime"] = thangNam;
                    }

                    dataTable.DefaultView.Sort = "ThangNamDateTime ASC";
                    //dataGridView3.Columns["ThangNamDateTime"].Visible = false;
                    break;

                case 2:
                    var result2 = from row in SalesInvoiceBUS.SalesInvoiceList.AsEnumerable()
                                  group row by row.Field<DateTime>("DATE").Year into grp
                                  select new
                                  {
                                      Năm = grp.Key,
                                      QUANTITY = grp.Count(r => r.Field<string>("ID") != null),
                                      TOTAL = grp.Sum(r => r.Field<decimal>("TOTAL_PAYMENT"))
                                  };

                    foreach (var item in result2)
                        dataTable.Rows.Add(item.Năm, item.QUANTITY, item.TOTAL);

                    dataTable.Columns.Add("ThangNamDateTime", typeof(DateTime));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        DateTime thangNam = DateTime.ParseExact(row["Ngày tháng năm"].ToString(), "yyyy", CultureInfo.InvariantCulture);
                        row["ThangNamDateTime"] = thangNam;
                    }

                    dataTable.DefaultView.Sort = "ThangNamDateTime ASC";
                    //dataGridView3.Columns["ThangNamDateTime"].Visible = false;
                    break;
            }

            dataGridView3.DataSource = dataTable;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dt3 = dataTable;
        }

        private void tabHoaDon1()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Ngày tháng năm", typeof(string));
            dataTable.Columns.Add("Số hóa đơn", typeof(int));
            dataTable.Columns.Add("Tổng tiền", typeof(decimal));

            dataGridView3.DataSource = dataTable;
            ThongKeHoaDon();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dtpThuChi1.CustomFormat == " ")
                dtpThuChi1.CustomFormat = "M/yyyy";

            //if (dateTimePicker1.CustomFormat == " " && dateTimePicker2.CustomFormat == " ")
            //{
            //    dataGridView1.DataSource = dt1;
            //    return;
            //}

            DataView dv = dt1.DefaultView;
            if (dtpThuChi2.CustomFormat == " ")
            {
                dv.RowFilter = $"ThangNamDateTime >= #{dtpThuChi1.Value.ToString("M/yyyy")}#";
                dataGridView1.DataSource = dv.ToTable();
            }
            else
            {
                dv.RowFilter = $"ThangNamDateTime >= #{dtpThuChi1.Value.ToString("M/yyyy")}# AND ThangNamDateTime <= #{dtpThuChi2.Value.ToString("M/yyyy")}#";
                dataGridView1.DataSource = dv.ToTable();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dtpThuChi2.CustomFormat == " ")
                dtpThuChi2.CustomFormat = "M/yyyy";

            //if (dateTimePicker1.CustomFormat == " " && dateTimePicker2.CustomFormat == " ")
            //{
            //    dataGridView1.DataSource = dt1;
            //    return;
            //}

            DataView dv = dt1.DefaultView;
            if (dtpThuChi1.CustomFormat == " ")
            {
                dv.RowFilter = $"ThangNamDateTime <= #{dtpThuChi2.Value.ToString("M/yyyy")}#";
                dataGridView1.DataSource = dv.ToTable();
            }
            else
            {
                dv.RowFilter = $"ThangNamDateTime >= #{dtpThuChi1.Value.ToString("M/yyyy")}# AND ThangNamDateTime <= #{dtpThuChi2.Value.ToString("M/yyyy")}#";
                dataGridView1.DataSource = dv.ToTable();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpThuChi1.Value = DateTime.Now;
            dtpThuChi2.Value = DateTime.Now;
            dtpThuChi1.CustomFormat = " ";
            dtpThuChi2.CustomFormat = " ";
            dataGridView1.DataSource = dt1;
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "Tiền Chi" ||
                dgv.Columns[e.ColumnIndex].Name == "Tiền Thu" ||
                dgv.Columns[e.ColumnIndex].Name == "Tổng tiền" ||
                dgv.Columns[e.ColumnIndex].Name == "Tổng")
            {
                if (e.Value != null && e.Value is decimal)
                {
                    e.Value = ((decimal)e.Value).ToString("#,##0");
                    e.FormattingApplied = true;
                }
            }

            if (dgv.Columns[e.ColumnIndex].Name == "Ngày")
            {
                if (e.Value != null && e.Value is DateTime)
                {
                    e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }
        }

        private void dtpSanPham1_ValueChanged(object sender, EventArgs e)
        {
            if (dtpSanPham1.CustomFormat == " ")
                dtpSanPham1.CustomFormat = "M/yyyy";

            DataView dv = dt2.DefaultView;
            if (dtpSanPham2.CustomFormat == " ")
            {
                dv.RowFilter = $"ThangNamDateTime >= #{dtpSanPham1.Value.ToString("M/yyyy")}#";
                dataGridView2.DataSource = dv.ToTable();
            }
            else
            {
                dv.RowFilter = $"ThangNamDateTime >= #{dtpSanPham1.Value.ToString("M/yyyy")}# AND ThangNamDateTime <= #{dtpSanPham2.Value.ToString("M/yyyy")}#";
                dataGridView2.DataSource = dv.ToTable();
            }
        }

        private void dtpSanPham2_ValueChanged(object sender, EventArgs e)
        {
            if (dtpSanPham2.CustomFormat == " ")
                dtpSanPham2.CustomFormat = "M/yyyy";

            DataView dv = dt2.DefaultView;
            if (dtpSanPham1.CustomFormat == " ")
            {
                dv.RowFilter = $"ThangNamDateTime <= #{dtpSanPham2.Value.ToString("M/yyyy")}#";
                dataGridView2.DataSource = dv.ToTable();
            }
            else
            {
                dv.RowFilter = $"ThangNamDateTime >= #{dtpSanPham1.Value.ToString("M/yyyy")}# AND ThangNamDateTime <= #{dtpSanPham2.Value.ToString("M/yyyy")}#";
                dataGridView2.DataSource = dv.ToTable();
            }
        }

        private void btnReset2_Click(object sender, EventArgs e)
        {
            dtpSanPham1.Value = DateTime.Now;
            dtpSanPham2.Value = DateTime.Now;
            dtpSanPham1.CustomFormat = " ";
            dtpSanPham2.CustomFormat = " ";
            dataGridView2.DataSource = dt2;
        }

        private void cbb_tab3_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnReset3.PerformClick();
            tabHoaDon1();
        }

        private void btnReset3_Click(object sender, EventArgs e)
        {
            flag = true;
            dtpHoaDon1.Value = DateTime.Now;
            dtpHoaDon2.Value = DateTime.Now;
            dtpHoaDon1.CustomFormat = " ";
            dtpHoaDon2.CustomFormat = " ";
            flag = false;
            dataGridView3.DataSource = dt3;
        }

        private void dtpHoaDon1_ValueChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                return;
            }
            DataView dv = dt3.DefaultView;
            switch (cbb_tab3.SelectedIndex)
            {
                case 0:
                    if (dtpHoaDon1.CustomFormat == " ")
                        dtpHoaDon1.CustomFormat = "dd/MM/yyyy";


                    if (dtpHoaDon2.CustomFormat == " ")
                    {
                        dv.RowFilter = $"ThangNamDateTime >= #{dtpHoaDon1.Value.ToString()}#";
                        dataGridView3.DataSource = dv.ToTable();
                    }
                    else
                    {
                        dv.RowFilter = $"ThangNamDateTime >= #{dtpHoaDon1.Value.ToString("dd/MM/yyyy")}# AND ThangNamDateTime <= #{dtpHoaDon2.Value.ToString()}#";
                        dataGridView3.DataSource = dv.ToTable();
                    }
                    break;

                case 1:
                    if (dtpHoaDon1.CustomFormat == " ")
                        dtpHoaDon1.CustomFormat = "M/yyyy";

                    dv = dt3.DefaultView;
                    if (dtpHoaDon2.CustomFormat == " ")
                    {
                        dv.RowFilter = $"ThangNamDateTime >= #{dtpHoaDon1.Value.ToString("M/yyyy")}#";
                        dataGridView3.DataSource = dv.ToTable();
                    }
                    else
                    {
                        dv.RowFilter = $"ThangNamDateTime >= #{dtpHoaDon1.Value.ToString("M/yyyy")}# AND ThangNamDateTime <= #{dtpHoaDon2.Value.ToString("M/yyyy")}#";
                        dataGridView3.DataSource = dv.ToTable();
                    }
                    break;

                case 2:
                    if (dtpHoaDon1.CustomFormat == " ")
                        dtpHoaDon1.CustomFormat = "yyyy";

                    dv = dt3.DefaultView;
                    if (dtpHoaDon2.CustomFormat == " ")
                    {
                        dv.RowFilter = $"ThangNamDateTime >= #{dtpHoaDon1.Value.ToString("yyyy")}#";
                        dataGridView3.DataSource = dv.ToTable();
                    }
                    else
                    {
                        dv.RowFilter = $"ThangNamDateTime >= #{dtpHoaDon1.Value.ToString("yyyy")}# AND ThangNamDateTime <= #{dtpHoaDon2.Value.ToString("yyyy")}#";
                        dataGridView3.DataSource = dv.ToTable();
                    }
                    break;
            }
        }

        private void dtpHoaDon2_ValueChanged(object sender, EventArgs e)
        {

            if (flag)
            {
                return;
            }
            DataView dv = dt3.DefaultView;
            switch (cbb_tab3.SelectedIndex)
            {
                case 0:
                    if (dtpHoaDon2.CustomFormat == " ")
                        dtpHoaDon2.CustomFormat = "dd/MM/yyyy";

                    dv = dt3.DefaultView;
                    if (dtpHoaDon1.CustomFormat == " ")
                    {
                        dv.RowFilter = $"ThangNamDateTime <= #{dtpHoaDon2.Value.ToString()}#";
                        dataGridView3.DataSource = dv.ToTable();
                    }
                    else
                    {
                        dv.RowFilter = $"ThangNamDateTime >= #{dtpHoaDon1.Value.ToString()}# AND ThangNamDateTime <= #{dtpHoaDon2.Value.ToString()}#";
                        dataGridView3.DataSource = dv.ToTable();
                    }
                    break;

                case 1:
                    if (dtpHoaDon2.CustomFormat == " ")
                        dtpHoaDon2.CustomFormat = "M/yyyy";

                    dv = dt3.DefaultView;
                    if (dtpHoaDon1.CustomFormat == " ")
                    {
                        dv.RowFilter = $"ThangNamDateTime <= #{dtpHoaDon2.Value.ToString("M/yyyy")}#";
                        dataGridView3.DataSource = dv.ToTable();
                    }
                    else
                    {
                        dv.RowFilter = $"ThangNamDateTime >= #{dtpHoaDon1.Value.ToString("M/yyyy")}# AND ThangNamDateTime <= #{dtpHoaDon2.Value.ToString("M/yyyy")}#";
                        dataGridView3.DataSource = dv.ToTable();
                    }
                    break;

                case 2:
                    if (dtpHoaDon2.CustomFormat == " ")
                        dtpHoaDon2.CustomFormat = "yyyy";

                    dv = dt3.DefaultView;
                    if (dtpHoaDon1.CustomFormat == " ")
                    {
                        dv.RowFilter = $"ThangNamDateTime <= #{dtpHoaDon2.Value.ToString("yyyy")}#";
                        dataGridView3.DataSource = dv.ToTable();
                    }
                    else
                    {
                        dv.RowFilter = $"ThangNamDateTime >= #{dtpHoaDon1.Value.ToString("yyyy")}# AND ThangNamDateTime <= #{dtpHoaDon2.Value.ToString("yyyy")}#";
                        dataGridView3.DataSource = dv.ToTable();
                    }
                    break;
            }
        }
    }
}
