using System.Globalization;

namespace DbLocalizationProvider
{
    public class Tenant
    {
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public CultureInfo CultureInfo { get; set; }

    }
}
