using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.Vendor
{
    /// <summary>
    /// A new customer to do provisioning
    /// </summary>
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = XmlNamespaceConstants.Organization)]
    [XmlRoot(Namespace = XmlNamespaceConstants.Organization, IsNullable = false)]
    public class CustomerProvision
    {
        /// <remarks/>
        public string companyName;

        /// <remarks/>
        public int trustLevel;

        /// <remarks/>
        [XmlElement("billingDetails")]
        public BillingDetails billingDetails;

        /// <remarks/>
        [XmlElement("primaryAdministrator")]
        public PrimaryAdministrator primaryAdministrator;

        /// <remarks/>
        [XmlElement("contact")]
        public Contact contact;
    }
}
