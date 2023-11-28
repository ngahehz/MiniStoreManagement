using MiniStoreManagement.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStoreManagement.GUI.FormSP
{
    public partial class TimKiemStockroom : Form
    {
        public delegate int truyenDuLieu(string txt);
        public truyenDuLieu temp;
        private int maxQ;
        private decimal maxP;

        private ProductBUS productBUS = new ProductBUS();
        public TimKiemStockroom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> s = new List<string>();

            if (!string.IsNullOrWhiteSpace(cbbID_product.Text))
            {
                s.Add($"PRODUCT_ID = '{cbbID_product.Text}'");
            }

            if (decimal.Parse(txtPrice1.Text.Replace(",","")) < decimal.Parse(txtPrice2.Text.Replace(",", "")))
            {
                s.Add($"PRICE >= '{txtPrice1.Text.Replace(",", "")}'");
                s.Add($"PRICE <= '{txtPrice2.Text.Replace(",", "")}'");
            }
            else if (decimal.Parse(txtPrice2.Text.Replace(",", "")) < decimal.Parse(txtPrice1.Text.Replace(",", "")))
            {
                MessageBox.Show("Số thứ 2 phải lớn hơn số thứ 1");
                txtPrice2.Focus();
            }
            else
                s.Add($"PRICE = '{txtPrice1.Text.Replace(",", "")}'");

            if (numericUpDown2.Value > numericUpDown1.Value)
            {
                s.Add($"QUANTITY >= '{numericUpDown1.Value}'");
                s.Add($"QUANTITY <= '{numericUpDown2.Value}'");
            }
            else if (numericUpDown2.Value < numericUpDown1.Value)
            {
                MessageBox.Show("Số thứ 2 phải lớn hơn số thứ 1");
                numericUpDown2.Focus();
            }
            else
                s.Add($"QUANTITY = '{numericUpDown1.Value}'");


            if (dateTimePicker1.CustomFormat != " " && dateTimePicker2.CustomFormat != " ")
            {
                if (dateTimePicker1.Value >= dateTimePicker2.Value)
                {
                    MessageBox.Show("thời gian đầu phải nhỏ hơn thời gian sau");
                    dateTimePicker2.Focus();
                    return;
                }
                else
                {
                    s.Add($"EXP >= #{dateTimePicker1.Value.ToString("MM/dd/yyyy")}#");
                    s.Add($"EXP <= #{dateTimePicker2.Value.ToString("MM/dd/yyyy")}#");
                }
            }
            else if (dateTimePicker1.CustomFormat != " ")
            {
                s.Add($"EXP >= #{dateTimePicker1.Value.ToString("MM/dd/yyyy")}#");
            }
            else if (dateTimePicker2.CustomFormat != " ")
            {
                s.Add($"EXP <= #{dateTimePicker2.Value.ToString("MM/dd/yyyy")}#");
            }

            int count_row = temp(string.Join(" AND ", s));
            lbCount.Text = "Tìm được " + count_row + " dòng";
        }

        private DataTable show_data(string abc)
        {
            if (abc == "1")
            {
                var filteredRows1 = ProductBUS.ProductList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
                return filteredRows1.Any() ? filteredRows1.CopyToDataTable() : ProductBUS.ProductList.Clone();
            }
            else
            {
                var filteredRows2 = ProviderBUS.ProviderList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
                return filteredRows2.Any() ? filteredRows2.CopyToDataTable() : ProviderBUS.ProviderList.Clone();
            }
        }

        private void TimKiemStockroom_Load(object sender, EventArgs e)
        {
            if (ProductBUS.ProductList == null)
                productBUS.getProduct();

            foreach (DataRow row in show_data("1").Rows)
                cbbID_product.Items.Add(row["ID"].ToString());

            maxQ = 0;
            maxP = 0;
            foreach (DataRow row in ProductBUS.ProductList.Rows)
            {
                if ((int)row["QUANTITY"] > maxQ)
                {
                    maxQ = (int)row["QUANTITY"];
                }
                if ((decimal)row["PRICE"] > maxP)
                {
                    maxP = (decimal)row["PRICE"];
                }
            }
            txtPrice2.Text = maxP.ToString("#,##0");
            numericUpDown2.Value = maxQ;

        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker) sender;
            if (dtp.CustomFormat == " ")
                dtp.CustomFormat = "dd/MM/yyyy";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name)
            {
                case "btnQuantity":
                    numericUpDown1.Value = 0;
                    numericUpDown2.Value = maxQ;
                    break;
                case "btnExp":
                    dateTimePicker1.Value = DateTime.Now;
                    dateTimePicker2.Value = DateTime.Now;
                    dateTimePicker1.CustomFormat = " ";
                    dateTimePicker2.CustomFormat = " ";
                    break;
                case "ID_product":
                    cbbID_product.SelectedItem = null;
                    break;
                case "btnPrice":
                    txtPrice1.Text = "0";
                    txtPrice2.Text = maxP.ToString("#,##0");
                    break;
            }
        }
    }

}
