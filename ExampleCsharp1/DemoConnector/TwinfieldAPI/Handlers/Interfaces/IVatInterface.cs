using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Data.Extras.VAT;
using DemoConnector.TwinfieldAPI.Data.VATs;

namespace DemoConnector.TwinfieldAPI.Handlers.Interfaces
{
    public interface IVatInterface
    {
        List<Vat> GetByName(string name);
        List<Vat> GetAll();
        List<VatSummary> GetSummaries();
        string Create(Vat vat);
        string Delete(Vat vat);
//        List<VatCountrySummary> GetVatCountriesByName(string name);
//        List<VatCountrySummary> GetAllVatCountries();
//        List<VatGroupSummary> GetVatGroupsByName(string name);
//        List<VatGroupSummary> GetAllVatGroups();
//        List<VatNrOfRelationsSummary> GetVatNrOfRelationsByName(string name);
//        List<VatNrOfRelationsSummary> GetAllVatNrOfRelations();
    }
}
