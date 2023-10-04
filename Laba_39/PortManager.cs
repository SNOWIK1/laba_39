using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Laba_39
{
    static class PortManager
    {
        static readonly IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
        public static void GetPortsInfo()
        {
            Thread anotherThread = new Thread(GetTCPConnectionsInfo);

            IPEndPoint[] test = GetIPEndPoints();
            anotherThread.Start();
        }

        private static IPEndPoint[] GetIPEndPoints()
        {
            IPEndPoint[] tcpEndPoints = properties.GetActiveTcpListeners();
            return tcpEndPoints;
        }

       private static void GetTCPConnectionsInfo ()
        {
            TcpConnectionInformation[] tcpConnections = properties.GetActiveTcpConnections();

            var some = tcpConnections.Select(p =>
            {
                return new PortInfo(
                i: p.LocalEndPoint.Port, //port number
                local: String.Format("{0}:{1}", p.LocalEndPoint.Address,
                p.LocalEndPoint.Port),
                remote: String.Format("{0}:{1}", p.RemoteEndPoint.Address,
                p.RemoteEndPoint.Port),
                state: p.State.ToString());
            }).ToList();

            Console.WriteLine(some);
        }

    }
}
