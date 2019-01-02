using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AspCorePluSight.Models
{
    public class HomeApiResponseModel
    {

        [XmlRoot(ElementName = "Currency")]
        public class Currency
        {
            [XmlElement(ElementName = "BanknoteBuying")]
            public string BanknoteBuying { get; set; }
            [XmlElement(ElementName = "BanknoteSelling")]
            public string BanknoteSelling { get; set; }
            [XmlAttribute(AttributeName = "CrossOrder")]
            public string CrossOrder { get; set; }
            [XmlElement(ElementName = "CrossRateOther")]
            public string CrossRateOther { get; set; }
            [XmlElement(ElementName = "CrossRateUSD")]
            public string CrossRateUSD { get; set; }
            [XmlAttribute(AttributeName = "CurrencyCode")]
            public string CurrencyCode { get; set; }
            [XmlElement(ElementName = "CurrencyName")]
            public string CurrencyName { get; set; }
            [XmlElement(ElementName = "ForexBuying")]
            public string ForexBuying { get; set; }
            [XmlElement(ElementName = "ForexSelling")]
            public string ForexSelling { get; set; }
            [XmlElement(ElementName = "Isim")]
            public string Isim { get; set; }
            [XmlAttribute(AttributeName = "Kod")]
            public string Kod { get; set; }
            [XmlElement(ElementName = "Unit")]
            public string Unit { get; set; }
        }

        [XmlRoot(ElementName = "Tarih_Date")]
        public class Tarih_Date
        {
            [XmlAttribute(AttributeName = "Bulten_No")]
            public string Bulten_No { get; set; }
            [XmlElement(ElementName = "Currency")]
            public List<Currency> Currency { get; set; }
            [XmlAttribute(AttributeName = "Date")]
            public string Date { get; set; }
            [XmlAttribute(AttributeName = "Tarih")]
            public string Tarih { get; set; }
        }
    }
}
