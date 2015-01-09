using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.Vendor
{
    /// <summary>
    /// A new customer contact details
    /// </summary>
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = XmlNamespaceConstants.Organization)]
    public class Contact
    {
        /// <remarks/>
        public string email;

        /// <remarks/>
        public string firstName;

        /// <remarks/>
        public string lastName;

        /// <remarks/>
        public string address1;

        /// <remarks/>
        public string address2;

        /// <remarks/>
        public string city;

        /// <remarks>
        /// optional
        /// </remarks>
        public string state;

        /// <remarks>
        /// optional
        /// </remarks>
        public string zip;

        /// <remarks/>
        public string country;

        /// <remarks/>
        public string phoneNumber;
    }
}