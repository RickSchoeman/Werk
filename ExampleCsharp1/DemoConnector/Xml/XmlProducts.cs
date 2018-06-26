using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConnector.Xml
{
    public class XmlProducts
    {
        public List<XmlProduct> Products { get; set; }
    }

    public class XmlProduct
    {
        public XmlPriceType TaxOptions { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string SalesPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public string MaxDiscountRate { get; set; }
        public int SalesGroupNumber { get; set; }
        public XmlTaxGroupEnum TaxGroup { get; set; }
        public int DiscountGroupMember { get; set; }
        public string Unit { get; set; }
        public decimal BestelEenheid { get; set; }
        public string SupplierCode { get; set; }
        public bool Voorraadcontrole { get; set; }
        public decimal MinimumStock { get; set; }
        public decimal PreferedStock { get; set; }
        public bool StockControl { get; set; }
        public string Grootboek { get; set; }
    }

    public enum XmlPriceType
    {
        Unknown = 0,
        Inclusive = 1,
        Exclusive = 2
    }

    public enum XmlTaxGroupEnum
    {
        Geen = 0,
        Laag = 1,
        Hoog = 2
    }
}
