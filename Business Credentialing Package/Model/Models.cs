using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Credentialing_Package.Model
{
    public class ProfessionalLicenseSearchRequestModel
    {
        public PersonName PersonName { get; set; }
        public string StateProv { get; set; }
    }

    public class PersonName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class UCCSearchReportRequestModel
    {
        public OrgInfo OrgInfo { get; set; }
    }

    public class OrgInfo
    {
        public string Name { get; set; }
        public ContactInfo[] ContactInfo{get;set;}
    }

    public class ContactInfo
    {
        public PostAddr PostAddr { get; set; }
    }

    public class PostAddr
    {
        public string Addr1 { get; set; }
        public string City { get; set; }
        public string StateProv { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
