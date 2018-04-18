using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.DimensionGroups
{
    public class CreateDimensionGroupCommand
    {
        public DimensionGroup DimensionGroup { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var createElement = command.AppendNewElement("dimensiongroup");
            createElement.AppendNewElement("office").InnerText = DimensionGroup.Office;
            createElement.AppendNewElement("code").InnerText = DimensionGroup.Code;
            createElement.AppendNewElement("name").InnerText = DimensionGroup.Name;
            createElement.AppendNewElement("shortname").InnerText = DimensionGroup.Shortname;
            var d1 = createElement.AppendNewElement("dimensions");
            for (int i = 0; i < DimensionGroup.Dimensions.Dimension.Count; i++)
            {
                if (!DimensionGroup.Dimensions.Dimension[i].Equals(null) || DimensionGroup.Dimensions.Dimension[i] != null || !DimensionGroup.Dimensions.Dimension[i].Code.Equals("") || DimensionGroup.Dimensions.Dimension[i].Code != "")
                {
                    var dimension = DimensionGroup.Dimensions.Dimension[i];
                    var d2 = d1.AppendNewElement("dimension");
                    d2.SetAttribute("id", (i + 1).ToString());
                    d2.AppendNewElement("type").InnerText = dimension.Type;
                    d2.AppendNewElement("code").InnerText = dimension.Code;
                }
            }
            return command;
        }
    }
}
