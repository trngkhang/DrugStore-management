using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAO
{
    public class TaiKhoanDAO
    {

        private static TaiKhoanDAO instance;

        public static TaiKhoanDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaiKhoanDAO();
                }
                return instance;
            }

        }

        private TaiKhoanDAO()
        {
        }
        public TaiKhoan checkAccount(String tendn, String pass)    // Check whether exist an account of user to login
        {
            String query = "proc_Login @tendn , @pass";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tendn, pass });

            if (data.Rows.Count == 0)
            {
                return null;
            }

            return new TaiKhoan(data.Rows[0]);
        }
        public bool doiMatKhau(String pass, String newpass)
        {
            String query = string.Format("UPDATE TaiKhoan SET PASS = '{0}' WHERE PASS = '{1}'", newpass, pass);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}