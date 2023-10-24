using MiniStoreManagement.GUI;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStoreManagement
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            // Đường dẫn tới tệp font đã sao chép vào dự án
            //string fontPath = Path.Combine(Application.StartupPath, "FontFolder", "YourCustomFont.ttf");

            //string fontPath = "D:/font/Truculenta/Truculenta-VariableFont_opsz,wdth,wght.ttf";

            //PrivateFontCollection pfc = new PrivateFontCollection();
            //pfc.AddFontFile(fontPath);
            //foreach(Control c in this.Controls)
            //{

            //}

            //if (File.Exists(fontPath))
            //{
            //    // Tạo một PrivateFontCollection
            //    PrivateFontCollection privateFonts = new PrivateFontCollection();

            //    // Thêm font vào PrivateFontCollection
            //    privateFonts.AddFontFile(fontPath);

            //    // Lấy font từ PrivateFontCollection
            //    Font customFont = new Font(privateFonts.Families[0], 12); // 12 là kích thước font

            //    // Gán font cho toàn bộ ứng dụng
            //    ControlPaint.Font = customFont;

            //    // Xóa PrivateFontCollection sau khi đã sử dụng
            //    privateFonts.Dispose();
            //}


            Application.Run(new Main());
        }
    }
}
