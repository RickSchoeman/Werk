using System.Collections.Generic;
using DemoConnector.Middleware;
using DemoConnector.TwinfieldAPI.Converters.Interfaces;
using DemoConnector.TwinfieldAPI.Data.Suppliers;
using DemoConnector.TwinfieldAPI.Data.Relations;
using Bank = DemoConnector.TwinfieldAPI.Data.Relations.Bank;
using BankM = DemoConnector.Middleware.Bank;

namespace DemoConnector.TwinfieldAPI.Converters
{
    public class SupplierConverter : ISupplierConverter
    {
        public Supplier ConvertSupplierResponse(SupplierResponse supplierResponse, string office)
        {
            var banks = new List<Bank>();
            var bank = new Bank
            {
                Ascription = supplierResponse.Bank.AccountHolder,
                Accountnumber = supplierResponse.Bank.AccountNumber,
                Bankname = supplierResponse.Bank.Name,
                Biccode = supplierResponse.Bank.BicCode,
                Iban = supplierResponse.Bank.Iban,
                Address = new Address
                {
                    Field2 = string.Empty,
                    Field3 = string.Empty
                }
            };
            banks.Add(bank);

            var a = supplierResponse.Addresses.General;
            var addresses = new List<Address>();
                var address = new Address
                {
                    Name = a.Address1,
                    City = a.City,
                    Contact = a.ContactPerson,
                    Country = a.Country.Code,
                    Postcode = a.ZipCode
                };
            addresses.Add(address);
            
            return new Supplier
            {
                Office = office,
                Name = supplierResponse.Name,
                Code = supplierResponse.Code,
                Website = supplierResponse.Website,
                Paymentconditions = new Paymentconditions
                {
                    Paymentcondition = new List<Paymentcondition>()
                },
                Postingrules = new Postingrules
                {
                    Postingrule = new List<Postingrule>()
                },
                Financials = new Financials
                {
                    Matchtype = MatchType.Customersupplier,
                    Accounttype = "inherit",
                    Level = 2,
                    Vatcode = new VatCode()
                },
                Banks = new Banks
                {
                    Bank = banks
                },
                Addresses = new Addresses
                {
                    Address = addresses
                }
            };
        }

        public SupplierResponse ConvertSupplier(Supplier supplier)
        {
            var phonenumber = string.Empty;
            var mobilenumber = string.Empty;
            var faxnumber = string.Empty;
            var address = new PostalAddress();
            for (int i = 0; i < supplier.Addresses.Address.Count; i++)
            {
                var a = supplier.Addresses.Address[i];
                if (a.Telephone.StartsWith("06"))
                {
                    mobilenumber = a.Telephone;
                }
                else
                {
                    phonenumber = a.Telephone;
                }

                faxnumber = a.Telefax;
                address = new PostalAddress
                {
                    Address1 = a.Name,
                    City = a.City,
                    ContactPerson = a.Contact,
                    ZipCode = a.Postcode
                };
                address.Country.Code = a.Country;
                address.Country.Name = a.CountryName;
            }
            var bank = new BankM();
            for (int i = 0; i < supplier.Banks.Bank.Count; i++)
            {
                if (supplier.Banks.Bank[i] != null)
                {
                    bank.AccountNumber = supplier.Banks.Bank[i].Accountnumber;
                    bank.AccountHolder = supplier.Banks.Bank[i].Ascription;
                    bank.BicCode = supplier.Banks.Bank[i].Biccode;
                    bank.Iban = supplier.Banks.Bank[i].Iban;
                    bank.Name = supplier.Banks.Bank[i].Bankname;
                }
            }
            
            var supplierResponse = new SupplierResponse
            {
                Name = supplier.Name,
                Code = supplier.Code,
                VatNumber = supplier.Vatnumber,
                Comment = supplier.Shortname,
                Website = supplier.Website,
            };
            supplierResponse.Addresses.General = address;
            supplierResponse.Bank.Name = bank.Name;
            supplierResponse.Bank.AccountNumber = bank.AccountNumber;
            supplierResponse.Bank.AccountHolder = bank.AccountHolder;
            supplierResponse.Bank.BicCode = bank.BicCode;
            supplierResponse.Bank.Iban = bank.Iban;
            supplierResponse.PhoneNumbers.General = phonenumber;
            supplierResponse.PhoneNumbers.Fax = faxnumber;
            supplierResponse.PhoneNumbers.Mobile = mobilenumber;
            supplierResponse.MailAddresses.General.To = supplier.Financials.Ebillmail;
            supplierResponse.MailAddresses.Invoice.To = supplier.Financials.Ebillmail;
            return supplierResponse;
        }
    }
}

