using Windows.System.Profile;

namespace CompositionHelper.Util
{
    public static class DeviceUtil
    {
        private static string[] GetDeviceOsVersion()
        {
            string sv = AnalyticsInfo.VersionInfo.DeviceFamilyVersion;
            ulong v = ulong.Parse(sv);
            ulong v1 = (v & 0xFFFF000000000000L) >> 48;
            ulong v2 = (v & 0x0000FFFF00000000L) >> 32;
            ulong v3 = (v & 0x00000000FFFF0000L) >> 16;
            ulong v4 = (v & 0x000000000000FFFFL);
            return new string[] { v1.ToString(), v2.ToString(), v3.ToString(), v4.ToString() };
        }

        public static string OSVersion
        {
            get
            {
                string sv = AnalyticsInfo.VersionInfo.DeviceFamilyVersion;
                ulong v = ulong.Parse(sv);
                ulong v1 = (v & 0xFFFF000000000000L) >> 48;
                ulong v2 = (v & 0x0000FFFF00000000L) >> 32;
                ulong v3 = (v & 0x00000000FFFF0000L) >> 16;
                ulong v4 = (v & 0x000000000000FFFFL);
                return $"{v1}.{v2}.{v3}.{v4}";
            }
        }

        public static bool IsTh1OS
        {
            get
            {
                var versions = GetDeviceOsVersion();
                return versions[2] == "10240";
            }
        }

        public static bool IsTh2OS
        {
            get
            {
                var versions = GetDeviceOsVersion();
                return versions[2] == "10586";
            }
        }

        public static bool IsRs1OS
        {
            get
            {
                var versions = GetDeviceOsVersion();
                return versions[2] == "14393";
            }
        }

        public static bool IsRs2OS
        {
            get
            {
                var versions = GetDeviceOsVersion();
                return versions[2] == "15063";
            }
        }
    }
}
