using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Vendor;
using DD.CBU.Compute.Api.Contracts.Network;

namespace DD.CBU.Compute.Powershell
{

    /// <summary>
    /// Finds a Caas account
    /// </summary>
    [Cmdlet(VerbsCommon.Find, "CaasVendorAccount")]
    [OutputType(typeof(bool))]
    public class FindCaasVendorAccountCmdlet:PsCmdletCaasVendorBase
    {
        /// <summary>
        /// Filter Caas Customer list
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "username to find")]
        public string Username { get; set; }


        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var exist = Connection.ApiClient.ExistAccount(Username).Result;
                WriteObject(exist);

            }
            catch (AggregateException ae)
            {
                ae.Handle(
                    e =>
                    {
                        if (e is ComputeApiException)
                        {
                            WriteError(new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, Connection));
                        }
                        else //if (e is HttpRequestException)
                        {
                            ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }
                        return true;
                    });
            }
          

        }
        
    }
}
