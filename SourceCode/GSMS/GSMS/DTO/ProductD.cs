using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMS.DTO
{
    public class ProductD
    {
        /*
        idProduct INT IDENTITY PRIMARY KEY NOT NULL,
	nameProduct NVARCHAR(100) NOT NULL, 
	price float NOT NULL,
	idSupplier INT NOT NULL,
	FOREIGN KEY (idSupplier) REFERENCES dbo.Supplier (idSupplier)
         */
        private string idProduct;
        private string nameProduct;
        private string price;
        #region
        public string IdProduct
        {
            get
            {
                return idProduct;
            }
            set
            {
                idProduct=value;
            }
        }
        public string NameProduct
        {
            get
            {
                return nameProduct;
            }
            set
            {
                nameProduct = value;
            }
        }
        public string Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        #endregion
    }
}
