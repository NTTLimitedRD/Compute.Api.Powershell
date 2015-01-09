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
    public class BillingDetails
    {
        /// <remarks>
        /// optional
        /// </remarks>
        public string referrerId;

        /// <remarks>
        /// optional
        /// </remarks>
        public string vatNumber;

        /// <remarks>
        /// optional
        /// </remarks>
        public string externalID;

        /// <remarks>
        /// optional
        /// </remarks>
        public string currencyMetadataValue;

        /// <remarks>
        /// optional
        /// </remarks>
        public string promotionCode;

     

    }
}