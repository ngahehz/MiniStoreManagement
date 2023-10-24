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
    public partial class textBoxBorder : UserControl
    {
        private bool muti = false;
        public textBoxBorder()
        {
            InitializeComponent();
        }
        
        public bool cusMuti
        {
            get { return muti; }
            set { muti = value;
                this.Invalidate();}
        }

        private void textBoxBorder_Paint(object sender, PaintEventArgs e)
        {
            if (cusMuti)
            {
                textBox1.Multiline = true;
                textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                textBox1.Height = this.Height;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxBorder_Load(object sender, EventArgs e)
        {

        }
    }
}
