using Demo.ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.Serialization;
using Microsoft.Extensions.Options;

namespace Demo.ApiClient.IoC
{
    public static class ServiceCollectionExtension
    {
        public static void AddDemoApiClientService(this IServiceCollection services,
            Action<ApiClientOptions> options)
        {
            services.Configure(options);
            services.AddSingleton(provider =>
            {
                var options = provider.GetRequiredService<IOptions<ApiClientOptions>>().Value;
                return new DemoApiclientService(options);
            });
        }

    }
}
