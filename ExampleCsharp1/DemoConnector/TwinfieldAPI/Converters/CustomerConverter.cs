using System;
using System.Collections.Generic;
using DemoConnector.Middleware;
using DemoConnector.TwinfieldAPI.Converters.Interfaces;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Customers;
using DemoConnector.TwinfieldAPI.Data.NotImplemented.Relations;
using Bank = DemoConnector.TwinfieldAPI.Data.NotImplemented.Relations.Bank;
using BankM = DemoConnector.Middleware.Bank;

namespace DemoConnector.TwinfieldAPI.Converters
{
    public class CustomerConverter : ICustomerConverter
    {
        public CustomerResponse ConvertCustomer(Customer customer)
        {
            var phonenumber = string.Empty;
            var mobilenumber = string.Empty;
            var faxnumber = string.Empty;
            var address = new PostalAddress();
            foreach (var a in customer.Addresses.Address)
            {
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
                    Address1 = a.Field2,
                    Address2 = a.Field3,
                    City = a.City,
                    ContactPerson = a.Field1,
                    ZipCode = a.Postcode
                };
                address.Country.Code = a.Country;
                address.Country.Name = a.CountryName;
            }

            var bank = new BankM();
            for (int i = 0; i < customer.Banks.Bank.Count; i++)
            {
                if (customer.Banks.Bank[i] != null)
                {
                    bank.AccountNumber = customer.Banks.Bank[i].Accountnumber;
                    bank.AccountHolder = customer.Banks.Bank[i].Ascription;
                    bank.BicCode = customer.Banks.Bank[i].Biccode;
                    bank.Iban = customer.Banks.Bank[i].Iban;
                    bank.Name = customer.Banks.Bank[i].Bankname;
                }
            }

            var customerResponse = new CustomerResponse
            {
                Code = customer.Code,
                Name = customer.Name,
                VATNumber = customer.Vatnumber,
                Website = customer.Website,
            };
            customerResponse.Addresses.General = address;
            customerResponse.Bank.Name = bank.Name;
            customerResponse.Bank.AccountNumber = bank.AccountNumber;
            customerResponse.Bank.AccountHolder = bank.AccountHolder;
            customerResponse.Bank.BicCode = bank.BicCode;
            customerResponse.Bank.Iban = bank.Iban;
            customerResponse.EMailAddresses.General.To = customer.Financials.Ebillmail;
            customerResponse.EMailAddresses.Invoice.To = customer.Financials.Ebillmail;
            customerResponse.EMailAddresses.InvoiceReminder.To = customer.Creditmanagement.Reminderemail;
            customerResponse.PhoneNumbers.General = phonenumber;
            customerResponse.PhoneNumbers.Fax = faxnumber;
            customerResponse.PhoneNumbers.Mobile = mobilenumber;
            return customerResponse;
        }

        public Customer ConvertCustomerResponse(CustomerResponse customerResponse, string office)
        {
            var banks = new List<Bank>();
            var bank = new Bank
            {
                Ascription = customerResponse.Bank.AccountHolder,
                Accountnumber = customerResponse.Bank.AccountNumber,
                Bankname = customerResponse.Bank.Name,
                Biccode = customerResponse.Bank.BicCode,
                Iban = customerResponse.Bank.Iban,
                Address = new Address
                {
                    Field2 = string.Empty,
                    Field3 = string.Empty
                }
            };
            banks.Add(bank);

            var addresses = new List<Address>();
            var a = customerResponse.Addresses.General;
            var address = new Address
            {
                Name = a.ContactPerson,
                Country = a.Country.Code,
                City = a.City,
                Postcode = a.ZipCode,
                Field1 = a.Address1,
                Field2 = a.Address2,
                Field3 = a.Address3
            };
            addresses.Add(address);


            var c = new Customer
            {
                Office = office,
                Code = customerResponse.Code,
                Name = customerResponse.Name,
                Website = customerResponse.Website,
                Financials = new Financials
                {
                    Ebillmail = customerResponse.EMailAddresses.Invoice.To,
                },
                Creditmanagement = new Creditmanagement
                {
                    Reminderemail = customerResponse.EMailAddresses.InvoiceReminder.To,
                },
                Addresses = new Addresses
                {
                    Address = addresses
                },
                Banks = new Banks
                {
                    Bank = banks
                },
                Paymentconditions = new Paymentconditions
                {
                    Paymentcondition = new List<Paymentcondition>()
                },
                Postingrules = new Postingrules
                {
                    Postingrule = new List<Postingrule>()
                }
            };

            c.Type = "DEB";       //Dimension type of customers is DEB.
            c.Beginperiod = 1;
            c.Beginyear = 1;
            c.Endperiod = 1;
            c.Endyear = 1;
            c.Financials = new Financials
            {
                Matchtype = MatchType.Customersupplier,     //Fixed value customersupplier.
                Accounttype = "inherit",            //Fixed value inherit.
                Subanalyse = Subanalyse.False,      //Fixed value false
                Duedays = 100,
                Substitutionlevel = 1,              //Level of the balancesheet account. Fixed value 1.
                Payavailable = false,               //Determines if direct debit is possible.
                Ebilling = false,                   //Determines if the sales invoices will be sent electronically to the customer.
                Vatobligatory = false,
                Collectionschema = CollectionSchema.Core,       //Collection schema information. Apply this information only when the customer invoices are collected by SEPA direct debit.
                Collectmandate = new Collectmandate
                {
                    Id = "1"
                },
                Vatcode = new VatCode()
            };
            c.Creditmanagement = new Creditmanagement
            {
                Sendreminder = SendReminder.False,      //Determines if and how a customer will be reminded.
                Blocked = false,            //Indicates if related projects for this customer are blocked in time & expenses.
                Freetext1 = true,           //Right of use
                Basecreditlimit = 500,      //The credit limit amount.
            };
            return c;
        }
    }
}