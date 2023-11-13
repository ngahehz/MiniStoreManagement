﻿using MiniStoreManagement.BUS;
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
        private Button selectedSubButton;
        private bool form_close = false;
        private bool bin = false;
        private string pic_control = null;
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

        private void SubButton_Click(object sender, EventArgs e)
        {
            if (selectedSubButton != null)
            {
                selectedSubButton.BackColor = SystemColors.Info;
            }

            Button clickedButton = (Button)sender;
            clickedButton.BackColor = SystemColors.InactiveCaption;
            selectedSubButton = clickedButton;

            //foreach (Control control in panel4.Controls)
            //{
            //    if (control is UserControl)
            //    {
            //        panel4.Controls.Remove(control);
            //    }
            //}

            panel4.Controls.Clear();

            switch (clickedButton.Name)
            {
                case "btnsub_invoice1":
                    InvoiceUC invoiceUC = new InvoiceUC();
                    invoiceUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(invoiceUC);
                    break;

                case "btnsub_invoice2":
                    InvoiceDetailUC invoiceDetailUC = new InvoiceDetailUC();
                    invoiceDetailUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(invoiceDetailUC);
                    break;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (selectedButton != null)
            {
                selectedButton.BackColor = Color.FromArgb(4, 70, 112);
            }
            if (selectedSubButton != null)
            {
                selectedSubButton.BackColor = SystemColors.Info;
            }

            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.FromArgb(4, 100, 112);
            selectedButton = clickedButton;

            //foreach (Control control in panel4.Controls)
            //{
            //    if (control is UserControl)
            //    {
            //        panel4.Controls.Remove(control);
            //    }
            //}

            panel4.Controls.Clear();

            switch (clickedButton.Name)
            {
                case "btnEmployee":
                    hideSubMenu();
                    bin = false;
                    picBin.Visible = true;
                    picBack.Visible = false;
                    pic_control = "Employee";
                    EmployeeUC employeeUC = new EmployeeUC();
                    employeeUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(employeeUC);
                    break;

                case "btnProvider":
                    hideSubMenu();
                    bin = false;
                    picBin.Visible = true;
                    picBack.Visible = false;
                    pic_control = "Provider";
                    ProviderUC providerUC = new ProviderUC();
                    providerUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(providerUC);
                    break;

                case "btnPromotion":
                    hideSubMenu();
                    bin = false;
                    picBin.Visible = false;
                    picBack.Visible = false;
                    PromotionUC promotionUC = new PromotionUC();
                    promotionUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(promotionUC);
                    break;

                case "btnConsumer":
                    hideSubMenu();
                    bin = false;
                    picBin.Visible = false;
                    picBack.Visible = false;
                    ConsumerUC consumerUC = new ConsumerUC();
                    consumerUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(consumerUC);
                    break;

                case "btnInvoice":
                    bin = false;
                    picBin.Visible = true;
                    picBack.Visible = false;
                    showSubMenu(panel5);
                    break;

                case "btnVoucher":
                    hideSubMenu();
                    bin = false;
                    picBin.Visible = false;
                    picBack.Visible = false;
                    VoucherUC voucherUC = new VoucherUC();
                    voucherUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(voucherUC);
                    break;

                case "btnProduct":
                    showSubMenu(panel2);
                    bin = false;
                    picBin.Visible = true;
                    picBack.Visible = false;
                    pic_control = "Product";
                    ProductUC productUC = new ProductUC();
                    productUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(productUC);
                    break;

                case "btnCategory":
                    hideSubMenu();
                    bin = false;
                    picBin.Visible = true;
                    picBack.Visible = false;
                    pic_control = "Category";
                    CategoryUC categoryUC = new CategoryUC();
                    categoryUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(categoryUC);
                    break;
            }

        }

        private void picBin_Click (object sender, EventArgs e)
        {
            if (bin)
            {
                return;
            }

            bin = true;

            foreach (Control control in panel4.Controls)
            {
                control.Visible = false;
            }
            switch (pic_control)
            {
                case "Category":
                    CategoryUC categoryUC = new CategoryUC("0");
                    categoryUC.Name = "binUC";
                    categoryUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(categoryUC);
                    picBack.Visible = true;
                    break;

                case "Employee":
                    EmployeeUC employeeUC = new EmployeeUC("0");
                    employeeUC.Name = "binUC";
                    employeeUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(employeeUC);
                    picBack.Visible = true;
                    break;

                case "Product":
                    ProductUC productUC = new ProductUC("0");
                    productUC.Name = "binUC";
                    productUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(productUC);
                    picBack.Visible = true;
                    break;
                case "Provider":
                    ProviderUC providerUC = new ProviderUC("0");
                    providerUC.Name = "binUC";
                    providerUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(providerUC);
                    picBack.Visible = true;
                    break;
            }
        }


        private void picBack_Click(object sender, EventArgs e)
        {
            bin = false;
            foreach (Control control in panel4.Controls)
            {
                if (control.Name == "binUC")
                {
                    panel4.Controls.Remove(control);
                }
                else { 
                    control.Visible = true;
                    switch (pic_control)
                    {
                        case "Category":
                            CategoryUC categoryUC = (CategoryUC)control;
                            categoryUC.showdata();
                            break;
                        case "Employee":
                            EmployeeUC employeeUC = (EmployeeUC)control;
                            employeeUC.showdata();
                            break;
                        case "Product":
                            ProductUC productUC = (ProductUC)control;
                            productUC.showdata();
                            break;
                        case "Provider":
                            ProviderUC providerUC = (ProviderUC)control;
                            providerUC.showdata();
                            break;
                    }
                }
            }
            picBack.Visible = false;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (form_close)
            {
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng chương trình không?", "Xác nhận đóng chương trình", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                form_close = true;
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
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
