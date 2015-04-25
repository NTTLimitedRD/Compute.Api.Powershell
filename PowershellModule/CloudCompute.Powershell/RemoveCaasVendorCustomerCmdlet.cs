// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveCaasVendorCustomerCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   Creates a new Tenant on Caas. It returns the customer ID
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Vendor;
using DD.CBU.Compute.Api.Contracts.General;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// Creates a new Tenant on Caas. It returns the customer ID
	/// </summary>
	[Cmdlet(VerbsCommon.Remove, "CaasVendorCustomer")]
	[OutputType(typeof (Guid))]
	public class RemoveCaasVendorCustomerCmdlet : PsCmdletCaasVendorBase
	{
		/// <summary>
		/// Customer Id
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The id of the customer id", ValueFromPipeline = true)]
		public string CustomerId { get; set; }


		/// <summary>
		/// The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();
			try
			{
				Guid customerGuid = Guid.Parse(CustomerId);
				Status status =
					Connection.ApiClient.CancelCustomer(customerGuid).Result;

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
						else
						{
// if (e is HttpRequestException)
							ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
						}

						return true;
					});
			}
		}
	}
}