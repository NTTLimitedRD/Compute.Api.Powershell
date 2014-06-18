namespace DD.CBU.Compute.Api.Client.Vendor
{
    using System;
    using System.Threading.Tasks;

    using DD.CBU.Compute.Api.Client.Interfaces;
    using DD.CBU.Compute.Api.Contracts.Billing;

    /// <summary>
    /// Api calls to apis defined in Vendor Api category
    /// </summary>
    public static class ComputeApiClientVendorExtensions
    {
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
        public static async Task<PricingPlans> ListPricingPlans(this IComputeApiClient computeApiClient, Guid organizationId, Guid geoId)
        {
            return
                await computeApiClient.WebApi.ApiGetAsync<PricingPlans>(ApiUris.GetUriForListingPricingPlans(organizationId, geoId));
        }
    }
}
