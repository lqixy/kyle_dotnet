using System;
namespace Kyle.Gateway
{
    public class AuthServerConfig
    {
        public AuthServerConfig()
        {
        }

        public string Authority { get; set; }

        public string ApiSecret { get; set; }

        public List<AuthServerConfigResource> Resources { get; set; }

    }

    public class AuthServerConfigResource
    {
        public string SchemeKey { get; set; }
        public string ApiName { get; set; }
    }
}

