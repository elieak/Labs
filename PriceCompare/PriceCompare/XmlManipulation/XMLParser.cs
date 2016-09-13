using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using PriceCompare.Components;

namespace PriceCompare.XmlManipulation
{
    public static class XmlParser
    {
        private const string XmlFolderName = @"xml_Files\";
        private static readonly string RelativeBinDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        private static readonly string DirecotryPath = new Uri(Path.Combine(RelativeBinDirectory, XmlFolderName)).AbsolutePath;

        public static readonly Dictionary<string, List<ItemInformation>> Data = new Dictionary<string, List<ItemInformation>>();

        public static void ParseXml()
        {
            foreach (var xmlFile in Directory.GetFiles(DirecotryPath, "*.xml").Select(Path.GetFileName))
            {
                var list = new List<ItemInformation>();
                var xFile = XDocument.Load(DirecotryPath + xmlFile);
                var chainid = xFile.Root?.Element("ChainID")?.Value;
                var chainName = GetChainName(xFile);

                list.AddRange(xFile.Descendants("Products")
                                   .Descendants("Product")
                                   .Select(xElement => new ItemInformation
                                   {
                                       ChainId = chainName,
                                       ItemName = xElement.Element("ItemName")?.Value,
                                       ItemPrice = (double)xElement.Element("ItemPrice"),
                                       ItemCode = xElement.Element("ItemCode")?.Value
                                   }));

                if (chainid != null) Data.Add(chainid, list);
            }
        }

        private static string GetChainName(XDocument xFile)
        {
            var chainId = xFile.Root?.Element("ChainID")?.Value;

            switch (chainId)
            {
                case "7290696200003":
                    return "ויקטורי: ";
                case "7290661400001":
                    return "מכסני השוק: ";
                case "7290058179503":
                    return "מכסני להב: ";
            }
            return "לא נמצאה רשת במספר זה.";
        }
    }
}
