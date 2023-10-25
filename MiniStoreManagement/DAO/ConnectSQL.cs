using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Runtime.Remoting.Contexts;

namespace MiniStoreManagement.DAO
{
    public class ConnectSQL
    {
        //private string mySqlCon;
        //private MySqlConnection mySqlConnection;
        public static SqlCommand cmd;
        public SqlConnection conn;

        //public ConnectSQL()
        //{
        //    mySqlCon = "server = 127.0.0.1; user = root; database = test; password = ";
        //    mySqlConnection = new MySqlConnection(mySqlCon);
        //    try
        //    {
        //        mySqlConnection.Open();
        //        MessageBox.Show("Connection Success");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally { mySqlConnection.Close(); }
        //}

        public void Connect()
        {
            string sqlSever = @"Data Source = LAPTOP-P3HQJNQL\NGAHZ; Initial Catalog = ministore; Integrated Security = True";
            conn = new SqlConnection(sqlSever);
            try
            {
                conn.Open();
                //MessageBox.Show("Connection Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //finally { conn.Close(); }
        }

        public DataTable ReadData(string s)
        {
            Connect();
            DataTable dt = new DataTable();
            SqlDataAdapter sqlData = new SqlDataAdapter(s, conn);
            sqlData.Fill(dt);
            CloseConnect();
            sqlData.Dispose();
            return dt;
        }

        //public DataTable ReadData2(string s)
        //{
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter sqlData = new SqlDataAdapter(s, conn);
        //    sqlData.Fill(dt);
        //    CloseConnect();
        //    sqlData.Dispose();

        //    // Định dạng lại các cột kiểu DateTime trong DataTable
        //    foreach (DataColumn column in dt.Columns)
        //    {
        //        if (column.DataType == typeof(DateTime))
        //        {
        //            foreach (DataRow row in dt.Rows)
        //            {
        //                if (!row.IsNull(column))
        //                {
        //                    row[column] = ((DateTime)row[column]).ToString("dd/MM/yyyy");
        //                    MessageBox.Show(((DateTime)row[column]).ToString("dd/MM/yyyy"));
        //                }
        //            }
        //        }
        //    }

        //    return dt;
        //}

        public bool ChangeData(string s)
        {
            MessageBox.Show(s);
            Connect();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = s;
            int row = 0;
            try
            {
                row = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            CloseConnect();
            cmd.Dispose();
            if (row < 1)
                return false;
            return true;
        }

        public void CloseConnect()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}