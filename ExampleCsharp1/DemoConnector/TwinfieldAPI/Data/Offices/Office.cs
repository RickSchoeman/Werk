using System.Collections.Generic;
using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Data.Offices
{
    public class Office
    {
        internal static Office FromXml(XmlElement element)
        {
            var prompts = new List<Prompts>();
            XmlNodeList listPrompts = element.GetElementsByTagName("prompt");
            for (int i = 0; i < listPrompts.Count; i++)
            {
                if (!listPrompts[i].Equals(null) || listPrompts[i] != null || !listPrompts[i].InnerText.Equals("") || listPrompts[i].InnerText != "")
                {
                    var prompt = new Prompts
                    {
                        Prompt = listPrompts[i].InnerText
                    };
                    prompts.Add(prompt);
                }
            }
            var sorts = new List<Sort>();
            XmlNodeList listSorts = element.GetElementsByTagName("field");
            for (int i = 0; i < listSorts.Count; i++)
            {
                if (!listSorts[i].Equals(null) || listSorts[i] != null || !listSorts[i].InnerText.Equals("") || listSorts[i].InnerText != "")
                {
                    var sort = new Sort
                    {
                        Field = listSorts[i].InnerText
                    };
                    sorts.Add(sort);
                }
            }

            return new Office
            {
                Code = element.SelectInnerText("code"),
                Created = element.SelectInnerText("created"),
                Modified = element.SelectInnerText("modified"),
                Name = element.SelectInnerText("name"),
                Shortname = element.SelectInnerText("shortname"),
                Touched = element.SelectInnerText("touched"),
                User = element.SelectInnerText("user"),
                General = new General
                {
                    Basecurrency = element.SelectInnerText("general/basecurrency"),
                    Reportingcurrency = element.SelectInnerText("general/reportingcurrency"),
                    Type = element.SelectInnerText("general/type"),
                    Demo = element.SelectInnerText("general/demo"),
                    Vatnumber = element.SelectInnerText("general/vatnumber"),
                    Cocnumber = element.SelectInnerText("general/cocnumber"),
                    Currentyear = element.SelectInnerText("general/currentyear"),
                    Currentperiod = element.SelectInnerText("general/currentperiod"),
                    Numberofperiods = element.SelectInnerText("general/numberofperiods"),
                    Lastclosedyear = element.SelectInnerText("general/lastclosedyear"),
                    Creditoridentifier = element.SelectInnerText("general/creditoridentifier"),
                    Defaultbank = element.SelectInnerText("general/defaultbank"),
                    Defaultmatching = element.SelectInnerText("general/defaultmatching"),
                    Region = element.SelectInnerText("general/region"),
                    Hierarchy = element.SelectInnerText("general/hierarchy"),
                    Template = element.SelectInnerText("general/template"),
                    Templateoffice = element.SelectInnerText("general/templateoffice"),
                    Editdimensionname = element.SelectInnerText("general/editdimensioname"),
                    Allowmultiplecontrolaccounts = element.SelectInnerText("general/allowmultiplecontrolaccounts"),
                    Paymentdiscount = element.SelectInnerText("general/paymentdiscount"),
                    Scheme = element.SelectInnerText("general/scheme"),
                    Allowicmt940 = element.SelectInnerText("general/allowicmt940"),
                    Lockwordinv = element.SelectInnerText("general/lockwordinv"),
                    Todolist = element.SelectInnerText("general/todolist"),
                    Sicmajorgroup = element.SelectInnerText("general/sicmajorgroup"),
                    Address = new Address
                    {
                        Field1 = element.SelectInnerText("general/address/field1"),
                        Field2 = element.SelectInnerText("general/address/field2"),
                        Field3 = element.SelectInnerText("general/address/field3"),
                        Field4 = element.SelectInnerText("general/address/field4"),
                        Field5 = element.SelectInnerText("general/address.field5"),
                        Field6 = element.SelectInnerText("general/address/field6"),
                        City = element.SelectInnerText("general/address/city"),
                        Country = element.SelectInnerText("general/address/country"),
                        Postcode = element.SelectInnerText("general/address/postcode"),
                        Telephone = element.SelectInnerText("general/address/telephone"),
                        Fax = element.SelectInnerText("general/address/fax")
                    }

                },
                Systemdimensions = new Systemdimensions
                {
                    Accountsreceivable = element.SelectInnerText("systemdimensions/accountsreceivable"),
                    Accountspayable = element.SelectInnerText("systemdimensions/accountspayable"),
                    Openingbalance = element.SelectInnerText("systemdimensions/openingbalance"),
                    Suspenceaccount = element.SelectInnerText("systemdimensions/suspenceaccount"),
                    Workingprogress = element.SelectInnerText("systemdimensions/workingprogress"),
                    Profitriseprojects = element.SelectInnerText("systemdimensions/profitriseprojects"),
                    Turnover = element.SelectInnerText("systemdimensions/turnover"),
                    Exchangedifference = new Exchangedifference
                    {
                        Debit = element.SelectInnerText("systemdimensions/exchangedifference/debit"),
                        Credit = element.SelectInnerText("systemdimensions/exchangedifference/credit"),
                    },
                    Paymentdifference = new Paymentdifference
                    {
                        Debit = element.SelectInnerText("systemdimensions/paymentdifference/debit"),
                        Credit = element.SelectInnerText("systemdimensions/paymentdifference/credit")
                    },
                    Discount = new Discount
                    {
                        Debit = element.SelectInnerText("systemdimensions/discount/debit"),
                        Credit = element.SelectInnerText("systemdimensions/discount/credit")
                    },
                    Teqcostcenter = element.SelectInnerText("systemdimensions/teqcostcenter"),
                    Astcostcenter = element.SelectInnerText("systemdimensions/astcostcenter"),
                    Closepnl = element.SelectInnerText("systemdimensions/closepnl"),
                    Forbalynd = element.SelectInnerText("systemdimensions/forbalynd")
                },
                Systemdimensiontype = new Systemdimensiontypes
                {
                    Accountsreceivable = element.SelectInnerText("systemdimensiontypes/accountsreceivable"),
                    Accountspayable = element.SelectInnerText("systemdimensiontypes/accountspayable"),
                    Balance = element.SelectInnerText("systemdimensiontypes/balance"),
                    Profitandloss = element.SelectInnerText("systemdimensiontypes/profitandloss"),
                    Fixedassets = element.SelectInnerText("systemdimensiontypes/fixedassets"),
                    Projects = element.SelectInnerText("systemdimensiontypes/projects"),
                    Costcenters = element.SelectInnerText("systemdimensiontypes/costcenters"),
                    Activities = element.SelectInnerText("systemdimensiontypes/activities")
                },
                Creditmanagement = new Creditmanagement
                {
                    Daysafterduedate = element.SelectInnerText("creditmanagement/daysafterduedate"),
                    Daysafterduedatevalue = element.SelectInnerText("creditmanagement/daysafterduedayevalue"),
                    Daysafterpartpayment = element.SelectInnerText("creditmanagement/daysafterpartpayment"),
                    Invoicebrowse = element.SelectInnerText("creditmanagement/invoicebrowse"),
                    Invoiceexplodebrowse = element.SelectInnerText("creditmanagement/invoiceexplodebrowse"),
                    Prompts = prompts,
                    Sort = sorts
                },
                Vatmanagement = new Vatmanagement
                {
                    Txp = new Txp
                    {
                        Cpid = element.SelectInnerText("vatmanagement/txp/cpid"),
                        Cpname = element.SelectInnerText("vatmanagement/txp/cpname"),
                        Cptel = element.SelectInnerText("vatmanagement/txp/cptel")
                    },
                    Int = new Int
                    {
                        Cpid = element.SelectInnerText("vatmanagement/int/cpid"),
                        Cpname = element.SelectInnerText("vatmanagement/int/cpname"),
                        Cptel = element.SelectInnerText("vatmanagement/int/cptel")
                    },
                    Seb = new Seb
                    {
                        Cpid = element.SelectInnerText("vatmanagement/seb/cpid"),
                        Cpname = element.SelectInnerText("vatmanagement/seb/cpname"),
                        Cptel = element.SelectInnerText("vatmanagement/seb/cptel")
                    },
                    Decltimeframe = element.SelectInnerText("vatmanagement/decltimeframe"),
                    Startingquarter = element.SelectInnerText("vatmanagement/startingquarter"),
                    Icptimeframe = element.SelectInnerText("vatmanagement/icptimeframe"),
                    Mayestimate = element.SelectInnerText("vatmanagement/mayestimate"),
                    Includepurchaseorsalesprovisionaltransactions = element.SelectInnerText("vatmanagement/includepurchaseorsalesprovisionaltransactions"),
                    Includecashorbankprovisionaltransactions = element.SelectInnerText("vatmanagement/includecashorbankprovisionaltransactions"),
                    Includejournalprovisionaltransactions = element.SelectInnerText("vatmanagement/includejournalprovisionaltransactions"),
                    Defgwytype = element.SelectInnerText("vatmanagement/defgwytype"),
                    Defgwycode = element.SelectInnerText("vatmanagement/defgwycode"),
                    Accountingscheme = element.SelectInnerText("vatmanagement/accountingscheme")
                },
                Fixedassets = new Fixedassets
                {
                    Transaction = element.SelectInnerText("fixedassets/transaction"),
                    Browsepurchase = element.SelectInnerText("fixedassets/browsepurchase"),
                    Browsedepreciate = element.SelectInnerText("fixedassets/browsedepreciate"),
                    Browsereconcile = element.SelectInnerText("fixedassets/browserreconcile")
                },
                Intercompany = new Intercompany
                {
                    Outs = element.SelectInnerText("intercompany/outs"),
                    Ins = element.SelectInnerText("intercompany/ins")
                },
                Regional = new Regional
                {
                    Dateformat = element.SelectInnerText("regional/dateformat"),
                    Thousandsep = element.SelectInnerText("regional/thousandsep"),
                    Decimalsep = element.SelectInnerText("regional/decimalsep")
                }
            };
        }
        public string Code { get; set; }
        public string Created { get; set; }
        public string Modified { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public string Touched { get; set; }
        public string User { get; set; }
        public General General { get; set; }
        public Systemdimensions Systemdimensions { get; set; }
        public Systemdimensiontypes Systemdimensiontype { get; set; }
        public Creditmanagement Creditmanagement { get; set; }
        public Vatmanagement Vatmanagement { get; set; }
        public Fixedassets Fixedassets { get; set; }
        public Intercompany Intercompany { get; set; }
        public Regional Regional { get; set; }
    }

    public class General
    {
        public string Basecurrency { get; set; }
        public string Reportingcurrency { get; set; }
        public string Type { get; set; }
        public string Demo { get; set; }
        public string Vatnumber { get; set; }
        public string Cocnumber { get; set; }
        public string Currentyear { get; set; }
        public string Currentperiod { get; set; }
        public string Numberofperiods { get; set; }
        public string Lastclosedyear { get; set; }
        public string Creditoridentifier { get; set; }
        public string Defaultbank { get; set; }
        public string Defaultmatching { get; set; }
        public string Region { get; set; }
        public string Hierarchy { get; set; }
        public string Template { get; set; }
        public string Templateoffice { get; set; }
        public string Editdimensionname { get; set; }
        public string Allowmultiplecontrolaccounts { get; set; }
        public string Paymentdiscount { get; set; }
        public string Scheme { get; set; }
        public string Allowicmt940 { get; set; }
        public string Lockwordinv { get; set; }
        public string Todolist { get; set; }
        public string Sicmajorgroup { get; set; }
        public Address Address { get; set; }

    }

    public class Address
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public string Field6 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
    }

    public class Systemdimensions
    {
        public string Accountsreceivable { get; set; }
        public string Accountspayable { get; set; }
        public string Openingbalance { get; set; }
        public string Suspenceaccount { get; set; }
        public string Workingprogress { get; set; }
        public string Profitriseprojects { get; set; }
        public string Turnover { get; set; }
        public Exchangedifference Exchangedifference { get; set; }
        public Paymentdifference Paymentdifference { get; set; }
        public Discount Discount { get; set; }
        public string Teqcostcenter { get; set; }
        public string Astcostcenter { get; set; }
        public string Closepnl { get; set; }
        public string Forbalynd { get; set; }
    }

    public class Discount
    {
        public string Debit { get; set; }
        public string Credit { get; set; }
    }

    public class Paymentdifference
    {
        public string Debit { get; set; }
        public string Credit { get; set; }
    }

    public class Exchangedifference
    {
        public string Debit { get; set; }
        public string Credit { get; set; }
    }

    public class Systemdimensiontypes
    {
        public string Accountsreceivable { get; set; }
        public string Accountspayable { get; set; }
        public string Balance { get; set; }
        public string Profitandloss { get; set; }
        public string Fixedassets { get; set; }
        public string Projects { get; set; }
        public string Costcenters { get; set; }
        public string Activities { get; set; }
    }

    public class Creditmanagement
    {
        public string Daysafterduedate { get; set; }
        public string Daysafterduedatevalue { get; set; }
        public string Daysafterpartpayment { get; set; }
        public string Invoicebrowse { get; set; }
        public string Invoiceexplodebrowse { get; set; }
        public List<Prompts> Prompts { get; set; }
        public List<Sort> Sort { get; set; }
    }

    public class Sort
    {
        public string Field { get; set; }
    }

    public class Prompts
    {
        public string Prompt { get; set; }
    }

    public class Vatmanagement
    {
        public Txp Txp { get; set; }
        public Int Int { get; set; }
        public Seb Seb { get; set; }
        public string Taxgroup { get; set; }
        public string Decltimeframe { get; set; }
        public string Startingquarter { get; set; }
        public string Icptimeframe { get; set; }
        public string Mayestimate { get; set; }
        public string Includepurchaseorsalesprovisionaltransactions { get; set; }
        public string Includecashorbankprovisionaltransactions { get; set; }
        public string Includejournalprovisionaltransactions { get; set; }
        public string Defgwytype { get; set; }
        public string Defgwycode { get; set; }
        public string Accountingscheme { get; set; }
    }

    public class Txp
    {
        public string Cpid { get; set; }
        public string Cpname { get; set; }
        public string Cptel { get; set; }
    }

    public class Int
    {
        public string Cpid { get; set; }
        public string Cpname { get; set; }
        public string Cptel { get; set; }
    }

    public class Seb
    {
        public string Cpid { get; set; }
        public string Cpname { get; set; }
        public string Cptel { get; set; }
    }

    public class Fixedassets
    {
        public string Transaction { get; set; }
        public string Browsepurchase { get; set; }
        public string Browsedepreciate { get; set; }
        public string Browsereconcile { get; set; }
    }

    public class Intercompany
    {
        public string Outs { get; set; }
        public string Ins { get; set; }
    }

    public class Regional
    {
        public string Dateformat { get; set; }
        public string Thousandsep { get; set; }
        public string Decimalsep { get; set; }
    }
}
