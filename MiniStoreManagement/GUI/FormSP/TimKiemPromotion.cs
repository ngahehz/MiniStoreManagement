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
    public partial class TimKiemPromotion : Form
    {
        public delegate void truyenDuLieu(string txt);
        public truyenDuLieu temp;
        public TimKiemPromotion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> s = new List<string>();
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                s.Add($"NAME = '{txtName.Text}'");
            }
            if (double.TryParse(txtPercent.Text, out double number))
            {
                if (number > 0 || number < 1)
                {
                    s.Add($"PERCENT_DISCOUNT = '{txtPercent.Text}'");
                }
                else
                {
                    MessageBox.Show("Chiết khấu nằm trong khoảng từ 0 đến 1");
                    txtPercent.Focus();
                    return;
                }
            }
            else if (!string.IsNullOrWhiteSpace(txtPercent.Text))
            {
                MessageBox.Show("Nhập sai định dạng chiết khấu. Chuyển thành số hoặc xóa đi");
                txtPercent.Focus();
                return;
            }
            if (dateTimePicker1.CustomFormat != " " && dateTimePicker2.CustomFormat != " ")
            {
                if (dateTimePicker1.Value >= dateTimePicker2.Value)
                {
                    MessageBox.Show("ngày kết thúc phải diễn ra sau ngày bắt đầu");
                    dateTimePicker2.Focus();
                    return;
                }
                else
                {
                    s.Add($"START_DATE >= #{dateTimePicker1.Value.ToString("MM/dd/yyyy")}#");
                    s.Add($"END_DATE <= #{dateTimePicker2.Value.ToString("MM/dd/yyyy")}#");
                }
            }
            else if(dateTimePicker1.CustomFormat != " ")
            {
                s.Add($"START_DATE >= #{dateTimePicker1.Value.ToString("MM/dd/yyyy")}#");
            }
            else if(dateTimePicker2.CustomFormat != " ")
            {
                s.Add($"END_DATE <= #{dateTimePicker2.Value.ToString("MM/dd/yyyy")}#");
            }
            temp(string.Join(" AND ", s));
        }
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            if (dtp.CustomFormat == " ")
                dtp.CustomFormat = "dd/MM/yyyy";
        }
    }
}
