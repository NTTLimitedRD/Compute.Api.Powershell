using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Vendor;
using DD.CBU.Compute.Api.Contracts.Vendor;
using DD.CBU.Compute.Api.Contracts.Vip;

namespace DD.CBU.Compute.Powershell
{
    [Cmdlet(VerbsCommon.Search, "CaasVendorCustomer")]
    [OutputType(typeof(SummaryCustomerOrganization[]))]
    public class SearchCaasVendorCustomerCmdlet:PsCmdletCaasVendorBase
    {

        /// <summary>
        /// Filter Caas Customer list
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "filter by name or referal")]
        public string Filter { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {

                var resultlist = Connection.ApiClient.SearchCustomer(Filter).Result;

                if (resultlist != null && resultlist.Any())
                {
                   
                    switch (resultlist.Count())
                    {
                        case 0:
                            WriteError(
                                   new ErrorRecord(
                                       new ItemNotFoundException(
                                           "This command cannot find a matching object with the given parameters."
                                           ), "ItemNotFoundException", ErrorCategory.ObjectNotFound, resultlist));
                            break;
                        case 1:
                            WriteObject(resultlist.First());
                            break;
                        default:
                            WriteObject(resultlist, true);
                            break;
                    }

                }

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
