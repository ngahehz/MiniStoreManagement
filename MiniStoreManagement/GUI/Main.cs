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
using MiniStoreManagement.GUI;

namespace MiniStoreManagement.GUI
{
    public partial class Main : Form
    {
        public delegate void truyenDuLieu();
        public truyenDuLieu showBase;
        
        private Button selectedButton;
        private Color selectedColor;
        private Button selectedSubButton;
        private bool form_close = false;
        private bool bin = false;
        private string pic_control = null;
        private int initial_width;
        public Main()
        {
            InitializeComponent();

            readCate();
            CustomizeDesign();

            InitialBUS initialBUS = new InitialBUS();
            initialBUS.checkPromotion();
            initialBUS.checkVoucher();
        }

        private void readCate()
        {
            CategoryBUS categoryBUS = new CategoryBUS();
            categoryBUS.getCategory();
            int row = show_data().Rows.Count;
            panel2.Height = panel2.Height * (row);

            //for(int i = 0; i < row; i++)
            //{
            //    buttonSub newbut = new buttonSub();
            //    newbut.GetButton().Text = CategoryBUS.CategoryList.Rows[i][1].ToString();
            //    newbut.Name = CategoryBUS.CategoryList.Rows[i][0].ToString();
            //    newbut.Dock = DockStyle.Bottom;
            //    panel2.Controls.Add(newbut);
            //}

            foreach (DataRow _row in show_data().Rows)
            {
                string id = _row["ID"].ToString();
                string name = _row["NAME"].ToString();

                buttonSub button = new buttonSub();
                button.GetButton().Text = name;
                button.GetButton().Name = "btn_" + id;
                button.Dock = DockStyle.Bottom;
                button.GetButton().Click += SubButton_Click;

                panel2.Controls.Add(button);
            }
        }

        private void CustomizeDesign()
        {
            panel2.Visible = false;
            initial_width = this.Width;
        }

        private void hideSubMenu()
        {
            if (panel2.Visible == true)
            {
                panel2.Visible = false;
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
                selectedSubButton.BackColor = SystemColors.HighlightText;
            }

            Button clickedButton = (Button)sender;
            clickedButton.BackColor = SystemColors.InactiveCaption;
            selectedSubButton = clickedButton;

            panel4.Controls.Clear();

            foreach (DataRow _row in show_data().Rows)
            {
                if (clickedButton.Name == "btn_" + _row["ID"].ToString())
                {
                    ProductUC productUC = new ProductUC(int.Parse(_row["ID"].ToString()));
                    productUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(productUC);
                    break;
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            if(selectedButton == null)
                selectedColor = clickedButton.BackColor;

            else 
            {
                selectedButton.BackColor = selectedColor;
                selectedColor = clickedButton.BackColor;
                /*selectedButton.BackColor = Color.FromArgb(4, 70, 112);*/ // màu cũ
            }
            if (selectedSubButton != null)
            {
                selectedSubButton.BackColor = SystemColors.HighlightText;
            }

            clickedButton.BackColor = Color.CornflowerBlue; // màu mới
            //int newBlueValue = Math.Min(clickedButton.BackColor.B + 60, 255);
            //clickedButton.BackColor = Color.FromArgb(clickedButton.BackColor.R, clickedButton.BackColor.G, newBlueValue); // màu mới
            selectedButton = clickedButton;

            panel4.Controls.Clear();
            this.Width = initial_width;

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
                    picBin.Visible = true;
                    picBack.Visible = false;
                    pic_control = "Promotion";
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
                    pic_control = "Invoice";
                    InvoiceUC invoiceUC = new InvoiceUC();
                    invoiceUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(invoiceUC);
                    break;

                case "btnVoucher":
                    hideSubMenu();
                    bin = false;
                    picBin.Visible = true;
                    picBack.Visible = false;
                    pic_control = "Voucher";
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

                case "btnStatistics":
                    hideSubMenu();
                    bin = false;
                    picBin.Visible = false;
                    picBack.Visible = false;
                    ThongKeUC thongKeUC = new ThongKeUC();
                    thongKeUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(thongKeUC);
                    break;

                case "btnStockroom":
                    hideSubMenu();
                    bin = false;
                    picBin.Visible = false;
                    picBack.Visible = false;
                    StockroomUC stockroomUC = new StockroomUC();
                    stockroomUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(stockroomUC);
                    break;
            }
        }

        private void picBin_Click(object sender, EventArgs e)
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

                case "Invoice":
                    InvoiceUC invoiceUC = new InvoiceUC("0");
                    invoiceUC.Name = "binUC";
                    invoiceUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(invoiceUC);
                    picBack.Visible = true;
                    break;

                case "Promotion":
                    PromotionUC promotionUC = new PromotionUC("0");
                    promotionUC.Name = "binUC";
                    promotionUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(promotionUC);
                    picBack.Visible = true;
                    break;

                case "Voucher":
                    VoucherUC voucherUC = new VoucherUC("0");
                    voucherUC.Name = "binUC";
                    voucherUC.Dock = DockStyle.Fill;
                    panel4.Controls.Add(voucherUC);
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
                else
                {
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
                        case "Invoice":
                            InvoiceUC invoiceUC = (InvoiceUC)control;
                            invoiceUC.showdata(1);
                            invoiceUC.showdata(2);
                            break;
                        case "Promotion":
                            PromotionUC promotionUC = (PromotionUC)control;
                            promotionUC.showdata();
                            break;
                        case "Voucher":
                            VoucherUC voucherUC = (VoucherUC)control;
                            voucherUC.showdata();
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

        private DataTable show_data()
        {
            var filteredRows = CategoryBUS.CategoryList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
            return filteredRows.Any() ? filteredRows.CopyToDataTable() : CategoryBUS.CategoryList.Clone();
        }

        private void fToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            hideSubMenu();
            UpaccountUC upaccount = new UpaccountUC();
            upaccount.Dock = DockStyle.Fill;
            panel4.Controls.Add(upaccount);
        }


        private void fToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            hideSubMenu();
            ListAdminUC listAccount = new ListAdminUC();
            listAccount.Dock = DockStyle.Fill;
            panel4.Controls.Add(listAccount);
        }

        private void fToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            form_close = true;
            this.Close();
            showBase();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            bin = false;
            picBin.Visible = false;
            picBack.Visible = false;
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


// TÌM CÁCH BỎ FONT VÀO MÀ HONG ĐƯỢC

//string fontPath = "D:/font/Truculenta/Truculenta-VariableFont_opsz,wdth,wght.ttf";

//PrivateFontCollection pfc = new PrivateFontCollection();
//pfc.AddFontFile(fontPath);
//foreach (Control c in this.Controls)
//{
//    c.Font = new Font(pfc.Families[0], 10, FontStyle.Regular);
//}

// 

//switch (clickedButton.Name)
//{
//    case "btnsub_invoice1":
//        break;

//    case "btnsub_invoice2":
//        //InvoiceDetailUC invoiceDetailUC = new InvoiceDetailUC();
//        //invoiceDetailUC.Dock = DockStyle.Fill;
//        //panel4.Controls.Add(invoiceDetailUC);
//        break;
//}