

using System.Text.RegularExpressions;

namespace DD.CBU.Compute.Api.Client.Vendor
{
    using System;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Client.Interfaces;
    using DD.CBU.Compute.Api.Contracts.Vendor;
    using DD.CBU.Compute.Api.Contracts.General;
    using System.Collections.Generic;


    /// <summary>
    /// Api calls to apis defined in Vendor Api category
    /// </summary>
    public static class ComputeApiClientVendorExtensions
    {



        public static async Task<bool> ExistAccount(this IComputeApiClient computeApiClient,string username)
        {
            bool exist = false;
            var response = await computeApiClient.WebApi.ApiGetAsync(ApiUris.ExistAccount(username));
            //due to Caas response value is on the root node, cannot deserialise into a class. Parsing the values true or false using Regex 
            string resultString = null;
            try
            {
               var  result = Regex.Match(response, "true|false").Value;
                exist = bool.Parse(result);
            }
            catch (ArgumentException ex)
            {
                throw new ComputeApiClientException(ClientError.Unknown, "Unexpected reaposnse from API", ex, null);
            }


            return exist;

        }
 

        /// <summary>
        /// Search for customers on 
        /// </summary>
        /// <param name="computeApiClient">The compute Api Client.</param>
        /// <param name="filter">It is some part of the customer’s organization name or the referrerId if a value was provided for that input when provisioning the customer. To return all customers use * as filter</param>
        /// <returns></returns>
        public static async Task<IEnumerable<SummaryCustomerOrganization>> SearchCustomer(this IComputeApiClient computeApiClient, string filter)
        {
            //when logged in with a vendor account the org id is the vendor id
            var customers = await computeApiClient.WebApi.ApiGetAsync<SummaryCustomerOrganizations>(ApiUris.SearchCustomers(computeApiClient.Account.OrganizationId, filter));

            return customers.Items;
        }



        /// <summary>
        /// Provision Net Terms Customer
        /// </summary>
        /// <param name="computeApiClient">Compute Api Client</param>
        /// <param name="vendorId">
        /// Organization Id
        /// </param>
        /// <param name="customerProvision">
        /// The custom Provisioning.
        /// </param>
        /// <returns>
        /// Provision Status
        /// </returns>
        public async static Task<Status> ProvisionCustomer(this IComputeApiClient computeApiClient, Guid vendorId, CustomerProvision customerProvision)
        {
            return
                await
                computeApiClient.WebApi.ApiPostAsync<CustomerProvision, Status>(
                    ApiUris.ProvisionCustomer(vendorId),
                    customerProvision);
        }

        /// <summary>
        /// Provision Customer on a multi-geography data center
        /// </summary>
        /// <param name="computeApiClient">
        /// The compute Api Client.
        /// </param>
        /// <param name="customerId">
        /// The customer Id.
        /// </param>
        /// <param name="geographyId">
        /// The geography Id.
        /// </param>
       /// <returns>
        /// Statuc
        /// </returns>
        public static async Task<Status> ProvisionCustomerInGeo(this IComputeApiClient computeApiClient, Guid customerId, Guid geographyId)
        {
            return await
                    computeApiClient.WebApi.ApiPostAsync<CustomerGeoSignUp, Status>(
                        ApiUris.ProvisionCustomerOnGeo(customerId),
                        new CustomerGeoSignUp { geoId = geographyId });
        }



        /// <summary>
        /// Suspend a customer account
        /// </summary>
        /// <param name="computeApiClient"> the compute API client </param>
        /// <param name="customerId">customer id</param>
        /// <param name="newPassword">new primary administrator password</param>
        /// <param name="cascadePassword">cascade password to sub administrators</param>
        /// <param name="shutAce">disconnet users from ACE (VPN)</param>
        /// <returns></returns>
        public static async Task<Status> SuspendCustomer(this IComputeApiClient computeApiClient, Guid customerId,
            string newPassword, bool cascadePassword, bool shutAce)
        {

            return
                await
                    computeApiClient.WebApi.ApiGetAsync<Status>(ApiUris.SuspendCustomer(customerId, newPassword,
                        cascadePassword, shutAce));


        }


        /// <summary>
        /// UnSuspend a customer account
        /// </summary>
        /// <param name="computeApiClient"> the compute API client </param>
        /// <param name="customerId">customer id</param>
        /// <param name="newPassword">new primary administrator password</param>
        /// <param name="cascadePassword">cascade password to sub administrators</param>
        /// <param name="shutAce">disconnet users from ACE (VPN)</param>
        /// <returns></returns>
        public static async Task<Status> UnsuspendCustomer(this IComputeApiClient computeApiClient, Guid customerId,
            string newPassword, bool cascadePassword, bool shutAce)
        {

            return
                await
                    computeApiClient.WebApi.ApiGetAsync<Status>(ApiUris.UnsuspendCustomer(customerId, newPassword,
                        cascadePassword, shutAce));


        }


        /// <summary>
        /// Cancel a customer account
        /// </summary>
        /// <param name="computeApiClient"> the compute API client </param>
        /// <param name="customerId">customer id</param>
      /// <returns></returns>
        public static async Task<Status> CancelCustomer(this IComputeApiClient computeApiClient, Guid customerId)
        {

            return
                await
                    computeApiClient.WebApi.ApiGetAsync<Status>(ApiUris.CancelCustomer(customerId));


        }




        //public static async Task<bool> ExistAccount

            /// <summary>
        /// List pricing plans for a organization
        /// </summary>
        /// <param name="computeApiClient">
        /// The compute Api Client.
        /// </param>
        /// <param name="organizationId">
        /// Organization Id
        /// </param>
        /// <param name="geoId">
        /// Geo Id
        /// </param>
        /// <returns>
        /// Pricing Plans
        /// </returns>
        [Obsolete]
        public static async Task<PricingPlans> ListPricingPlans(this IComputeApiClient computeApiClient, Guid organizationId, Guid geoId)
        {
            return
                await computeApiClient.WebApi.ApiGetAsync<PricingPlans>(ApiUris.GetUriForListingPricingPlans(organizationId, geoId));
        }
    }
}
