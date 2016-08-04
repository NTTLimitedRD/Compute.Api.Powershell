
New-CaasVlan
===================

Synopsis
--------

.. code-block:: powershell
    
    
New-CaasVlan -NetworkDomainId <string> -Name <string> -PrivateIpv4BaseAddress <ipaddress> -PrivateIpv4PrefixSize <int> [-Description <string>] [-Wait] [-Connection <ComputeServiceConnection>] [<CommonParameters>]

New-CaasVlan -NetworkDomain <NetworkDomainType> -Name <string> -PrivateIpv4BaseAddress <ipaddress> -PrivateIpv4PrefixSize <int> [-Description <string>] [-Wait] [-Connection <ComputeServiceConnection>] [<CommonParameters>]





Description
-----------



Parameters
----------




-Connection <ComputeServiceConnection>
~~~~~~~~~

The CaaS Connection created by New-CaasConnection

* Position?                    Named
* Accept pipeline input?       true (ByPropertyName)
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Description <string>
~~~~~~~~~

The vlan description

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Name <string>
~~~~~~~~~

The vlan name

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-NetworkDomain <NetworkDomainType>
~~~~~~~~~

The network domain

* Position?                    Named
* Accept pipeline input?       true (ByValue)
* Parameter set name           With_NetworkDomain
* Aliases                      None
* Dynamic?                     false





-NetworkDomainId <string>
~~~~~~~~~

The network domain id

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           With_NetworkDomainId
* Aliases                      None
* Dynamic?                     false





-PrivateIpv4BaseAddress <ipaddress>
~~~~~~~~~

The vlan Private Ipv4BaseAddress

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-PrivateIpv4PrefixSize <int>
~~~~~~~~~

The vlan Private Ipv4 PrefixSize, must be between 16 and 24

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





-Wait <switch>
~~~~~~~~~

Wait until provisioned before returning

* Position?                    Named
* Accept pipeline input?       false
* Parameter set name           (All)
* Aliases                      None
* Dynamic?                     false





Inputs
------

DD.CBU.Compute.Api.Contracts.Network20.NetworkDomainType
DD.CBU.Compute.Powershell.ComputeServiceConnection


Outputs
-------

DD.CBU.Compute.Api.Contracts.Network20.ResponseType


Notes
-----



Examples
---------


