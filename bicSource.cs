using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICTextFormatter
{
    public class bicSource
    {
        public string tag { get; set; }
        public string modificationFlag { get; set; }
        public string bicCode { get; set; }
        public string branchCode { get; set; }
        public string institutionName { get; set; }
        public string branchInformation { get; set; }
        public string cityHeading { get; set; }
        public string subtypeIndication { get; set; }
        public string valueAddedServices { get; set; }
        public string extraInfo { get; set; }
        public string physicalAddr1 { get; set; }
        public string physicalAddr2 { get; set; }
        public string physicalAddr3 { get; set; }
        public string physicalAddr4 { get; set; }
        public string location { get; set; }
        public string countryName { get; set; }
        public string pobNumber { get; set; }
        public string pobLocation { get; set; }
        public string pobCountryName { get; set; }
    }
}
