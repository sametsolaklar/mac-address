using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }

        //İP ADRESS VE İPV6MAÇ ADRESS ALMA
                public string GetIpAddress1()
        {

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string ipAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            //List<string> ipAddresses = new List<string>();
            if (ipAddress == "::1")
            {


                var ipAddresses = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();//0 MAC ADRESİ DÖNER 1 İPADRES
            }

#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (string.IsNullOrEmpty(ipAddress))
            {

#pragma warning disable CS8601 // Possible null reference assignment.
                ipAddress = Request.HttpContext.GetServerVariable("REMOTE_ADDR");
#pragma warning restore CS8601 // Possible null reference assignment.
            }
            else
            {

            }


            return ipAddress;


        }








        //İP ADRESS VE MAÇ ADRESİ ALMA

        public PhysicalAddress GetIpAddress()
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            var ipAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            PhysicalAddress xa = new PhysicalAddress(new byte[] { });
            if (ipAddress == "::1")
            {
                var ipAddresses = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1];//0 MAC ADRESİ DÖNER 1 İPADRES
                xa = Lookup(ipAddresses);
            }
            return xa;
        }


        public PhysicalAddress Lookup(IPAddress ip)
        {
            if (ip == null)
                throw new ArgumentNullException(nameof(ip));

            int destIp = BitConverter.ToInt32(ip.GetAddressBytes(), 0);

            var addr = new byte[6];
            var len = addr.Length;

            var res = NativeMethods.SendARP(destIp, 0, addr, ref len);

            if (res == 0)
                return new PhysicalAddress(addr);
            throw new Win32Exception(res);
        }

        private class NativeMethods
        {
            private const string IphlpApi = "iphlpapi.dll";

            [DllImport(IphlpApi, ExactSpelling = true)]
            [SecurityCritical]
            internal static extern int SendARP(int destinationIp, int sourceIp, byte[] macAddress, ref int physicalAddrLength);
        }
    }
}