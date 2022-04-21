using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RequestClasses
{
    public class RequestClass
    {
        [JsonPropertyName("AcountName")]
        public string GetAcountName { get; set; }
        [JsonPropertyName("ContactFirstName")]
        public string GetContactFirstName { get; set; }
        [JsonPropertyName("ContactLastName")]
        public string GetContactLastName { get; set; }
        [JsonPropertyName("ContactEmail")]
        public string GetContactEmail { get; set; }
        [JsonPropertyName("IcendentDesc")]
        public string GetIcendentDesc { get; set; }
        public RequestClass() { }
        public RequestClass(string AcountName, string ContactFirstName, string ContactLastName, string ContactEmail, string IcendentDesc)
        {
            GetAcountName = AcountName;
            GetContactFirstName = ContactFirstName;
            GetContactLastName = ContactLastName;
            GetContactEmail = ContactEmail;
            GetIcendentDesc = IcendentDesc;
        }
    }
}
