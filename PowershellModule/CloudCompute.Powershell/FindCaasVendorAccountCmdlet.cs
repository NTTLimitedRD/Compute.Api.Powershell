// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FindCaasVendorAccountCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   Finds a Caas account
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Vendor;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// Finds a Caas account
	/// </summary>
	[Cmdlet(VerbsCommon.Find, "CaasVendorAccount")]
	[OutputType(typeof (bool))]
	public class FindCaasVendorAccountCmdlet : PsCmdletCaasVendorBase
	{
		/// <summary>
		/// Filter Caas Customer list
		/// </summary>
		[Parameter(Mandatory = true, Position = 0, HelpMessage = "username to find")]
		public string Username { get; set; }


		/// <summary>
		/// The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				bool exist = Connection.ApiClient.ExistAccount(Username).Result;
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