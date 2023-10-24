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
    public partial class buttonSub : UserControl
    {
        public buttonSub()
        {
            InitializeComponent();
        }

        public Button GetButton()
        {
            return button1;
        }
    }
}
