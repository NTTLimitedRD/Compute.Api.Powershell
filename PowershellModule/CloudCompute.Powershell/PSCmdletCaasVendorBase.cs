namespace DD.CBU.Compute.Powershell
{
    using System.Linq;
    using System.Management.Automation;
    using System.Security.Authentication;

    /// <summary>
    /// This base Cmdlet is used for Vendor only cmdlets
    /// </summary>
    public class PsCmdletCaasVendorBase : PsCmdletCaasBase
    {
       
        protected override void BeginProcessing()
        {
            WriteWarning("NOTE:This is a vendor only cmdlet, if you have a regular account it will not work with this cmdlet");
            base.BeginProcessing();

           
        }
       
    }
}
