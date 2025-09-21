using System.Text;
using AliHayderBase.Web.Core.Domain;
using AliHayderBase.Web.Core.Interface;
using AliHayderBase.Web.Persistence;
using AliHayderBase.Web.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AliHayderBase.Web.Dependencies
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAliHayderBaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            // 🔗 Connection String
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            // 🧱 DbContext
            services.AddDbContext<AliHayderDbContext>(options =>
                options.UseSqlServer(connectionString));

            // 🔐 Identity Configuration
            services.AddIdentity<User, Role>(options =>
            {
                options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
                options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
            })
            .AddEntityFrameworkStores<AliHayderDbContext>()
            .AddDefaultTokenProviders();

            var jwtKey = configuration["Jwt:secretKey"]
                ?? throw new InvalidOperationException("Missing JWT secret key");
            var jwtIssuer = configuration["Jwt:Issuer"]
                ?? throw new InvalidOperationException("Missing JWT issuer");
            var jwtAudience = configuration["Jwt:Audience"]
                ?? throw new InvalidOperationException("Missing JWT audience");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                    ValidIssuer = jwtIssuer,
                    ValidAudience = jwtAudience,
                    ClockSkew = TimeSpan.Zero
                };
            })
            .AddGoogle(options =>
            {
                options.ClientId = configuration["Google:ClientId"]
                    ?? throw new InvalidOperationException("Missing Google ClientId");
                options.ClientSecret = configuration["Google:ClientSecret"]
                    ?? throw new InvalidOperationException("Missing Google ClientSecret");
                options.CallbackPath = "/signin-google";
            });

            services.AddAuthorization();

            // 🧩 Repositories & Services
            services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IAuthRepository, AuthRepository>()
                .AddScoped<IExternalLoginRepository, ExternalLoginRepository>()
                .AddScoped<IEmailServicesRepository, EmailServicesRepository>()
                .AddScoped<IJwtRepository, JwtRepository>();

            return services;
        }

    }
}