using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;

namespace SR.Xam.Sample.Helpers
{
    public static class ConnectivityHelper
    {
        private static DateTime _lastCheckDateConnectivity;
        private static bool _lastCheckResponseConnectivity;

        static ConnectivityHelper()
        {
            _lastCheckDateConnectivity = DateTime.MinValue;
            _lastCheckResponseConnectivity = false;
        }

        public static async Task<bool> CheckConnectivityAsync()
        {
            bool response;
            //checking internet connectivity pinging to google
            if (CrossConnectivity.Current.IsConnected)
            {
                if (_lastCheckDateConnectivity.AddSeconds(3) < DateTime.Now)
                {
                    _lastCheckDateConnectivity = DateTime.Now;
                    //validate
                    string host = "https://www.google.com.pe/";

                    bool isHostReachable;
                    isHostReachable = await CrossConnectivity.Current.IsRemoteReachable(host);

                    if (isHostReachable == true)
                    {
                        response = isHostReachable;
                    }
                    else
                    {
                        response = isHostReachable;
                    }
                }
                else
                {
                    response = _lastCheckResponseConnectivity;
                }
            }
            else
            {
                response = false;
            }
            _lastCheckResponseConnectivity = response;

            return response;
        }
    }
}
