using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XLinq
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Working...");

            var mscorlib = Assembly.Load("mscorlib");
            var elements = from item in mscorlib.GetExportedTypes()
                           where item.IsClass && item.IsPublic
                           select new XElement("Type", new XAttribute("FullName", item.FullName), new XElement("Properties",
                            from props in item.GetProperties()
                            where props.CanRead
                            select new XElement("Property", new XAttribute("Name", props.Name), new XAttribute("Type", props.PropertyType))), new XElement("Methods",
                                   from method in item.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                                   select new XElement("Method", new XAttribute("Name", method.Name), new XAttribute("ReturnType", method.ReturnType), new XElement("Parameters",
                                       from param in method.GetParameters()
                                       select new XElement("Parameter", new XAttribute("Name", param.Name), new XAttribute("Type", param.GetType()))))));

            var xelement = new XElement(mscorlib.GetName().Name);
            xelement.Add(elements);
            xelement.Save("InitialElements.xml");

            var xmlElements = elements as IList<XElement> ?? elements.ToList();
            NoProperties(xmlElements);
            MethodsCount(xmlElements);
            PropertiesCount(xmlElements);
            MostCommonParameterType(xmlElements);
            MethodsInDescendingOrder(xmlElements);
            GroupedMethods(xmlElements);

            Console.WriteLine("Done.");
            Console.WriteLine(@"Go to XLinq\XLinq\bin\Debug for results.");
            Console.ReadKey();
        }

        private static void NoProperties(IEnumerable<XElement> xml)
        {
            var types = from item in xml
                        let xElement = item.Element("Properties")
                        where xElement != null && xElement.IsEmpty
                        orderby item.Attribute("FullName").ToString()
                        select item.Attribute("FullName").ToString();

            var xelement = new XElement("NoProperties");
            xelement.Add(types);
            xelement.Save("NoProperties.xml");}

        private static void MethodsCount(IEnumerable<XElement> xmlElements)
        {
            var numberOfMethods = from item in xmlElements
                                  let xElement = item.Element("Methods")
                                  where xElement != null && xElement.IsEmpty == false
                                  select item.Attribute("Method");

            var xelement = new XElement("MethodsCount");
            xelement.Add(numberOfMethods);
            xelement.Save("MethodsCount.xml");
        }

        private static void PropertiesCount(IEnumerable<XElement> xmlElements)
        {
            var numberOfProperties = from item in xmlElements
                                     let xElement = item.Element("Properties")
                                     where xElement != null && xElement.IsEmpty == false
                                     select item.Attribute("Property");

            var xelement = new XElement("numberOfProperties");
            xelement.Add(numberOfProperties);
            xelement.Save("numberOfProperties.xml");
        }

        private static void MostCommonParameterType(IEnumerable<XElement> xmlElements)
        {
            var commonParamTypes = xmlElements.Descendants("Parameter")
                .GroupBy(element => element.Attribute("Type"))
                .Select(element => new { type = element.Key, count = element.Count() })
                .OrderBy(element => element.count)
                .Last().type.Value;

            var xelement = new XElement("MostCommonParameterType");
            xelement.Add(commonParamTypes);
            xelement.Save("MostCommonParameterType.xml");
        }

        private static void MethodsInDescendingOrder(IEnumerable<XElement> xmlElements)
        {
            var numberOfMethods = from item in xmlElements
                                  orderby item.Descendants("Method").Count() descending
                                  select item;

            var xml = from item in numberOfMethods
                      select new XElement("Type", new XAttribute("FullName", item.FirstAttribute.Value),
                             new XAttribute("NumberOfProperties", item.Descendants("Property").Count()),
                             new XAttribute("NumberOfMethods", item.Descendants("Method").Count()));

            var newXml = new XElement("MethodsInDescendingOrder");
            newXml.Add(xml);
            newXml.Save("MethodsInDescendingOrder.xml");
        }

        private static void GroupedMethods(IEnumerable<XElement> xml)
        {
            var methodGroups = xml
                .OrderBy(element => element.Attribute("FullName").ToString())
                .GroupBy(element => element.Descendants("Method").Count())
                .OrderByDescending(x => x.Descendants("Method").Count());

            var newXml = new XElement("GroupedMethods");
            newXml.Add(methodGroups);
            newXml.Save("GroupedMethods.xml");
        }
    }

}
