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
            double temp1, temp2;

            if (double.TryParse(txtPercent1.Text, out temp1))
            {
                if (temp1 > 0 || temp1 < 1)
                {
                    //s.Add($"PERCENT_DISCOUNT = '{txtPercent1.Text}'");
                }
                else
                {
                    MessageBox.Show("Chiết khấu nằm trong khoảng từ 0 đến 1");
                    txtPercent1.Focus();
                    return;
                }
            }
            else if (!string.IsNullOrWhiteSpace(txtPercent1.Text))
            {
                MessageBox.Show("Nhập sai định dạng chiết khấu. Chuyển thành số hoặc xóa đi");
                txtPercent1.Focus();
                return;
            }

            if (double.TryParse(txtPercent2.Text, out temp2))
            {
                if (temp2 > 0 || temp2 < 1)
                {
                    //s.Add($"PERCENT_DISCOUNT = '{txtPercent2.Text}'");
                }
                else
                {
                    MessageBox.Show("Chiết khấu nằm trong khoảng từ 0 đến 1");
                    txtPercent2.Focus();
                    return;
                }
            }
            else if (!string.IsNullOrWhiteSpace(txtPercent2.Text))
            {
                MessageBox.Show("Nhập sai định dạng chiết khấu. Chuyển thành số hoặc xóa đi");
                txtPercent2.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtPercent1.Text) && !string.IsNullOrWhiteSpace(txtPercent2.Text))
            {
                if(temp1 > temp2)
                {
                    MessageBox.Show("Chiết khấu đầu phải nhỏ hơn chiếu khấu sau");
                    return;
                }
                else
                {
                    s.Add($"PERCENT_DISCOUNT >= {temp1}");
                    s.Add($"PERCENT_DISCOUNT <= {temp2}");
                }
            }
            else if (string.IsNullOrWhiteSpace(txtPercent1.Text))
            {
                s.Add($"PERCENT_DISCOUNT <= {temp2}");
            }
            else if (string.IsNullOrWhiteSpace(txtPercent2.Text))
            {
                s.Add($"PERCENT_DISCOUNT >= {temp1}");
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
