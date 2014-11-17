﻿using System;
using System.Collections;
using System.Linq;

namespace DD.CBU.Compute.Api.Client
{
    using System.Collections.Specialized;
    using System.Diagnostics.Contracts;
    using System.Net;

    /// <summary>
    ///		Constants and formatters for API URLs.
    /// </summary>
    public static class ApiUris
    {
        /// <summary>
        ///		The path (relative to the base API URL) of the My Account action.
        /// </summary>
        internal static readonly Uri MyAccount = new Uri("myaccount", UriKind.Relative);

        /// <summary>
        ///		Get the base URI for the CaaS REST API.
        /// </summary>
        /// <param name="targetRegionName">
        ///		The target region's short name ("au", for example).
        /// </param>
        /// <returns>
        ///		The base URI for the CaaS REST API.
        /// </returns>
        internal static Uri ComputeBase(string targetRegionName)
        {
            if (String.IsNullOrWhiteSpace(targetRegionName))
                throw new ArgumentException(
                    "Argument cannot be null, empty, or composed entirely of whitespace: 'targetRegionName'.",
                    "targetRegionName");

            return new Uri(String.Format("https://api-{0}.dimensiondata.com/oec/0.9/", targetRegionName.ToLower()));
        }

        /// <summary>
        ///		Get the relative URI for the CaaS API action that retrieves a list of all data centres available for use by the specified organisation.
        /// </summary>
        /// <param name="organizationId">
        ///		The organisation Id.
        /// </param>
        /// <returns>
        ///		The relative action Uri.
        /// </returns>
        internal static Uri DatacentersWithDiskSpeedDetails(Guid organizationId)
        {
            if (organizationId == Guid.Empty) throw new ArgumentException("GUID cannot be empty: 'organizationId'.", "organizationId");

            return new Uri(String.Format("{0}/datacenterWithDiskSpeed", organizationId), UriKind.Relative);
        }

        /// <summary>
        /// Get the relative URI for the CaaS API action that retrieves a list of all data centres available for use by the specified organisation.
        /// </summary>
        /// <param name="orgId">The organisation Id</param>
        /// <returns>The relative action Uri.</returns>
        internal static Uri DatacentresWithMaintanence(Guid orgId)
        {
            Contract.Requires(orgId != Guid.Empty, "Organization id cannot be empty!");

            return new Uri(string.Format("{0}/datacenterWithMaintenanceStatus", orgId), UriKind.Relative);
        }

        /// <summary>
        ///		Get the relative URI for the CaaS API action that retrieves a list of all system-defined images deployed in the specified data centre.
        /// </summary>
        /// <param name="locationName">
        ///		The data centre location name.
        /// </param>
        /// <returns>
        ///		The relative action Uri.
        /// </returns>
        internal static Uri ImagesWithSoftwareLabels(string locationName)
        {
            if (String.IsNullOrWhiteSpace(locationName))
                throw new ArgumentException(
                    "Argument cannot be null, empty, or composed entirely of whitespace: 'locationName'.",
                    "locationName");

            return new Uri(String.Format("base/image/deployedWithSoftwareLabels/{0}", locationName), UriKind.Relative);
        }




        /// <summary>
        /// Gets the relative URI for the CaaS API action that retrieves a filtered list of server images or servers.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="name">The server name</param>
        /// <param name="networkId">The server networkid</param>
        /// <param name="location">The server location</param>
        /// <returns>A list of deployed servers</returns>
        internal static Uri ImagesWithDiskSpeed(Guid orgId, ServerImageType imagetype, string imageId, string name,  string location, string operatingSystemId, string operatingSystemFamily)
        {
           string uri = "base/imageWithDiskSpeed";
            if (imagetype == ServerImageType.CUSTOMER)
            {
                Contract.Requires(orgId != Guid.Empty, "Organization Id cannot be empty");
                uri = string.Format("{0}/imageWithDiskSpeed", orgId);
            }
            //build que query string paramenters
            var querystringcollection = new NameValueCollection();
            if (!string.IsNullOrEmpty(name))
                querystringcollection.Add("name", name);
            if (!string.IsNullOrEmpty(imageId))
                querystringcollection.Add("id", imageId);
            if (!string.IsNullOrEmpty(location))
               querystringcollection.Add("location", location);
            if (!string.IsNullOrEmpty(operatingSystemId))
                querystringcollection.Add("operatingSystemId", operatingSystemId);
            if (!string.IsNullOrEmpty(operatingSystemFamily))
                querystringcollection.Add("operatingSystemFamily", operatingSystemFamily);

            if (querystringcollection.AllKeys.Any())
                uri = string.Concat(uri, "?");
            // build the query string
            string querystring = querystringcollection.ToQueryString();

            if (!string.IsNullOrEmpty(querystring))
                uri = string.Concat(uri, querystring);

            return new Uri(uri, UriKind.Relative);
        }
        /// <summary>
        /// Gets the relative URI for the CaaS API action that delete a customer image.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="imageId">The customer image id</param>
        /// <returns></returns>
        internal static Uri RemoveCustomerServerImage(Guid orgId, string imageId)
        {
            return new Uri(
                string.Format("{0}/image/{1}?delete", orgId,imageId),UriKind.Relative);
        }

