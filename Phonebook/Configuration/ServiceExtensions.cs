using Microsoft.Extensions.DependencyInjection;
using Phonebook.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Phonebook.Infrastructure;

namespace Phonebook.Configuration
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configure Identity Service
        /// </summary>
        /// <param name="services">Reference to Service Collection Object</param>
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<User>(u => u.User.RequireUniqueEmail = true);

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
        }
    }
}
