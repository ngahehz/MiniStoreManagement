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
    public partial class textBox_Test : TextBox
    {
        private Color _bottomBoderColor = Color.Black;
        private Color _onFocusColor = Color.Blue;
        public textBox_Test()
        {
            BorderStyle = BorderStyle.None;
            AutoSize = false;

            //add lable to control
            Controls.Add(new Label
            {
                Height = 2,
                Dock = DockStyle.Bottom,
                BackColor = _bottomBoderColor
            });
            InitializeComponent();
        }

        //hides the borderstyle from control property
        // so to avoid people changing borderstyle of the textbox
        [Browsable(false)]

        public new BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
            set { base.BorderStyle = value; }
        }

        public Color BottomBorderColor
        {
            get { return _bottomBoderColor; }
            set
            {
                _bottomBoderColor = value;
                Controls[0].BackColor = _bottomBoderColor;
            }
        }

        public Color BottomBoderOnFocusColor
        {
            get { return _onFocusColor; }
            set { _onFocusColor = value; }
        }

        private void textBox_Test_Enter(object sender, EventArgs e)
        {
            Controls[0].BackColor = _onFocusColor;
        }

        private void textBox_Test_Leave(object sender, EventArgs e)
        {
            Controls[0].BackColor = _bottomBoderColor;
        }
    } 
}
