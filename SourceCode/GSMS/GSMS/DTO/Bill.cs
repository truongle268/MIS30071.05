using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMS
    .DTO
{
    public class Bill
    {

        private int idBill;
        private string tenNhanVien;
        private DateTime? getIn;
        private string nameProduct;
        private int numberP;
        private float price;
        private float totalPrice;
        #region Properties
        public int IdBill
        {
            get
            {
                return idBill;
            }

            set
            {
                idBill = value;
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

        public DateTime? GetIn
        {
            get
            {
                return getIn;
            }

            set
            {
                getIn = value;
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
        public int NumberP
        {
            get
            {
                return numberP;
            }

            set
            {
                numberP = value;
            }
        }
        public float Price
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

        public float TotalPrice
        {
            get
            {
                return totalPrice;
            }

            set
            {
                totalPrice = value;
            }
        }
        #endregion
    }
}
