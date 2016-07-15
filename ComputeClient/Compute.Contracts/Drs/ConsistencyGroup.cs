﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DD.CBU.Compute.Api.Contracts.Drs
{
    using System.Xml.Serialization;
    using DD.CBU.Compute.Api.Contracts.Network20;

// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:didata.com:api:cloud:types")]
    public partial class DrsServerType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()] public string id;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()] public string name;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()] public string primaryNicIpv4;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()] public string primaryNicIpv6;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:didata.com:api:cloud:types")]
    public partial class DrsServerPairInfoType
    {

        /// <remarks/>
        public DrsServerType sourceServer;

        /// <remarks/>
        public DrsServerType targetServer;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()] public string id;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()] public string state;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:didata.com:api:cloud:types")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:didata.com:api:cloud:types", IsNullable = false)]
    public partial class consistencyGroups
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("consistencyGroup")]
        public ConsistencyGroupType[] consistencyGroup;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int pageNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool pageNumberSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int pageCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool pageCountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int totalCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool totalCountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int pageSize;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool pageSizeSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:didata.com:api:cloud:types")]
    [System.Xml.Serialization.XmlRootAttribute("consistencyGroup", Namespace = "urn:didata.com:api:cloud:types", IsNullable = false)]
    public partial class ConsistencyGroupType
    {

        /// <remarks/>
        public string name;

        /// <remarks/>
        public string description;

        /// <remarks/>
        public ConsistencyGroupTypeJournal journal;

        /// <remarks/>
        public ConsistencyGroupTypeSource source;

        /// <remarks/>
        public ConsistencyGroupTypeTarget target;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("serverPair")] public DrsServerPairInfoType[] serverPair;

        /// <remarks/>
        public System.DateTime createTime;

        /// <remarks/>
        public string operationStatus;

        /// <remarks/>
        public string drsInfrastructureStatus;

        /// <remarks/>
        public string state;

        /// <remarks/>
        public ProgressType progress;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()] public string id;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:didata.com:api:cloud:types")]
    public partial class ConsistencyGroupTypeJournal
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()] public int sizeGb;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()] public int extentCount;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:didata.com:api:cloud:types")]
    public partial class ConsistencyGroupTypeSource
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()] public string datacenterId;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()] public string networkDomainId;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()] public string networkDomainName;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:didata.com:api:cloud:types")]
    public partial class ConsistencyGroupTypeTarget
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()] public string datacenterId;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()] public string networkDomainId;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()] public string networkDomainName;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:didata.com:api:cloud:types")]
    [System.Xml.Serialization.XmlRootAttribute("createConsistencyGroup", Namespace = "urn:didata.com:api:cloud:types", IsNullable = false)]
    public partial class CreateConsistencyGroupType
    {

        /// <remarks/>
        public string name;

        /// <remarks/>
        public string description;

        /// <remarks/>
        public int journalSizeGb;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("serverPair")]
        public DrsServerPairType[] serverPair;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:didata.com:api:cloud:types")]
    public partial class DrsServerPairType
    {

        /// <remarks/>
        public string sourceServerId;

        /// <remarks/>
        public string targetServerId;
    }
}
