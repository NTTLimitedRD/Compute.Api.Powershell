// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResumeCaasVendorCustomerCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   Resume a suspended tenant on Caas.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Management.Automation;
using System.Security;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Vendor;
using DD.CBU.Compute.Api.Contracts.General;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// Resume a suspended tenant on Caas.
	/// </summary>
	[Cmdlet(VerbsLifecycle.Resume, "CaasVendorCustomer")]
	[OutputType(typeof (Guid))]
	public class ResumeCaasVendorCustomerCmdlet : PsCmdletCaasVendorBase
	{
		/// <summary>
		/// Customer Id
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The id of the customer id", ValueFromPipeline = true)]
		public string CustomerId { get; set; }


		/// <summary>
		/// Primary administrator new password.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "Primary administrator new password.")]
		public SecureString NewPassword { get; set; }

		/// <summary>
		/// When cascadePassword is set to “true”, the new password value is also assigned to all SubAdministrators.
		/// </summary>
		[Parameter(Mandatory = true, 
			HelpMessage =
				"When cascadePassword is set to “true”, the new password value is also assigned to all SubAdministrators.")]
		public bool CascadePassword { get; set; }


		/// <summary>
		/// </summary>
		[Parameter(Mandatory = true, 
			HelpMessage =
				@"The shutAce parameter is used to tell the system whether or not to re-enable the public interfaces on the networks still assigned to the customer"
			)]
		public bool ShutdownAce { get; set; }


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
					Connection.ApiClient.UnsuspendCustomer(customerGuid, NewPassword.ToPlainString(), CascadePassword, 
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