        /// <summary>
        /// Gets the relative URI for the CaaS API action that retrieves a filtered list of deployed servers.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="name">The server name</param>
        /// <param name="networkId">The server networkid</param>
        /// <param name="location">The server location</param>
        /// <returns>A list of deployed servers</returns>
        internal static Uri DeployedServers(Guid orgId, string serverId, string name, string networkId, string location)
        {
           Contract.Requires(orgId != Guid.Empty, "Organization Id cannot be empty");
            string uri= "{0}/serverWithBackup";
           //build que query string paramenters
            var querystringcollection = new NameValueCollection();
            if (!string.IsNullOrEmpty(name))
                querystringcollection.Add("name", name);
            if (!string.IsNullOrEmpty(serverId))
                  querystringcollection.Add("id", serverId);
            if (!string.IsNullOrEmpty(networkId))
                querystringcollection.Add("networkid", networkId);
            if (!string.IsNullOrEmpty(location))
                querystringcollection.Add("location", location);

            if (querystringcollection.AllKeys.Any())
                uri = string.Concat(uri, "?");
            // build the query string
            string querystring = querystringcollection.ToQueryString();

            if(!string.IsNullOrEmpty(querystring))
                uri = string.Concat(uri, querystring);

            return new Uri(string.Format(uri, orgId), UriKind.Relative);
        }

        /// <summary>
        /// Gets the relative URI for the CaaS API action that retrieves a list of customer images with software labels
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="networkLocation">The network location id</param>
        /// <returns>A list of OS server images</returns>
        internal static Uri CustomerImagesWithSoftwareLabels(Guid orgId, string networkLocation)
        {
            return new Uri(
                string.Format("{0}/image/deployedWithSoftwareLabels/{1}", orgId, networkLocation),
                UriKind.Relative);
        }

        /// <summary>
        /// The relative URI for the CaaS API action that allows a server to be deployed
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        [Obsolete("This Uri is deprecated, please use DeployServerWithDiskSpeed instead.")]
        internal static Uri DeployServer(Guid orgId)
        {
            return new Uri(string.Format("{0}/server", orgId), UriKind.Relative);
        }

        /// <summary>
        /// The relative URI for the CaaS API action that allows a server to be deployed
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        internal static Uri DeployServerWithDiskSpeed(Guid orgId)
        {
            return new Uri(string.Format("{0}/deployServer", orgId), UriKind.Relative);
        }


        /// <summary>
        /// Modify the server.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for a modify servers</returns>
        internal static Uri ModifyServer(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}", orgId, serverId), UriKind.Relative);
        }


