using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStoreManagement.GUI.items
{
    public partial class textBoxCustom : UserControl
    {
        private string text = "";
        public textBoxCustom()
        {
            InitializeComponent();
        }

        public string customText
        {
            get { return text; }
            set
            {
                text = value;
                this.Invalidate();
            }
        }

        private void textBoxCustom_Paint(object sender, PaintEventArgs e)
        {
            label1.Text = customText;
        }
    }
}
