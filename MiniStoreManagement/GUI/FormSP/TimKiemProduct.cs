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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace MiniStoreManagement.GUI.FormSP
{
    public partial class TimKiemProduct : Form
    {
        public delegate int truyenDuLieu(string txt);
        public truyenDuLieu temp;
        private int max;

        private ProductBUS productBUS = new ProductBUS();
        private ProviderBUS providerBUS = new ProviderBUS();
        private CategoryBUS categoryBUS = new CategoryBUS();
        private PromotionBUS promotionBUS = new PromotionBUS();

        public TimKiemProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> s = new List<string>();

            if (!string.IsNullOrWhiteSpace(cbbID_category.Text))
            {
                s.Add($"CATEGORY_ID = '{cbbID_category.Text}'");
            }
            if (!string.IsNullOrWhiteSpace(cbbID_promotion.Text))
            {
                s.Add($"PROMOTION_ID = '{cbbID_promotion.Text}'");
            }
            if (!string.IsNullOrWhiteSpace(cbbID_provider.Text))
            {
                s.Add($"PROVIDER_ID = '{cbbID_provider.Text}'");
            }

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

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            if (dtp.CustomFormat == " ")
                dtp.CustomFormat = "dd/MM/yyyy";
        }

        private void TimKiemProduct_Load(object sender, EventArgs e)
        {
            if (ProductBUS.ProductList == null)
                productBUS.getProduct();
            if (ProviderBUS.ProviderList == null)
                providerBUS.getProvider();
            if (CategoryBUS.CategoryList == null)
                categoryBUS.getCategory();
            if (PromotionBUS.PromotionList == null)
                promotionBUS.getPromotion();

            foreach (DataRow row in show_data("2").Rows)
                cbbID_provider.Items.Add(row["ID"].ToString());
            foreach (DataRow row in show_data("1").Rows)
                cbbID_category.Items.Add(row["ID"].ToString());
            foreach (DataRow row in PromotionBUS.PromotionList.Rows)
                cbbID_promotion.Items.Add(row["ID"].ToString());

            max = 0;
            foreach(DataRow row in ProductBUS.ProductList.Rows)
            {
                if ((int)row["QUANTITY"] > max)
                {
                    max = (int)row["QUANTITY"];
                }
            }
            numericUpDown2.Value = max;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name)
            {
                case "btnQuantity":
                    numericUpDown1.Value = 0;
                    numericUpDown2.Value = max;
                    break;
                case "btnExp":
                    dateTimePicker1.Value = DateTime.Now;
                    dateTimePicker2.Value = DateTime.Now;
                    dateTimePicker1.CustomFormat = " ";
                    dateTimePicker2.CustomFormat = " ";
                    break;
                case "ID_provider":
                    cbbID_provider.SelectedItem = null;
                    break;
                case "ID_category":
                    cbbID_category.SelectedItem = null;
                    break;
                case "ID_promotion":
                    cbbID_promotion.SelectedItem = null;
                    break;
            }
        }

        private DataTable show_data(string abc)
        {
            if (abc == "1")
            {
                var filteredRows1 = CategoryBUS.CategoryList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
                return filteredRows1.Any() ? filteredRows1.CopyToDataTable() : CategoryBUS.CategoryList.Clone();
            }
            else 
            {
                var filteredRows2 = ProviderBUS.ProviderList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
                return filteredRows2.Any() ? filteredRows2.CopyToDataTable() : ProviderBUS.ProviderList.Clone();
            }
        }
    }
}
