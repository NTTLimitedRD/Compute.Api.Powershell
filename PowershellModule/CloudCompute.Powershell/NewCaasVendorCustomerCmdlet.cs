// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCaasVendorCustomerCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   Creates a new Tenant on Caas. It returns the customer ID
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Management.Automation;
using System.Security;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Vendor;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Vendor;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// Creates a new Tenant on Caas. It returns the customer ID
	/// </summary>
	[Cmdlet(VerbsCommon.New, "CaasVendorCustomer")]
	[OutputType(typeof (Guid))]
	public class NewCaasVendorCustomerCmdlet : PsCmdletCaasVendorBase
	{
		/// <summary>
		/// Company Name
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The company name")]
		public string CompanyName { get; set; }

		/// <summary>
		/// The customer trust level, possible values 0 or 10
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The customer trust level, possible values 0 or 10.")]
		public int TrustLevel { get; set; }

		/// <summary>
		/// The billing ReferrerId.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The billing ReferrerId.")]
		public string ReferrerId { get; set; }

		/// <summary>
		/// The billing VatNumber.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The billing VatNumber.")]
		public string VatNumber { get; set; }


		/// <summary>
		/// The billing externalID.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The billing externalID.")]
		public string ExternalId { get; set; }


		/// <summary>
		/// The billing promotionCode.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The billing promotionCode.")]
		public string PromotionCode { get; set; }

		/// <summary>
		/// The billing currencyMetadataValue.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The billing currencyMetadataValue.")]
		public string CurrencyMetadataValue { get; set; }


		/// <summary>
		/// The primary administrator Username.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The primary administrator Username.")]
		public string AdministratorUsername { get; set; }

		/// <summary>
		/// The primary administrator password.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The primary administrator password.")]
		public SecureString AdministratorPassword { get; set; }


		/// <summary>
		/// The contact email address
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The contact email address")]
		public string Email { get; set; }


		/// <summary>
		/// The contact first name
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The contact first name")]
		public string FirstName { get; set; }


		/// <summary>
		/// The contact last name
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The contact last name")]
		public string LastName { get; set; }


		/// <summary>
		/// "The contact address
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The contact address")]
		public string Address1 { get; set; }


		/// <summary>
		/// The contact address2
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The contact address2")]
		public string Address2 { get; set; }

		/// <summary>
		/// The contact city
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The contact city")]
		public string City { get; set; }

		/// <summary>
		/// The contact state or province
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The contact state or province")]
		public string State { get; set; }


		/// <summary>
		/// The contact zip or postcode
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The contact zip or postcode")]
		public string Zip { get; set; }


		/// <summary>
		/// The contact country
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The contact country, max 2 chars, ISO 3166-1 alpha-2 country code")]
		[ValidateLength(2, 2)]
		public string Country { get; set; }

		/// <summary>
		/// The contact country
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The contact phone number, numeric, no spaces")]
		public string PhoneNumber { get; set; }


		/// <summary>
		/// The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();
			try
			{
				var customer = new CustomerProvision
				{
					companyName = CompanyName, 
					trustLevel = TrustLevel, 
					primaryAdministrator =
						new PrimaryAdministrator
						{
							userName = AdministratorUsername, 
							password = AdministratorPassword.ToPlainString()
						}, 
					billingDetails = new BillingDetails
					{
						promotionCode = PromotionCode, 
						currencyMetadataValue = CurrencyMetadataValue, 
						externalID = ExternalId, 
						referrerId = ReferrerId, 
						vatNumber = VatNumber
					}, 
					contact = new Contact
					{
						firstName = FirstName, 
						lastName = LastName, 
						email = Email, 
						address1 = Address1, 
						address2 = Address2, 
						city = City, 
						state = State, 
						zip = Zip, 
						country = Country, 
						phoneNumber = PhoneNumber
					}
				};


				Status status = Connection.ApiClient.ProvisionCustomer(Connection.Account.OrganizationId, customer).Result;
				if (status != null)
				{
					var customerid = new Guid(status.resultDetail);
					WriteObject(customerid);
					WriteDebug(
						string.Format(
							"{0} resulted in {1} ({2}): {3}", 
							status.operation, 
							status.result, 
							status.resultCode, 
							status.resultDetail));
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