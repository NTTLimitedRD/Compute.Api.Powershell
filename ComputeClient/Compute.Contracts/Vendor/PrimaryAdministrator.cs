using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.Vendor
{
    /// <summary>
    /// Primary Administrator
    /// </summary>
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = XmlNamespaceConstants.Organization)]
    public class PrimaryAdministrator
    {
        /// <remarks/>
        public string userName;

        /// <remarks/>
        public string password;
    }
}