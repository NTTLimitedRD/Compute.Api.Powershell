using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Vendor;

namespace DD.CBU.Compute.Powershell
{
     /// <summary>
     /// Enable a customer to another region
     /// </summary>
    [Cmdlet("Enable", "CaasVendorMultiGeoCustomer")]
    public class EnableCaasVendorMultiGeoCustomerCmdlet:PsCmdletCaasVendorBase
    {
        /// <summary>
        /// Company Name
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The id of the Geo region to be enabled. List available using Get-CaasMultiGeoRegions")]
        public string GeoId { get; set; }


        /// <summary>
        /// Company Name
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The id of the customer to be enaibled on a new geo")]
        public string CustomerId { get; set; }



        protected override void ProcessRecord()
        {
            try
            {

                var customerGuid = Guid.Parse(CustomerId);
                var geoGuid = Guid.Parse(GeoId);
                var status = Connection.ApiClient.ProvisionCustomerInGeo(customerGuid, geoGuid).Result;

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
