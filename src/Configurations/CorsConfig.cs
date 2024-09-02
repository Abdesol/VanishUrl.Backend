using Microsoft.AspNetCore.Cors.Infrastructure;

namespace VanishUrl.Api.Configurations;

public static class CorsConfig
{
    public static string CorsPolicyName = "AllowAll";
    
    public static void CorsPolicyConfig(CorsOptions options)
    {
        options.AddPolicy(CorsPolicyName, builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
    }
}
