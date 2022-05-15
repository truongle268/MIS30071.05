using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMS.DTO
{
    public class NhanVien
    {
        private int idNhanVien;
        private string maNhanVien;
        private string tenNhanVien;
        public NhanVien(int idNhanVien, string maNhanVien, string tenNhanVien)
        {
            this.IdNhanVien = idNhanVien;
            this.MaNhanVien = maNhanVien;
            this.TenNhanVien = tenNhanVien;
        }
        #region
        public int IdNhanVien
        {
            get
            {
                return idNhanVien;
            }

            set
            {
                idNhanVien = value;
            }
        }

        public string MaNhanVien
        {
            get
            {
                return maNhanVien;
            }

            set
            {
                maNhanVien = value;
            }
        }

        public string TenNhanVien
        {
            get
            {
                return tenNhanVien;
            }

            set
            {
                tenNhanVien = value;
            }
        }
        #endregion
    }
}
