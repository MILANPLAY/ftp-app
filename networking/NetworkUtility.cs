using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

public class NetworkUtility
{
    public class IPProperties
    {
        public string InterfaceName { get; set; }
        public string IPAddress { get; set; }
        public string SubnetMask { get; set; }
    }

    public static List<IPProperties> GetIPProperties(bool filterVPNs = false)
    {
        List<IPProperties> ipPropsList = new List<IPProperties>();

        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (nic.OperationalStatus == OperationalStatus.Up)
            {
                if (filterVPNs && IsLikelyVPN(nic))
                {
                    continue;
                }

                IPInterfaceProperties ipProps = nic.GetIPProperties();

                foreach (UnicastIPAddressInformation ipInfo in ipProps.UnicastAddresses)
                {
                    if (ipInfo.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        ipPropsList.Add(new IPProperties
                        {
                            InterfaceName = nic.Name,
                            IPAddress = ipInfo.Address.ToString(),
                            SubnetMask = ipInfo.IPv4Mask.ToString()
                        });
                    }
                }
            }
        }

        return ipPropsList;
    }

    private static bool IsLikelyVPN(NetworkInterface nic)
    {
        string name = nic.Name.ToLower();
        string description = nic.Description.ToLower();

        if (name.Contains("vpn") || description.Contains("vpn") ||
            description.Contains("virtual") || description.Contains("tun") ||
            description.Contains("tap") || description.Contains("ppp") ||
            nic.NetworkInterfaceType == NetworkInterfaceType.Tunnel ||
            nic.NetworkInterfaceType == NetworkInterfaceType.Ppp)
        {
            return true;
        }

        return false;
    }

    public static string GetHostNameFromIP(string ipAddress)
    {
        try
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(ipAddress);
            return hostEntry.HostName;
        }
        catch (Exception ex)
        {
            return $"Could not resolve hostname: {ex.Message}";
        }
    }
}
