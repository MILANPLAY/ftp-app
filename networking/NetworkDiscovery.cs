using System.Net.Sockets;
using System.Net;
using System.Text;
using static NetworkUtility;

public class NetworkDiscovery
{

    private static bool Sender_Active = false;

    public static IPProperties IP = GetIPProperties(true)[0];

    public static void throwerror()
    {
        throw new Exception();
    }

    public static async Task DiscoverUDP(int Port = 5000, string message = "Default")
    {
       
        byte[] data = Encoding.UTF8.GetBytes(message);
        using (UdpClient udpClient = new UdpClient())
        {
            udpClient.EnableBroadcast = true;

           
            IPAddress localIPAddress = IPAddress.Parse(IP.IPAddress);
            IPAddress SubnetMask = IPAddress.Parse(IP.SubnetMask);

            IPEndPoint localEndPoint = new IPEndPoint(localIPAddress, 0);
            udpClient.Client.Bind(localEndPoint);

            IPEndPoint broadcastEndPoint = new IPEndPoint(GetBroadcastAddress(localIPAddress,SubnetMask), Port);
            Sender_Active = true;
            while (Sender_Active)
            {
                udpClient.Send(data, data.Length, broadcastEndPoint);
                Thread.Sleep(1000);
            }
        }
    }

    public static void StopDiscoverUDP()
    {
        Sender_Active = false;
    }

    public static async Task<List<IPEndPoint>> ListenUDP(int Port = 5000, string message = "Default", string Response = "Awnser", int timeout = 2000)
    {
        List<IPEndPoint> Online = new List<IPEndPoint>();
        using (UdpClient listener = new UdpClient(new IPEndPoint(IPAddress.Any, Port)))
        {
            listener.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            listener.Client.ReceiveTimeout = timeout;
            IPEndPoint remoteEndpoint = new IPEndPoint(IPAddress.Any, Port);
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    byte[] receivedBytes = listener.Receive(ref remoteEndpoint);
                    string receivedMessage = Encoding.ASCII.GetString(receivedBytes);
                    if (receivedMessage == message)
                    {
                        byte[] responseBytes = Encoding.ASCII.GetBytes(Response);
                        listener.Send(responseBytes, responseBytes.Length, remoteEndpoint);
                        if (!Online.Contains(remoteEndpoint) && remoteEndpoint.Address.ToString() != IP.IPAddress ) Online.Add(remoteEndpoint);
                        
                    }
                }
                catch (SocketException ex)
                {
                }
            }
        }
        return Online;
    }






    private static IPAddress GetBroadcastAddress(IPAddress ipAddress, IPAddress subnetMask)
    {
        byte[] ipBytes = ipAddress.GetAddressBytes();
        byte[] maskBytes = subnetMask.GetAddressBytes();

        if (ipBytes.Length != maskBytes.Length)
        {
            throw new ArgumentException("Lengths of IP address and subnet mask do not match.");
        }

        byte[] broadcastBytes = new byte[ipBytes.Length];
        for (int i = 0; i < ipBytes.Length; i++)
        {
            // Broadcast address is (IP address | ~Subnet mask)
            broadcastBytes[i] = (byte)(ipBytes[i] | (maskBytes[i] ^ 255)); // ~Subnet mask = ^ 255
        }

        return new IPAddress(broadcastBytes);
    }
}