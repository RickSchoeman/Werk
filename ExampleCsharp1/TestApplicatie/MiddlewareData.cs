using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.Middleware;
using TestApplicatie.Interfaces;

namespace TestApplicatie
{
    public class MiddlewareData : IMiddlewareData
    {
        public List<CustomerResponse> GetCustomerData()
        {
            var cr = new CustomerResponse
            {
                Code = "1797",
                Name = "testCust"
            };
            cr.Addresses.General = new PostalAddress
            {
                Address1 = "testaddress",
                City = "veenendaal",
                Country =
                {
                    Code = "NL",
                    Name = "Nederland"
                },
                ZipCode = "3905GG"
            };
            cr.Bank.Name = "testbank";
            cr.Bank.AccountHolder = "1002";
            cr.Bank.AccountNumber = "12345";
            return new List<CustomerResponse> { cr };
        }

        public List<SupplierResponse> GetSupplierData()
        {
            var address = new PostalAddress
            {
                Address1 = "testbedrijf",
                City = "Veenendaal",
                ContactPerson = "testsupplier",
                ZipCode = "3903AA"
            };
            address.Country.Code = "NL";
            address.Country.Name = "Nederland";
            var supplierresponse = new SupplierResponse
            {
                Name = "testsupplier",
                Code = "2790",
                Comment = "test",
                VatNumber = "1",
                Website = "test.nl"
            };
            supplierresponse.Bank.Name = "Bank";
            supplierresponse.Bank.AccountNumber = "12345";
            supplierresponse.Bank.AccountHolder = "testsupplier";
            supplierresponse.Bank.Iban = "NL32INGB0000012345";
            supplierresponse.Addresses.General = address;
            supplierresponse.PhoneNumbers.General = "03181111111";
            supplierresponse.PhoneNumbers.Mobile = "0611111111";
            return new List<SupplierResponse>{supplierresponse};
        }

        public List<Product> GetProductData()
        {
            var product = new Product
            {
                Code = "9999",
                Description = "testproduct",
                MaxDiscountRate = "",
                SupplierCode = "00006",
                SalesPrice = "100",
                BestelEenheid = 1,
                Grootboek = "4080"

            };
            return new List<Product>{product};
        }

        public List<SalesInvoiceResponse> GetSalesInvoiceData()
        {
            var salesinvoicelines = new List<SalesInvoiceLine>();
            var salesinvoiceline = new SalesInvoiceLine
            {
                Amount = 1,
                Currency = "EUR",
                Description = "test",
                Quantity = 2,
                VatPercent = 0,
                VatType = "sales",
                Article = "FRUIT",
                Subarticle = "BANAAN"
            };
            salesinvoicelines.Add(salesinvoiceline);

            var salesinvoiceresponse = new SalesInvoiceResponse
            {
                CustomerId = "1002",
                Project = "",
                CustomerReference = "1002",
                Name = "test",
                OrderNummer = "10",
                OrderType = "FACTUUR"
            };
            salesinvoiceresponse.SalesInvoiceLines.SalesInvoiceLine = salesinvoicelines;
            return new List<SalesInvoiceResponse>{salesinvoiceresponse};
        }

        public List<GeneralLedgerResponse> GetBalanceSheetData()
        {
            var gl = new GeneralLedgerResponse
            {
                Name = "Test",
                Code = "3999",
                Type = "BAS"
            };
            return new List<GeneralLedgerResponse>{gl};
        }

        public List<GeneralLedgerResponse> GetProfitAndLossData()
        {
            var gl = new GeneralLedgerResponse
            {
                Name = "Test",
                Code = "9999",
                Type = "PNL"
            };
            return new List<GeneralLedgerResponse>{gl};
        }

        public List<CostCenterResponse> GetCostCenterData()
        {
            var costCenterResponse = new CostCenterResponse
            {
                Code = "09998",
                Name = "Test Cost Center",
                Website = "test.nl"
            };
            return new List<CostCenterResponse>{costCenterResponse};
        }
    }
}