        /// <summary>
        /// Deletes the server.
        /// <remarks>The Server must be stopped before it can be deleted</remarks>
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for a deletion of the server</returns>
        internal static Uri DeleteServer(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}?delete", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// A “graceful” stop of a server by initiating a shutdown sequence within the guest operating system.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for a graceful shutdown of the server</returns>
        internal static Uri ShutdownServer(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}?shutdown", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// Powers on an existing deployed server.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for starting the server</returns>
        internal static Uri PowerOnServer(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}?start", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// An abrupt power off of the server. Success is guarenteed
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for powering off the server</returns>
        internal static Uri PoweroffServer(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}?poweroff", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        ///  A "graceful" reboot of the server.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for rebooting the server</returns>
        internal static Uri RebootServer(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}?reboot", orgId, serverId), UriKind.Relative);
        }


        /// <summary>
        /// Triggers an update of the VMware Tools software running on the guest OS of a virtual server
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for rebooting the server</returns>
        internal static Uri UpdateServerVMwareTools(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}?updateVMwareTools", orgId, serverId), UriKind.Relative);
        }


        /// <summary>
        /// Initiates a clone of a server to create a Customer Image
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for rebooting the server</returns>
        internal static Uri CloneServerToCustomerImage(Guid orgId, string serverId,string imageName, string imageDesc)
        {
            Uri uri = null;
            if (string.IsNullOrEmpty(imageDesc))
                uri = new Uri(string.Format("{0}/server/{1}?clone={2}", orgId, serverId,imageName), UriKind.Relative);
            else
                uri = new Uri(string.Format("{0}/server/{1}?clone={2}&desc={3}", orgId, serverId,imageName,imageDesc), UriKind.Relative);
            return uri;
        }

        /// <summary>
        /// Change server disk speed
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <param name="diskId">The disk id</param>
        /// <returns>Returns the relative URI of the REST request for change server disk size the server</returns>
        internal static Uri ChangeServerDiskSpeed(Guid orgId, string serverId, string diskId)
        {
            return new Uri(string.Format("{0}/server/{1}/disk/{2}/changeSpeed", orgId, serverId, diskId), UriKind.Relative);
        }


        /// <summary>
        /// Change server disk size
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <param name="diskId">The disk id</param>
        /// <returns>Returns the relative URI of the REST request for change server disk size the server</returns>
        internal static Uri ChangeServerDiskSize(Guid orgId, string serverId,string diskId)
        {
            return new Uri(string.Format("{0}/server/{1}/disk/{2}/changeSize", orgId, serverId,diskId), UriKind.Relative);
        }

        /// <summary>
        /// Adds a additional disk to a CaaS server
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <param name="size">the size of the new disk</param>
        /// <param name="speedId">the speed of the new disk</param>
        /// <returns></returns>
        internal static Uri AddServerDisk(Guid orgId, string serverId,string size,string speedId)
        {
            string uri = "{0}/server/{1}?addLocalStorage&";
            var querystringcollection = new NameValueCollection();
            if (!string.IsNullOrEmpty(size))
                querystringcollection.Add("amount", size);
            if (!string.IsNullOrEmpty(speedId))
                querystringcollection.Add("speed", speedId);

            // build the query string with parameters
            string querystring = querystringcollection.ToQueryString();

            if (!string.IsNullOrEmpty(querystring))
                uri = string.Concat(uri, querystring);

            return new Uri(string.Format(uri, orgId,serverId), UriKind.Relative);
        }

        /// <summary>
        ///  The relative URI for the CaaS API action that deletes a server disk
        /// </summary>
        /// <param name="orgId">The organisation id</param>
        /// <param name="serverId">the server id</param>
        /// <param name="diskId">the disk id</param>
        /// <returns></returns>
        internal static Uri RemoveServerDisk(Guid orgId, string serverId, string diskId)
        {
            return new Uri(string.Format("{0}/server/{1}/disk/{2}?delete", orgId, serverId, diskId), UriKind.Relative);
        }


        /// <summary>
        /// The relative URI for the CaaS API action that creates a anti affinity rule
        /// </summary>
        /// <param name="orgId">The organisation id</param>
        /// <returns></returns>
        internal static Uri CreateAntiAffinityRule(Guid orgId)
        {
            return new Uri(string.Format("{0}/antiAffinityRule", orgId), UriKind.Relative);
        }

        /// <summary>
        /// The relative URI for the CaaS API action that deletes a anti affinity rule
        /// </summary>
        /// <param name="orgId">the org id</param>
        /// <param name="ruleId">the anti affinity rule id</param>
        /// <param name="location">the location</param>
        /// <param name="networkId">the network id</param>
        ///  <returns></returns>
        internal static Uri GetAntiAffinityRule(Guid orgId, string ruleId, string location, string networkId)
        {
            string uri = "{0}/antiAffinityRule";
           //build que query string paramenters
            var querystringcollection = new NameValueCollection();
           
            if (!string.IsNullOrEmpty(ruleId))
                querystringcollection.Add("id", ruleId);
            if (!string.IsNullOrEmpty(networkId))
                querystringcollection.Add("networkid", networkId);
            if (!string.IsNullOrEmpty(location))
                querystringcollection.Add("location", location);

            if (querystringcollection.AllKeys.Any())
                uri = string.Concat(uri, "?");
            // build the query string
            string querystring = querystringcollection.ToQueryString();

            if(!string.IsNullOrEmpty(querystring))
                uri = string.Concat(uri, querystring);

            return new Uri(string.Format(uri, orgId), UriKind.Relative);
        }

        /// <summary>
        /// The relative URI for the CaaS API action that deletes a anti affinity rule
        /// </summary>
        /// <param name="orgId"></param>
        /// <param name="ruleId"></param>
        /// <returns></returns>
        internal static Uri RemoveAntiAffinityRule(Guid orgId, string ruleId)
        {
            return new Uri(string.Format("{0}/antiAffinityRule/{1}?delete", orgId, ruleId), UriKind.Relative);
        }



        #region Network API

        /// <summary>
        /// Lists the Networks deployed across all data center locations for the supplied organization.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <returns>Returns the relative URI of the REST request for a list of networks</returns>
        internal static Uri NetworkWithLocations(Guid orgId)
        {
            return new Uri(string.Format("{0}/networkWithLocation", orgId), UriKind.Relative);
        }

        /// <summary>
        /// Create an ACL rule
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="networkId">The network id</param>
        /// <returns>Returns the relative URI of the REST request for creating an ACL rule</returns>
        internal static Uri CreateAclRule(Guid orgId, string networkId)
        {
            return new Uri(string.Format("{0}/network/{1}/aclrule", orgId, networkId), UriKind.Relative);
        }

        /// <summary>
        /// Removes the ACL rule
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="networkId">The network id</param>
        /// <param name="aclId">The ACL rule id</param>
        /// <returns>Returns the relative URI of the REST request for removing an ACL rule</returns>
        internal static Uri DeleteAclRule(Guid orgId, string networkId, string aclId)
        {
            return new Uri(string.Format("{0}/network/{1}/aclrule/{2}?delete", orgId, networkId, aclId), UriKind.Relative);
        }

        /// <summary>
        /// Getting all the ACL rules in the network
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="networkId">The network id</param>
        /// <returns>Returns the relative URI of the REST request for getting ACL rules</returns>
        internal static Uri GetAclRules(Guid orgId, string networkId)
        {
            return new Uri(string.Format("{0}/network/{1}/aclrule", orgId, networkId), UriKind.Relative);
        }

        /// <summary>
        /// Gets all the NAT rules for a specified network.
        /// </summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="networkId">The network id.</param>
        /// <returns>Returns the relative URI of the REST request for getting the NAT rules</returns>
        internal static Uri GetNatRules(Guid orgId, string networkId)
        {
            return new Uri(string.Format("{0}/network/{1}/natrule", orgId, networkId), UriKind.Relative);
        }

        /// <summary>
        /// Creates a new NAT rule.
        /// </summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="networkId">The network id.</param>
        /// <returns>Returns the relative URI of the REST request for creating a new NAT rule</returns>
        internal static Uri CreateNatRule(Guid orgId, string networkId)
        {
            return new Uri(string.Format("{0}/network/{1}/natrule", orgId, networkId), UriKind.Relative);
        }

        /// <summary>
        /// Deletes a specified NAT rule
        /// </summary>
        /// <param name="orgId">The organization id.</param>
        /// <param name="networkId">The network id.</param>
        /// <param name="natRuleId">The NAT rule id to delete</param>
        /// <returns>Returns the relative URI of the REST request for deleting an existing NAT rule</returns>
        internal static Uri DeleteNatRule(Guid orgId, string networkId, string natRuleId)
        {
            return new Uri(
                string.Format("{0}/network/{1}/natrule/{2}?delete", orgId, networkId, natRuleId),
                UriKind.Relative);
        }

        /// <summary>
        /// Gets the relative URI for the CaaS API action that creates a network in a specified data centre location.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <returns>Returns the relative URI of the REST request for creating a network.</returns>
        internal static Uri CreateNetwork(Guid orgId)
        {
            return new Uri(string.Format("{0}/networkWithLocation", orgId), UriKind.Relative);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orgId"></param>
        /// <param name="networkId"></param>
        /// <returns></returns>
        internal static Uri DeleteNetwork(Guid orgId, string networkId)
        {
            return new Uri(string.Format("{0}/network/{1}?delete", orgId, networkId), UriKind.Relative);
        }

        #endregion // Network API

        #region Backup URIs

        /// <summary>
        /// Enables the Backup service for a deployed Server. Requires the Organization ID, Server ID and the Service Plan being enabled.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for enabling the backup on the server</returns>
        internal static Uri EnableBackup(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}/backup", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// Disables the Backup service for a deployed server.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for disabling the backup on the server</returns>
        internal static Uri DisableBackup(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}/backup?disable", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// Modify the backup service plan for a deployed server.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for modifying the backup service pland of the server</returns>
        internal static Uri ChangeBackupPlan(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}/backup/modify", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// Backup client types associated with a specific server.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request listing the client types for the server</returns>
        internal static Uri BackupClientTypes(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}/backup/client/type", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// Backup storage policies associated with a specific server.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request listing the storage policies for the server</returns>
        internal static Uri BackupStoragePolicies(Guid orgId, string serverId)
        {
            return new Uri(
                string.Format("{0}/server/{1}/backup/client/storagePolicy", orgId, serverId),
                UriKind.Relative);
        }

        /// <summary>
        /// Backup schedule policies associated with a specific server.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request listing the schedule policies for the server</returns>
        internal static Uri BackupSchedulePolicies(Guid orgId, string serverId)
        {
            return new Uri(
                string.Format("{0}/server/{1}/backup/client/schedulePolicy", orgId, serverId),
                UriKind.Relative);
        }

        /// <summary>
        /// Retrieves complete details of how the Backup service is configured for a specific deployed Server.
        /// Requires the Organization ID and Server ID for the Server and that the Server already has the Backup service enabled.
        /// The user must be the Primary Administrator or a Sub-Administrator with the “backup” role. 
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for getting the backup details of the server</returns>
        internal static Uri GetBackupDetails(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}/backup", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// Provisions a new Backup Client for a deployed Server.
        /// Requires the Organization ID, the Server ID for the server and that the Server already has the Backup service enabled.
        /// The user must be the Primary Administrator or a Sub-Administrator with the “backup” role
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <returns>Returns the relative URI of the REST request for adding a backup client to the server</returns>
        internal static Uri AddBackupClient(Guid orgId, string serverId)
        {
            return new Uri(string.Format("{0}/server/{1}/backup/client", orgId, serverId), UriKind.Relative);
        }

        /// <summary>
        /// Removes a Backup Client for the Backup service on a deployed Server. Requires the Organization ID, 
        /// Server ID and Backup Client ID for the relevant Backup Client and Server and that the Server already has 
        /// the Backup service enabled. The user must be the Primary Administrator or a Sub-Administrator with the “backup” role. 
        /// Note that the Backup Client ID is available from the backupClient.id additionalInformation element in the 
        /// response received when the Backup Client was originally added. See Add Backup Client for details. 
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <param name="backupClientId">The backup client id to remove</param>
        /// <returns>Returns the relative URI of the REST request for removing a backup client from the server</returns>
        internal static Uri RemoveBackupClient(Guid orgId, string serverId, string backupClientId)
        {
            return new Uri(
                string.Format("{0}/server/{1}/backup/client/{2}?remove", orgId, serverId, backupClientId),
                UriKind.Relative);
        }

        /// <summary>
        /// Modifies the settings of an existing Backup Client for a deployed Server.
        /// Requires the Organization ID, the Server ID for the server and that the Server already has the Backup service enabled.
        /// The user must be the Primary Administrator or a Sub-Administrator with the “backup” role. 
        /// <remarks>Note that the Backup Client type cannot be changed.</remarks>
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <param name="backupClientId">The backup client id to modify</param>
        /// <returns>Returns the relative URI of the REST request for modifying a backup client for the server</returns>
        internal static Uri ModifyBackupClient(Guid orgId, string serverId, string backupClientId)
        {
            return new Uri(
                string.Format("{0}/server/{1}/backup/client/{2}/modify", orgId, serverId, backupClientId),
                UriKind.Relative);
        }

        /// <summary>
        /// Requests an immediate Backup for a Backup Client
        /// </summary>
        /// <param name="organizationId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <param name="backupClientId">The backup client id</param>
        /// <returns>Returns the relative URI of the REST request for initiating a backup on the client</returns>
        public static Uri InitiateBackup(Guid organizationId, string serverId, string backupClientId)
        {
            return new Uri(
                string.Format("{0}/server/{1}/backup/client/{2}?backupNow", organizationId, serverId, backupClientId),
                UriKind.Relative);
        }

        /// <summary>
        /// Requests a cancellation of all running jobs for a backup client
        /// </summary>
        /// <param name="organizationId">The organization id</param>
        /// <param name="serverId">The server id</param>
        /// <param name="backupClientId">The backup client id</param>
        /// <returns>Returns the relative URI of the REST request for cancelling backup jobs on the client</returns>
        public static Uri CancelBackupJobs(Guid organizationId, string serverId, string backupClientId)
        {
            return new Uri(
                string.Format("{0}/server/{1}/backup/client/{2}?cancelJob", organizationId, serverId, backupClientId),
                UriKind.Relative);
        }

 
        #endregion // Backup URIs

        #region Import and Export Customer Image API

        /// <summary>
        /// Gets the relative URI for the CaaS API action that retrieves a list of OVF Packages
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <returns>Returns the relative URI of the REST request for getting the OVF Packages</returns>
        internal static Uri GetOvfPackages(Guid orgId)
        {
            return new Uri(string.Format("{0}/ovfPackage", orgId), UriKind.Relative);
        }

        /// <summary>
        /// Gets the relative URI for the CaaS API action that POST a request to import a customer image
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <returns>Returns the relative URI of the REST request for importing a customer image</returns>
        internal static Uri ImportCustomerImage(Guid orgId)
        {
            return new Uri(string.Format("{0}/imageImport", orgId), UriKind.Relative);
        }

        /// <summary>
        /// Gets the relative URI for the CaaS API action that retrieves a list of customer image imports in progress.
        /// </summary>
        /// <param name="orgId">The organization id</param>
        /// <returns>a list of customer image imports in progress</returns>
        internal static Uri GetCustomerImageImports(Guid orgId)
        {
            return new Uri(string.Format("{0}/imageImport", orgId), UriKind.Relative);
        }

        /// <summary>
        /// Get Uri for Provision On Geo
        /// </summary>
        /// <param name="organizationId">Organization Id</param>
        /// <returns>Uri</returns>
        internal static Uri GetUriForProvisionOnGeo(Guid organizationId)
        {
            return new Uri(string.Format("{0}/provisionOnGeo", organizationId), UriKind.Relative);
        }

        /// <summary>
        /// Get Uri for Provisioning
        /// </summary>
        /// <param name="organizationId">Organization Id</param>
        /// <returns>Uri</returns>
        internal static Uri GetUriForProvisioning(Guid organizationId)
        {
            return new Uri(string.Format("{0}/provision", organizationId), UriKind.Relative);
        }

        /// <summary>
        /// Get Uri For Listing Pricing Plans
        /// </summary>
        /// <param name="organizationId">Organization Id</param>
        /// <param name="geoId">Geo Id</param>
        /// <returns>Uri</returns>
        internal static Uri GetUriForListingPricingPlans(Guid organizationId, Guid geoId)
        {
            return new Uri(string.Format("{0}/geo/{1}/pricingplan", organizationId, geoId), UriKind.Relative);
        }

        /// <summary>
        /// Get Uri For List Multi-Geography Data Centers With Key
        /// </summary>
        /// <param name="organizationId">Organization Id</param>
        /// <returns>Uri</returns>
        internal static Uri GetUriForListMultiGeoDataCentersWithKey(Guid organizationId)
        {
            return new Uri(string.Format("{0}/multigeo", organizationId), UriKind.Relative);
        }

        #endregion // Import and Export Customer Image API

      
    }
}
