using System;
using System.Collections.Generic;
using System.Linq;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldFinderService;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Dimensions
{
	public class DimensionService
	{
		private readonly Session session;
		private readonly ProcessXmlService processXml;
		private readonly FinderService finderService;

		public DimensionService(Session session)
			: this(session, new ClientFactory())
		{ }

		public DimensionService(Session session, IClientFactory clientFactory)
		{
			this.session = session;
			processXml = new ProcessXmlService(session, clientFactory);
			finderService = new FinderService(session, clientFactory);
		}

		public List<DimensionSummary> FindDimensions(string pattern, string dimensionType, int field)
		{
			var query = new FinderService.Query
			{
				Type = "DIM",
				Pattern = pattern,
				Field = field,
				Options = new[] { new[] { "dimtype", dimensionType } }
			};
			var searchResult = finderService.Search(query);

			return SearchResultToDimensionSummaries(searchResult);
		}

		private static List<DimensionSummary> SearchResultToDimensionSummaries(FinderData searchResult)
		{
			if (searchResult.Items == null)
				return new List<DimensionSummary>();

			return searchResult.Items.Select(item =>
					new DimensionSummary { Code = item[0], Name = item[1] }).ToList();
		}

		public Dimension ReadDimension(string dimensionType, string dimensionCode)
		{
			var command = new ReadDimensionCommand
			{
				Office = session.Office,
				DimensionType = dimensionType,
				DimensionCode = dimensionCode
			};
			var response = processXml.Process(command.ToXml());
			return Dimension.FromXml(response);
		}

	    public void CreateDimension(Dimension dimension)
	    {
            var command = new CreateDimensionCommand
            {
                Dimension = dimension
            };
	        processXml.Process(command.ToXml());

	    }

	}
}
