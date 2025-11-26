namespace Sampel.RestAPI.Endpoints.API.Authentication
{
    public class JwtOptions
    {
        public string Issuer { get; set; } = "";
        public string Audience { get; set; } = "";
        public string Key { get; set; } = ""; // Secret Key
        public int ExpirationMinutes { get; set; } = 60;
    }
}

