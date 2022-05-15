using System;
using System.Collections.Generic;
using System.Text;

namespace GSMS.DTO
{
    public class StorageD
    {
		/*CREATE TABLE Storage
(
	stt INT IDENTITY PRIMARY KEY,
	tenKho NVARCHAR(100) NOT NULL,
	idProduct INT NOT NULL,
	ngaynhap DATETIME NOT NULL,
	slconlai INT NOT NULL,
	FOREIGN KEY (idProduct) REFERENCES dbo.Products (idProduct)
)
         */
		private int stt;
		private string tenKho;
		private string tenSP;
		private int sl;
		private DateTime? ngaynhap;
		public int STT
        {
            get
            {
				return stt;
            }
            set
            {
				stt = value;
            }
        }
        public string TenKho
        {
            get
            {
                return tenKho;
            }
            set
            {
                tenKho = value;
            }

        }
        public string TenSP        
        {
            get
            {
                return tenSP;
            }
            set
            {
                tenSP = value;
            }
        }
        public int SL
        {
            get
            {
                return sl;
            }
            set
            {
                sl = value;
            }
        }
        public DateTime? NgayNhap
        {
            get
            {
                return ngaynhap;
            }
            set
            {
                ngaynhap = value;
            }
        }
    }
}
