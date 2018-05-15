using System;
using System.Collections.Generic;

namespace DemoConnector.Middleware
{
    class OrderBaseResponse 
    {
        public String PaymentReference { get; set; }
        public ExtensionValue SysteemReference { get; set; }
        public ExtensionValue UserReference { get; set; }
        public DateTime Date { get; set; }
        public Decimal DiscountRate { get; set; }
        public String Discription { get; set; }
        public String Comment { get; set; }
        public ExtensionValue CostCenterReference { get; set; }
        public PriceType PriceType { get; set; }
        public ExtensionDataCollection ExtraFields { get; set; }
        public List<BaseOrderLine> Lines { get; set; }

        public OrderBaseResponse()
        {
            Date = DateTime.Now;
            Lines = new List<BaseOrderLine>();
            ExtraFields = new ExtensionDataCollection();
        }
    }

    public enum PriceType
    {
        Unknown = 0,
        Inclusive = 1,
        Exclusive = 2,
    }

    public enum OrderLineType
    {
        Unknown = 0,
        Product,
        Shipping,
        Discount,
        Payment,
        Text,
        Totaal,
    }

    public class BaseOrderLine
    {
        public OrderLineType Type { get; set; }
        public String _productCode;
        public String ProductCode {
            get
            {
                if (Product == null)
                {
                    return _productCode;
                }

                return Product.Code;
            }
            set
            {
                _productCode = value;
                if (ProductCode == null)
                {
                    return;
                }

                Product.Code = value;
            }
        }

        private Product _product;

        public Product Product
        {
            get
            {
                return _product; 

            }
            set {
                if (value == null && _product != null)
                {
                    _productCode = _product.Code;
                }

                _product = value;
            }
        }
        public String Description { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal SalesPrice { get; set; }
        public Decimal DiscountRate { get; set; }
        public Decimal TaxValue { get; set; }
        public List<ProductOption> Options { get; set; }
        public ExtensionDataCollection ExtraFields { get; set; }

    }

    public class ProductOption
    {
        public String Name { get; set; }
        public String Value { get; set; }
    }
}
