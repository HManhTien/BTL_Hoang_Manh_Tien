using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chatbotc
{
    
    public  class HoiDap
    {
        public HoiDap() { }

        internal static string timkiemkhachhang(string tenkh)
        {
            string chuoiketnoi = @"Data Source=HOANGTIEN\SQL;Initial Catalog=QL_BHST_GO;Integrated Security=True";

            string kq = "";
            try
            {
                using (SqlConnection cn = new SqlConnection(chuoiketnoi))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandText = "cocaicut";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.Add("@ten", SqlDbType.NVarChar, 20).Value = tenkh;
                        
                        object obj = cm.ExecuteScalar(); //lấy col1 of row1
                        if (obj != null)
                            kq = (string)obj;
                        else
                            kq = $"khong co khach hang nao ten : {tenkh}";
                    }
                }
            }
            catch (Exception ex)
            {
                kq += $"Error: {ex.Message}";
            }
            return kq;
        
    }

        internal static string tkhd(string tkhd)
        {

            string chuoiketnoi = @"Data Source=HOANGTIEN\SQL;Initial Catalog=QL_BHST_GO;Integrated Security=True";
            string kq1 = "";
            try
            {
                using (SqlConnection cn = new SqlConnection(chuoiketnoi))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandText = "tkhd";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.Add("@tenhd", SqlDbType.NVarChar, 20).Value = tkhd;

                        object obj = cm.ExecuteScalar(); //lấy col1 of row1
                        if (obj != null)
                            kq1 = (string)obj;
                        else
                            kq1 = $"khong co khach hang nao ten : {tkhd}";
                    }
                }
            }
            catch (Exception ex)
            {
                kq1 += $"Error: {ex.Message}";
            }
            return kq1;
        }
    }
}
