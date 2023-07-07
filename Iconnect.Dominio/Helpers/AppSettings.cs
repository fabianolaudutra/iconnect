using System;
using System.Collections.Generic;
using System.Text;

namespace Iconnect.Dominio.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }

        public string WebSiteUrl { get; set; }

        public string IdentityServerUrl { get; set; }

        public string MultipartBodyLengthLimit { get; set; }
    }
}
