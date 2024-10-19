using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Project
{
    class Program
    {
        const int port = 64000;
        static async Task Main(string[] args)
        {
           
            if (args.Length == 0)
            {
                Console.WriteLine("Sending");
                Task.Run(() => NetworkDiscovery.DiscoverUDP(port));
                Console.WriteLine("10 sec");
                Thread.Sleep(100000);
                Console.WriteLine("Stopped Discover");
                NetworkDiscovery.StopDiscoverUDP();
            }
            else
            {
                Console.WriteLine("Collecting");
                var list = await NetworkDiscovery.ListenUDP(port);
                foreach (IPEndPoint arg in list) { Console.WriteLine(arg); }

            }


            Console.ReadKey();
        }
    }
}
