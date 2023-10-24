using MiniStoreManagement.BUS;
using MiniStoreManagement.GUI.items;
using MiniStoreManagement.GUI.UCs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStoreManagement.GUI
{
    public partial class Main : Form
    {
        //int panelWidth;
        //bool Hidden;
        private Button selectedButton;
        public Main()
        {
            InitializeComponent();


            //panelWidth = panelSlide.Width;
            //Hidden = false;
            readCate();
            CustomizeDesign();

            //string fontPath = "D:/font/Truculenta/Truculenta-VariableFont_opsz,wdth,wght.ttf";

            //PrivateFontCollection pfc = new PrivateFontCollection();
            //pfc.AddFontFile(fontPath);
            //foreach (Control c in this.Controls)
            //{
            //    c.Font = new Font(pfc.Families[0], 10, FontStyle.Regular);
            //}
        }

        private void readCate()
        {
            CategoryBUS categoryBUS = new CategoryBUS();
            categoryBUS.getCategory();
            int row = CategoryBUS.CategoryList.Rows.Count;
            panel2.Height = panel2.Height * (row + 1);
            for(int i = 0; i < row; i++)
            {
                buttonSub newbut = new buttonSub();
                newbut.GetButton().Text = CategoryBUS.CategoryList.Rows[i][1].ToString();
                newbut.Name = "btn" + i;
                newbut.Dock = DockStyle.Bottom;
                panel2.Controls.Add(newbut);
            }

        }

        private void CustomizeDesign()
        {
            panel2.Visible = false;
            panel5.Visible = false;
        }

        private void hideSubMenu()
        {
            if(panel2.Visible == true)
            {
                panel2.Visible = false;
            }
            if (panel5.Visible == true)
            {
                panel5.Visible = false;
            }
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }



        private void Button_Click(object sender, EventArgs e)
        {
            if (selectedButton != null)
            {
                selectedButton.BackColor = Color.FromArgb(4, 70, 112);
            }

            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.FromArgb(4, 100, 112);
            selectedButton = clickedButton;

            foreach (Control control in panel4.Controls)
            {
                if (control is UserControl)
                {
                    panel4.Controls.Remove(control);
                }
            }
            switch(clickedButton.Name)
            {
                case "btnEmployee":
                    hideSubMenu();
                    EmployeeUC employeeUC = new EmployeeUC();
                    employeeUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(employeeUC);
                    break;

                case "btnProvider":
                    hideSubMenu();
                    break;

                case "btnPromotion":
                    hideSubMenu();
                    PromotionUC promotionUC = new PromotionUC();
                    promotionUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(promotionUC);
                    break;

                case "btnConsumer":
                    hideSubMenu();
                    break;

                case "btnInvoice":
                    showSubMenu(panel5);
                    SalesInvoiceUC salesInvoiceUC = new SalesInvoiceUC();
                    salesInvoiceUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(salesInvoiceUC);
                    break;

                case "btnVoucher":
                    hideSubMenu();
                    break;

                case "btnProduct":
                    showSubMenu(panel2);
                    break;
            }

        }


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    timer1.Start();
        //}

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    if(Hidden)
        //    {
        //        panelSlide.Width = panelSlide.Width + 10;
        //        if(panelSlide.Width > panelWidth)
        //        {
        //            timer1.Stop();
        //            Hidden = false;
        //            this.Refresh();
        //        }
        //    }
        //    else
        //    {
        //        panelSlide.Width = panelSlide.Width - 10;
        //        if(panelSlide.Width <= 0)
        //        {
        //            timer1.Stop();
        //            Hidden = true;
        //            this.Refresh();
        //        }
        //    }
        //}
    }
}
