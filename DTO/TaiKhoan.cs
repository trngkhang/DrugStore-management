using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoan
    {
        private string tendn;
        private string pass;
        public TaiKhoan(string tendn, string pass)
        {
            this.tendn = tendn;
            this.pass = pass;
        }
        public TaiKhoan(DataRow row)
        {
            this.TENDN = row["TENDN"].ToString();
            this.PASS = row["PASS"].ToString();
        }
        public TaiKhoan()
        {

        }
        
        public string TENDN { get => tendn; set => tendn = value; }
        public string PASS { get => pass; set => pass = value; }
    }
}
