using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldFinderService;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.VATs
{
    public class VatService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public VatService(Session session) : this(session, new ClientFactory())
        {

        }

        public VatService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<VatSummary> FindVats(string pattern, string vatType, int field)
        {
            var query = new FinderService.Query
            {
                Type = "VAT",
                Pattern = pattern,
                Field = field
            };
            var searchResult = finderService.Search(query);
            return SearchResultToVatSummaries(searchResult);
        }

        private static List<VatSummary> SearchResultToVatSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<VatSummary>();
            }

            return searchResult.Items.Select(item => new VatSummary {Code = item[0], Name = item[1]}).ToList();
        }

        public Vat ReadVat(string vatCode)
        {
            var command = new ReadVatCommand
            {
                Office = session.Office,
                VatCode = vatCode
            };
            var response = processXml.Process(command.ToXml());
            return Vat.FromXml(response);
        }

        public void CreateVat(Vat vat)
        {
            var command = new CreateVatCommand
            {
                Vat = vat
            };
            processXml.Process(command.ToXml());
        }

        public void DeleteVat(Vat vat)
        {
            var command = new DeleteVatCommand
            {
                Vat = vat
            };
            processXml.Process(command.ToXml());
        }

        public bool WriteVat(Vat vat)
        {
            var response = processXml.Process(vat.ToXml());
            return response.IsSuccess();
        }
    }
}
