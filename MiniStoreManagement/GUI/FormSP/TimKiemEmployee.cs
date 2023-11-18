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
    public partial class TimKiemEmployee : Form
    {
        public delegate void truyenDuLieu(string txt);
        public truyenDuLieu temp;
        public TimKiemEmployee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> s = new List<string>();
            if (!string.IsNullOrWhiteSpace(txtID.Text))
            {
                s.Add($"ID = '{txtID.Text}'");
            }
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                s.Add($"NAME = '{txtName.Text}'");
            }
            if (!string.IsNullOrWhiteSpace(txtSĐT.Text))
            {
                s.Add($"CELL = '{txtSĐT.Text}'");
            }
            if (dateTimePicker1.CustomFormat != " ")
            {
                s.Add($"DOB = #{dateTimePicker1.Value.ToString("MM/dd/yyyy")}#");
            }
            if (radioButton1.Checked)
            {
                s.Add($"GENDER = 'Nam'");
            }
            else
                s.Add($"GENDER = 'Nữ'");
            temp(string.Join(" AND ", s));
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.CustomFormat == " ")
                dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

    }
}
