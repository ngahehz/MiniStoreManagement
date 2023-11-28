using MiniStoreManagement.BUS;
using MiniStoreManagement.GUI.FormSP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStoreManagement.GUI.UCs
{
    public partial class StockroomUC : UserControl
    {
        private StockroomBUS stockroomBUS = new StockroomBUS();
        private ProductBUS productBUS = new ProductBUS();
        public StockroomUC()
        {
            InitializeComponent();
        }

        private void StockroomUC_Load(object sender, EventArgs e)
        {
            if (StockroomBUS.StockroomList == null)
                stockroomBUS.getStockroom();
            if(ProductBUS.ProductList == null)
                productBUS.getProduct();
            dataGridView1.DataSource = StockroomBUS.StockroomList;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if(StockroomBUS.StockroomList.Rows.Count == 0)
                return;

            if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "")
            {
                reset_form();
                return;
            }
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtID_product.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtQuantiy.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            dateTimePicker1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());

            DataRow rowFind = ProductBUS.ProductList.AsEnumerable().FirstOrDefault(row => row.Field<string>("ID") == txtID_product.Text);
            txtName.Text = rowFind[1].ToString();
            txtPrice.Text = ((decimal)rowFind[5]).ToString("#,##0");
        }

        private void reset_form()
        {
            txtName.ResetText();
            txtPrice.ResetText();
            txtPrice.Text = "0";
            txtSearch.ResetText();
            txtID.ResetText();
            txtID_product.ResetText();
            dateTimePicker1.CustomFormat = " ";
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "EXP")
            {
                if (e.Value != null && e.Value is DateTime)
                {
                    e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }
        }
        private int LoadData(string query)
        {
            DataView dv = StockroomBUS.StockroomList.DefaultView;
            dv.RowFilter = query;
            dataGridView1.DataSource = dv.ToTable();
            return dv.ToTable().Rows.Count;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["TimKiemStockroom"] != null)
                return;
            TimKiemStockroom timkiem = new TimKiemStockroom();
            timkiem.temp = new TimKiemStockroom.truyenDuLieu(LoadData);
            timkiem.Show();
        }
    }
}
