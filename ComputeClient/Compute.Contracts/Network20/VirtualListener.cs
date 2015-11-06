﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DD.CBU.Compute.Api.Contracts.Network20
{
    using System.Xml.Serialization;

    // 
    // This source code was auto-generated by xsd, Version=4.6.81.0.
    // 

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:didata.com:api:cloud:types")]
    public partial class PoolSummaryType
    {

        private string loadBalanceMethodField;

        private string serviceDownActionField;

        private string slowRampTimeField;

        private IdAndNameType[] healthMonitorField;

        private string idField;

        private string nameField;

        /// <remarks/>
        public string loadBalanceMethod
        {
            get
            {
                return this.loadBalanceMethodField;
            }
            set
            {
                this.loadBalanceMethodField = value;
            }
        }

        /// <remarks/>
        public string serviceDownAction
        {
            get
            {
                return this.serviceDownActionField;
            }
            set
            {
                this.serviceDownActionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
        public string slowRampTime
        {
            get
            {
                return this.slowRampTimeField;
            }
            set
            {
                this.slowRampTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("healthMonitor")]
        public IdAndNameType[] healthMonitor
        {
            get
            {
                return this.healthMonitorField;
            }
            set
            {
                this.healthMonitorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:didata.com:api:cloud:types")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:didata.com:api:cloud:types", IsNullable = false)]
    public partial class createVirtualListener
    {

        private string networkDomainIdField;

        private string nameField;

        private string descriptionField;

        private string typeField;

        private string protocolField;

        private string listenerIpAddressField;

        private int portField;

        private bool portFieldSpecified;

        private bool enabledField;

        private string connectionLimitField;

        private string connectionRateLimitField;

        private string sourcePortPreservationField;

        private string poolIdField;

        private string clientClonePoolIdField;

        private string persistenceProfileIdField;

        private string fallbackPersistenceProfileIdField;

        private string optimizationProfileField;

        private string[] iruleIdField;

        /// <remarks/>
        public string networkDomainId
        {
            get
            {
                return this.networkDomainIdField;
            }
            set
            {
                this.networkDomainIdField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string protocol
        {
            get
            {
                return this.protocolField;
            }
            set
            {
                this.protocolField = value;
            }
        }

        /// <remarks/>
        public string listenerIpAddress
        {
            get
            {
                return this.listenerIpAddressField;
            }
            set
            {
                this.listenerIpAddressField = value;
            }
        }

        /// <remarks/>
        public int port
        {
            get
            {
                return this.portField;
            }
            set
            {
                this.portField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool portSpecified
        {
            get
            {
                return this.portFieldSpecified;
            }
            set
            {
                this.portFieldSpecified = value;
            }
        }

        /// <remarks/>
        public bool enabled
        {
            get
            {
                return this.enabledField;
            }
            set
            {
                this.enabledField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
        public string connectionLimit
        {
            get
            {
                return this.connectionLimitField;
            }
            set
            {
                this.connectionLimitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
        public string connectionRateLimit
        {
            get
            {
                return this.connectionRateLimitField;
            }
            set
            {
                this.connectionRateLimitField = value;
            }
        }

        /// <remarks/>
        public string sourcePortPreservation
        {
            get
            {
                return this.sourcePortPreservationField;
            }
            set
            {
                this.sourcePortPreservationField = value;
            }
        }

        /// <remarks/>
        public string poolId
        {
            get
            {
                return this.poolIdField;
            }
            set
            {
                this.poolIdField = value;
            }
        }

        /// <remarks/>
        public string clientClonePoolId
        {
            get
            {
                return this.clientClonePoolIdField;
            }
            set
            {
                this.clientClonePoolIdField = value;
            }
        }

        /// <remarks/>
        public string persistenceProfileId
        {
            get
            {
                return this.persistenceProfileIdField;
            }
            set
            {
                this.persistenceProfileIdField = value;
            }
        }

        /// <remarks/>
        public string fallbackPersistenceProfileId
        {
            get
            {
                return this.fallbackPersistenceProfileIdField;
            }
            set
            {
                this.fallbackPersistenceProfileIdField = value;
            }
        }

        /// <remarks/>
        public string optimizationProfile
        {
            get
            {
                return this.optimizationProfileField;
            }
            set
            {
                this.optimizationProfileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("iruleId")]
        public string[] iruleId
        {
            get
            {
                return this.iruleIdField;
            }
            set
            {
                this.iruleIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:didata.com:api:cloud:types")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:didata.com:api:cloud:types", IsNullable = false)]
    public partial class editVirtualListener
    {

        private string descriptionField;

        private bool enabledField;

        private bool enabledFieldSpecified;

        private string connectionLimitField;

        private string connectionRateLimitField;

        private string sourcePortPreservationField;

        private string poolIdField;

        private bool poolIdFieldSpecified;

        private string clientClonePoolIdField;

        private bool clientClonePoolIdFieldSpecified;

        private string persistenceProfileIdField;

        private string fallbackPersistenceProfileIdField;

        private string optimizationProfileField;

        private string[] iruleIdField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public bool enabled
        {
            get
            {
                return this.enabledField;
            }
            set
            {
                this.enabledField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool enabledSpecified
        {
            get
            {
                return this.enabledFieldSpecified;
            }
            set
            {
                this.enabledFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
        public string connectionLimit
        {
            get
            {
                return this.connectionLimitField;
            }
            set
            {
                this.connectionLimitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
        public string connectionRateLimit
        {
            get
            {
                return this.connectionRateLimitField;
            }
            set
            {
                this.connectionRateLimitField = value;
            }
        }

        /// <remarks/>
        public string sourcePortPreservation
        {
            get
            {
                return this.sourcePortPreservationField;
            }
            set
            {
                this.sourcePortPreservationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string poolId
        {
            get
            {
                return this.poolIdField;
            }
            set
            {
                this.poolIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool poolIdSpecified
        {
            get
            {
                return this.poolIdFieldSpecified;
            }
            set
            {
                this.poolIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string clientClonePoolId
        {
            get
            {
                return this.clientClonePoolIdField;
            }
            set
            {
                this.clientClonePoolIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool clientClonePoolIdSpecified
        {
            get
            {
                return this.clientClonePoolIdFieldSpecified;
            }
            set
            {
                this.clientClonePoolIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string persistenceProfileId
        {
            get
            {
                return this.persistenceProfileIdField;
            }
            set
            {
                this.persistenceProfileIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string fallbackPersistenceProfileId
        {
            get
            {
                return this.fallbackPersistenceProfileIdField;
            }
            set
            {
                this.fallbackPersistenceProfileIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string optimizationProfile
        {
            get
            {
                return this.optimizationProfileField;
            }
            set
            {
                this.optimizationProfileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("iruleId", IsNullable = true)]
        public string[] iruleId
        {
            get
            {
                return this.iruleIdField;
            }
            set
            {
                this.iruleIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:didata.com:api:cloud:types")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:didata.com:api:cloud:types", IsNullable = false)]
    public partial class virtualListeners
    {

        private VirtualListenerType[] virtualListenerField;

        private int pageNumberField;

        private bool pageNumberFieldSpecified;

        private int pageCountField;

        private bool pageCountFieldSpecified;

        private int totalCountField;

        private bool totalCountFieldSpecified;

        private int pageSizeField;

        private bool pageSizeFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("virtualListener")]
        public VirtualListenerType[] virtualListener
        {
            get
            {
                return this.virtualListenerField;
            }
            set
            {
                this.virtualListenerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int pageNumber
        {
            get
            {
                return this.pageNumberField;
            }
            set
            {
                this.pageNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool pageNumberSpecified
        {
            get
            {
                return this.pageNumberFieldSpecified;
            }
            set
            {
                this.pageNumberFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int pageCount
        {
            get
            {
                return this.pageCountField;
            }
            set
            {
                this.pageCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool pageCountSpecified
        {
            get
            {
                return this.pageCountFieldSpecified;
            }
            set
            {
                this.pageCountFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int totalCount
        {
            get
            {
                return this.totalCountField;
            }
            set
            {
                this.totalCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool totalCountSpecified
        {
            get
            {
                return this.totalCountFieldSpecified;
            }
            set
            {
                this.totalCountFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int pageSize
        {
            get
            {
                return this.pageSizeField;
            }
            set
            {
                this.pageSizeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool pageSizeSpecified
        {
            get
            {
                return this.pageSizeFieldSpecified;
            }
            set
            {
                this.pageSizeFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:didata.com:api:cloud:types")]
    [System.Xml.Serialization.XmlRootAttribute("virtualListener", Namespace = "urn:didata.com:api:cloud:types", IsNullable = false)]
    public partial class VirtualListenerType
    {

        private string networkDomainIdField;

        private string nameField;

        private string stateField;

        private string descriptionField;

        private System.DateTime createTimeField;

        private string typeField;

        private string protocolField;

        private string listenerIpAddressField;

        private int portField;

        private bool portFieldSpecified;

        private bool enabledField;

        private string connectionLimitField;

        private string connectionRateLimitField;

        private string sourcePortPreservationField;

        private PoolSummaryType poolField;

        private PoolSummaryType clientClonePoolField;

        private IdAndNameType persistenceProfileField;

        private IdAndNameType fallbackPersistenceProfileField;

        private string optimizationProfileField;

        private IdAndNameType[] iruleField;

        private string idField;

        private string datacenterIdField;

        /// <remarks/>
        public string networkDomainId
        {
            get
            {
                return this.networkDomainIdField;
            }
            set
            {
                this.networkDomainIdField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string state
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        /// <remarks/>
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public System.DateTime createTime
        {
            get
            {
                return this.createTimeField;
            }
            set
            {
                this.createTimeField = value;
            }
        }

        /// <remarks/>
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string protocol
        {
            get
            {
                return this.protocolField;
            }
            set
            {
                this.protocolField = value;
            }
        }

        /// <remarks/>
        public string listenerIpAddress
        {
            get
            {
                return this.listenerIpAddressField;
            }
            set
            {
                this.listenerIpAddressField = value;
            }
        }

        /// <remarks/>
        public int port
        {
            get
            {
                return this.portField;
            }
            set
            {
                this.portField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool portSpecified
        {
            get
            {
                return this.portFieldSpecified;
            }
            set
            {
                this.portFieldSpecified = value;
            }
        }

        /// <remarks/>
        public bool enabled
        {
            get
            {
                return this.enabledField;
            }
            set
            {
                this.enabledField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
        public string connectionLimit
        {
            get
            {
                return this.connectionLimitField;
            }
            set
            {
                this.connectionLimitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
        public string connectionRateLimit
        {
            get
            {
                return this.connectionRateLimitField;
            }
            set
            {
                this.connectionRateLimitField = value;
            }
        }

        /// <remarks/>
        public string sourcePortPreservation
        {
            get
            {
                return this.sourcePortPreservationField;
            }
            set
            {
                this.sourcePortPreservationField = value;
            }
        }

        /// <remarks/>
        public PoolSummaryType pool
        {
            get
            {
                return this.poolField;
            }
            set
            {
                this.poolField = value;
            }
        }

        /// <remarks/>
        public PoolSummaryType clientClonePool
        {
            get
            {
                return this.clientClonePoolField;
            }
            set
            {
                this.clientClonePoolField = value;
            }
        }

        /// <remarks/>
        public IdAndNameType persistenceProfile
        {
            get
            {
                return this.persistenceProfileField;
            }
            set
            {
                this.persistenceProfileField = value;
            }
        }

        /// <remarks/>
        public IdAndNameType fallbackPersistenceProfile
        {
            get
            {
                return this.fallbackPersistenceProfileField;
            }
            set
            {
                this.fallbackPersistenceProfileField = value;
            }
        }

        /// <remarks/>
        public string optimizationProfile
        {
            get
            {
                return this.optimizationProfileField;
            }
            set
            {
                this.optimizationProfileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("irule")]
        public IdAndNameType[] irule
        {
            get
            {
                return this.iruleField;
            }
            set
            {
                this.iruleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string datacenterId
        {
            get
            {
                return this.datacenterIdField;
            }
            set
            {
                this.datacenterIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:didata.com:api:cloud:types")]
    [System.Xml.Serialization.XmlRootAttribute("deleteVirtualListener", Namespace = "urn:didata.com:api:cloud:types", IsNullable = false)]
    public partial class DeleteVirtualListener
    {

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

}