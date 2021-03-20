using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class TimeLogic
    {
        const string NtpServerAddress= "hu.pool.ntp.org";
        ModificationLogic modLogic;

        public TimeLogic(ModificationLogic modLogic)
        {
            this.modLogic = modLogic;
        }


        private DateTime GetNetworkTime()
        {
            const string NtpServer = NtpServerAddress;

            const int DaysTo1900 = 1900 * 365 + 95; // 95 = offset for leap-years etc.
            const long TicksPerSecond = 10000000L;
            const long TicksPerDay = 24 * 60 * 60 * TicksPerSecond;
            const long TicksTo1900 = DaysTo1900 * TicksPerDay;

            var ntpData = new byte[48];
            ntpData[0] = 0x1B;

            IPAddress[] addresses;
            try
            {
                addresses = Dns.GetHostEntry(NtpServer).AddressList;
            }
            catch (Exception)
            {
                return default;
            }
            var ipEndPoint = new IPEndPoint(addresses[0], 123);
            long pingDuration = Stopwatch.GetTimestamp(); // temp access (JIT-Compiler need some time at first call)
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Connect(ipEndPoint);
                socket.ReceiveTimeout = 5000;
                socket.Send(ntpData);
                pingDuration = Stopwatch.GetTimestamp(); // after Send-Method to reduce WinSocket API-Call time

                socket.Receive(ntpData);
                pingDuration = Stopwatch.GetTimestamp() - pingDuration;
            }

            long pingTicks = pingDuration * TicksPerSecond / Stopwatch.Frequency;

            long intPart = (long)ntpData[40] << 24 | (long)ntpData[41] << 16 | (long)ntpData[42] << 8 | ntpData[43];
            long fractPart = (long)ntpData[44] << 24 | (long)ntpData[45] << 16 | (long)ntpData[46] << 8 | ntpData[47];
            long netTicks = intPart * TicksPerSecond + (fractPart * TicksPerSecond >> 32);

            var networkDateTime = new DateTime(TicksTo1900 + netTicks + pingTicks / 2);

            return networkDateTime.ToLocalTime(); // without ToLocalTime() = faster
        }

        public DateTime GetCurrentDateTime()
        {
            DateTime dt = GetNetworkTime();
            if (dt!=default)
            {
                return dt;
            }
            return System.DateTime.Now;
        }
        public DateTime GetNextBellRing(DateTime DayDate)
        {
            IQueryable<BellRing> DaysBellRings = modLogic.GetBellRingsForDay(DayDate);
            DateTime dt = (from x in DaysBellRings
                           where x.BellRingTime > GetCurrentDateTime()
                           orderby x ascending
                           select x).FirstOrDefault().BellRingTime;
            return dt;
        }
    }
}
