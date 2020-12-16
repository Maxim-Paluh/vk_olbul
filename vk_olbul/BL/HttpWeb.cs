using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace vk_olbul.BL
{
    public static class HttpWeb
    {
        public static string Get(string url, int timeoutmilliseconds)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));
            bool ErrorInternetAvailability = false;
            while (true)
            {
                try
                {
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = timeoutmilliseconds;
                    request.Method = HttpMethod.Get;

                    string sourcePage = null;
                    var response = (HttpWebResponse)request.GetResponse();
                    using (var stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        sourcePage = stream.ReadToEnd();
                        response.Close();
                        stream.Close();
                    }
                    return sourcePage;
                }
                catch
                {
                    if (!InternetAvailability.IsInternetAvailable())
                    {
                        if (ErrorInternetAvailability)
                            throw new InternetAvailabilityException();
                        else
                            ErrorInternetAvailability = true;
                        continue;
                    }
                    throw;
                }

            }
        }
    }

    public static class HttpMethod
    {
        public static string Get { get { return "GET"; } }
        public static string Post { get { return "POST"; } }
        public static string Put { get { return "PUT"; } }
        public static string Delete { get { return "DELETE"; } }
    }

    public static class InternetAvailability
    {
        [DllImport("wininet.dll")]
        private static extern bool InternetGetConnectedState(out int description, int reservedValue);

        public static bool IsInternetAvailable()
        {
            try
            {
                int description;
                return InternetGetConnectedState(out description, 0);
            }
            catch
            {
                return false;
            }
        }
    }

    public class InternetAvailabilityException : Exception
    {
        public InternetAvailabilityException() : base("Нет подключения к интернету")
        {

        }
    }
}
