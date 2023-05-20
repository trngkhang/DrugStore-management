using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TaiKhoanBUS
    {
        private static TaiKhoanBUS instance;
        public static TaiKhoanBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaiKhoanBUS();
                }
                return instance;
            }

        }

        public TaiKhoanBUS()
        {

        }
        
        public TaiKhoan checkAccount(String tendn, String pass)
        {
            return DAO.TaiKhoanDAO.Instance.checkAccount(tendn, pass);
        }
        public bool doiMatKhau(String pass, String newpass)
        {
            return DAO.TaiKhoanDAO.Instance.doiMatKhau(pass, newpass);
        }
    }

}
