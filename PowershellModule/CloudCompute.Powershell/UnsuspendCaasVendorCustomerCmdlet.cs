using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Vendor;

namespace DD.CBU.Compute.Powershell
{
    /// <summary>
    /// Creates a new Tenant on Caas. It returns the customer ID 
    /// </summary>
    [Cmdlet("Unsuspend", "CaasVendorCustomer")]
    [OutputType(typeof(Guid))]
    public class UnsuspendCaasVendorCustomerCmdlet:PsCmdletCaasVendorBase
    {

        /// <summary>
        /// Customer Id
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The id of the customer id",ValueFromPipeline = true)]
        public string CustomerId { get; set; }

       
        /// <summary>
        /// Primary administrator new password.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Primary administrator new password.")]
        public SecureString NewPassword { get; set; }

        /// <summary>
        /// When cascadePassword is set to “true”, the new password value is also assigned to all SubAdministrators.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "When cascadePassword is set to “true”, the new password value is also assigned to all SubAdministrators.")]
        public bool CascadePassword { get; set; }


        /// <summary>
        //The shutAce parameter is used to tell the system whether or not to re-enable the public interfaces
        //on the networks still assigned to the customer
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = @"The shutAce parameter is used to tell the system whether or not to re-enable the public interfaces on the networks still assigned to the customer")]

        public bool ShutdownAce { get; set; }


        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            try
            {
                  var customerGuid = Guid.Parse(CustomerId);
                var status =
                    CaaS.ApiClient.UnsuspendCustomer(customerGuid, NewPassword.ToPlainString(), CascadePassword,
                        ShutdownAce).Result;

                if (status != null)
                    WriteDebug(
                        string.Format(
                            "{0} resulted in {1} ({2}): {3}",
                            status.operation,
                            status.result,
                            status.resultCode,
                            status.resultDetail));




            }
            catch (AggregateException ae)
            {
                ae.Handle(
                    e =>
                    {
                        if (e is ComputeApiException)
                        {
                            WriteError(new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, CaaS));
                        }
                        else //if (e is HttpRequestException)
                        {
                            ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, CaaS));
                        }
                        return true;
                    });
            }
        }

    }


}
