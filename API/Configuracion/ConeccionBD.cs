using DotNetEnv;
using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace API.Configuracion
{
    public class VariableEntorno
    {
        public string? Host { get; set; }
        public string? Port { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }
        public string? Database { get; set; }
    }

    public class ConeccionBD
    {
        public ConeccionBD()
        {
            Env.Load();   
        }

        private string CadenaConeccion()
        {
            var variablesEntorno = new VariableEntorno()
            {
                Host = Environment.GetEnvironmentVariable("DB_HOST"),
                Port = Environment.GetEnvironmentVariable("DB_PORT"),
                User = Environment.GetEnvironmentVariable("DB_UID"),
                Password = Environment.GetEnvironmentVariable("DB_PWD"),
                Database = Environment.GetEnvironmentVariable("DB_NAME")                
            };

            foreach (var propiedad in typeof(VariableEntorno).GetProperties())
            {
                var valor = propiedad.GetValue(variablesEntorno) as string;

                if (string.IsNullOrEmpty(valor))
                {
                    throw new Exception($"La variables de entorno {propiedad.Name} no está declarada");
                }
            }

            return (
                $"server={variablesEntorno.Host};" +
                $"port={variablesEntorno.Port};" +
                $"uid={variablesEntorno.User};" +
                $"pwd={variablesEntorno.Password};" +
                $"database={variablesEntorno.Database};"
            );
        }

        public void ConectarMySql(WebApplicationBuilder builder)
        {
            var cadenaConeccion = CadenaConeccion();
            builder.Services.AddDbContext<AplicationDbContext>(options =>
            {
                options.UseMySql(
                    cadenaConeccion,
                    MySqlServerVersion.AutoDetect(cadenaConeccion),
                    b => b.MigrationsAssembly("Infraestructura")
                );
            });
        }

    }
}
