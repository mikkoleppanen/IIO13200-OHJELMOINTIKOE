using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using Tehtava2;

namespace Tehtava2
{
    class MyXMLData
    {
        private List<XMLDataModel> wholeXmlList = new List<XMLDataModel>();
        private List<XMLDataModel> shownList = new List<XMLDataModel>();
        private String xmlFilePath = @"Countries.xml";
        public MyXMLData()
        {
            getDataFromXml();
        }
        public void setFilePath()
        {
            //this.xmlFilePath = ConfigurationManager.AppSettings["DataFile"];
        }
        public void getDataFromXml()
        {
            try
            {
                XElement xmlDoc = new XElement(XDocument.Load(xmlFilePath).Root);
                wholeXmlList = (from el in xmlDoc.Descendants("ROW")
                        select new XMLDataModel
                        {
                            name = el.Element("Name").Value,
                            continent = el.Element("Continent").Value,
                            population = int.Parse(el.Element("Population").Value),
                            localName = el.Element("LocalName").Value,
                            headOfState = el.Element("HeadOfState").Value
                        }).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("XML-dokumenttia ei voitu avata.", "Virhe", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public List<String> showContinents()
        {
            List<String> continents = new List<String>();
            foreach(XMLDataModel item in wholeXmlList)
            {
                if(continents.Find(x => x == item.continent) == null)
                {
                    continents.Add(item.continent);
                }
            }
            return continents;
        }

        public List<XMLDataModel> showData()
        {
            shownList = wholeXmlList;
            return shownList;
        }

        public List<XMLDataModel> showDataFind(String findText)
        {
            shownList.Clear();
            foreach (XMLDataModel item in wholeXmlList)
            {
                if(item.name.Contains(findText))
                {
                    shownList.Add(item);
                }
            }

            return shownList;
        }

        public List<XMLDataModel> showDataByContinent(String continent)
        {
            shownList = wholeXmlList.Where(x => x.continent == continent).ToList();

            return shownList;
        }
        
        public List<XMLDataModel> showTenHighestPopulation()
        {
            shownList = wholeXmlList.OrderByDescending(x => x.population).Take(10).ToList();

            return shownList;
        }

        
        public List<XMLDataModel> showTenHighestSurfaceArea()
        {
            try
            {
                XElement xmlDoc = new XElement(XDocument.Load(xmlFilePath).Root);
                shownList = (from el in xmlDoc.Descendants("ROW")
                             orderby int.Parse(el.Element("SurfaceArea").Value) descending
                             select new XMLDataModel
                        {
                            name = el.Element("Name").Value,
                            continent = el.Element("Continent").Value,
                            population = int.Parse(el.Element("Population").Value),
                            localName = el.Element("LocalName").Value,
                            headOfState = el.Element("HeadOfState").Value
                        }).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("XML-dokumenttia ei voitu avata.", "Virhe", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            shownList = shownList.Take(10).ToList();
            return shownList;
        }

        public int getCountryCount()
        {
            return shownList.Count();
        }

        public long getCombinedPopulation()
        {
            long populationCount = 0;
            foreach(XMLDataModel item in shownList)
            {
                populationCount += item.population;
            }
            return populationCount;
        }
    }
}
