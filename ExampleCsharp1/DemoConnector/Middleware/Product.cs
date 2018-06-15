using System;
using System.Collections.Generic;

namespace DemoConnector.Middleware
{
    public class Product
    {
        public enum TaxGroupEnum
        {
            Geen = 0,
            Laag = 1, 
            Hoog = 2,
        }

        public Product()
        {
            ExtraFields = new List<ExtensionData>();
        }

        public PriceType TaxOptions { get; set; }
        public String Code { get; set; }
        public String Description { get; set; }
        public String SalesPrice { get; set; }
        public Decimal PurchasePrice { get; set; }
        public String MaxDiscountRate { get; set; }
        public Int32 SalesGroupNumber { get; set; }
        public TaxGroupEnum TaxGroup { get; set; }
        public Int32 DiscountGroupNumber { get; set; }
        public String Unit { get; set; }
        public Decimal BestelEenheid { get; set; }
        public String SupplierCode { get; set; }
        public Boolean Voorraadcontrole { get; set; }
        public Decimal MinimumStock { get; set; }
        public Decimal PreferredStock { get; set; }
        public Boolean StockControl { get; set; }
        public int Grootboek { get; set; }
        public List<ExtensionData> ExtraFields { get; set; }
    }
}
