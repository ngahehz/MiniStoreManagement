using MiniStoreManagement.DTO;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStoreManagement.BUS
{
    internal class InitialBUS
    {
        private PromotionBUS promotionBUS = new PromotionBUS();
        private VoucherBUS voucherBUS = new VoucherBUS();
        private ProductBUS productBUS = new ProductBUS();

        public void checkPromotion()
        {
            if (PromotionBUS.PromotionList == null)
                promotionBUS.getPromotion();
            if(ProductBUS.ProductList == null)
                productBUS.getProduct();

            int count = 0;

            var filteredRows = PromotionBUS.PromotionList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
            
            foreach (DataRow row in filteredRows)
            {
                if ((DateTime)row[4] < DateTime.Now)
                {
                    PromotionDTO promotionDTO = new PromotionDTO(row);
                    promotionDTO.State = "1";
                    if (promotionBUS.updatePromotion(promotionDTO))
                    {
                        count++;
                        row[5] = "1";
                        var filteredRows1 = ProductBUS.ProductList.AsEnumerable().Where(_row => _row.Field<string>("PROMOTION_ID") == promotionDTO.Id);
                        // ban đầu tính dùng showdata nhma thôi ấy hết promotion trong cả sản phẩm xóa luôn
                        foreach (DataRow _row in filteredRows1) 
                        {
                            ProductDTO productDTO = new ProductDTO(_row);
                            productDTO.PromotionId = null;
                            if (productBUS.updateProduct(productDTO))
                            {
                                _row[3] = null;
                            }
                            
                        }
                    }
                }
            }
            if(count > 0)
                MessageBox.Show("Có " + count + " promotion hết hạn");
        }

        public void checkVoucher()
        {
            if (VoucherBUS.VoucherList == null)
                voucherBUS.getVoucher();

            int count = 0;

            var filteredRows = VoucherBUS.VoucherList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");

            foreach (DataRow row in filteredRows)
            {
                if ((DateTime)row[8] < DateTime.Now)
                {
                    VoucherDTO voucherDTO = new VoucherDTO(row);
                    voucherDTO.State = "1";
                    if (voucherBUS.updateVoucher(voucherDTO))
                    {
                        count++;
                        row[9] = "1";
                    }
                }
            }
            if (count > 0)
                MessageBox.Show("Có " + count + " voucher hết hạn");
        }


        //private DataTable show_data(int temp)
        //{
        //    if (temp == 1)
        //    {
        //        var filteredRows = PromotionBUS.PromotionList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
        //        return filteredRows.Any() ? filteredRows.CopyToDataTable() : SalesInvoiceBUS.SalesInvoiceList.Clone();
        //    }
        //    else
        //    {
        //        var filteredRows = ProductBUS.ProductList.AsEnumerable().Where(row => row.Field<string>("STATE") == "0");
        //        return filteredRows.Any() ? filteredRows.CopyToDataTable() : ProductBUS.ProductList.Clone();
        //    }


        //}


    }
}
