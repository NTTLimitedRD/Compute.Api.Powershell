// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSCmdletCaasVendorBase.cs" company="">
//   
// </copyright>
// <summary>
//   This base Cmdlet is used for Vendor only cmdlets
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// This base Cmdlet is used for Vendor only cmdlets
	/// </summary>
	public class PsCmdletCaasVendorBase : PsCmdletCaasBase
	{
		/// <summary>
		/// The begin processing.
		/// </summary>
		protected override void BeginProcessing()
		{
			WriteWarning("NOTE:This is a vendor only cmdlet, therfore only works with vendor accounts.");
			base.BeginProcessing();
		}
	}
}