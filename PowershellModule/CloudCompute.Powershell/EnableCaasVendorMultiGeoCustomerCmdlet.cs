// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnableCaasVendorMultiGeoCustomerCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   Enable a customer to another region
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
	/// Enable a customer to another region
	/// </summary>
	[Cmdlet(VerbsLifecycle.Enable, "CaasVendorMultiGeoCustomer")]
	public class EnableCaasVendorMultiGeoCustomerCmdlet : PsCmdletCaasVendorBase
	{
		/// <summary>
		/// Company Name
		/// </summary>
		[Parameter(Mandatory = true, 
			HelpMessage = "The id of the Geo region to be enabled. List available using Get-CaasMultiGeoRegions")]
		public string GeoId { get; set; }


		/// <summary>
		/// Company Name
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The id of the customer to be enaibled on a new geo")]
		public string CustomerId { get; set; }


		/// <summary>
		/// The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			try
			{
				Guid customerGuid = Guid.Parse(CustomerId);
				Guid geoGuid = Guid.Parse(GeoId);
				Status status = Connection.ApiClient.ProvisionCustomerInGeo(customerGuid, geoGuid).Result;

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