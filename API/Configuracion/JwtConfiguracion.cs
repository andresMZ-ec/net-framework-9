using DotNetEnv;

namespace API.Configuracion
{
    public class JwtPayload
    {
        public string KeySecret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationMinutes { get; set; }
    }

    public class JwtConfiguracion : JwtPayload
    {
        public JwtConfiguracion()
        {
            Env.Load();

            KeySecret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? string.Empty;
            Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? string.Empty;
            Audience = Environment.GetEnvironmentVariable("JWT_URL_AUDIENCE") ?? string.Empty;

            _ = int.TryParse(Environment.GetEnvironmentVariable("JWT_TIME_EXPIRATION"), out int expiration);
            ExpirationMinutes =  expiration > 0 ? expiration : 120;
        }

    }


}
