namespace DD.CBU.Compute.Api.Contracts.Vendor
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://oec.api.opsource.net/schemas/organization")]
    public partial class SummaryCustomerOrganization
    {

        private string idField;

        private string descriptionField;

        private OrgStateType orgStateField;

        private string trustLevelField;

        private string referrerIdField;

        /// <remarks/>
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
        public OrgStateType orgState
        {
            get
            {
                return this.orgStateField;
            }
            set
            {
                this.orgStateField = value;
            }
        }

        /// <remarks/>
        public string trustLevel
        {
            get
            {
                return this.trustLevelField;
            }
            set
            {
                this.trustLevelField = value;
            }
        }

        /// <remarks/>
        public string referrerId
        {
            get
            {
                return this.referrerIdField;
            }
            set
            {
                this.referrerIdField = value;
            }
        }
    }
}