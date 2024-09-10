using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCv.Application.Interfaces.IElasticSearchRepostory;
using MyCv.Infrastructure.Repositories.ElasticSearchRepostory;
using Nest;
using System;

namespace MyCv.Infrastructure.Context
{
    public static class ElasticSearchContext
    {
        public static void AddElastic(this IServiceCollection services, IConfiguration configuration)
        {
            // ElasticSearch URI'sini appsettings.json'dan alın
            var pool = new SingleNodeConnectionPool(new Uri(configuration.GetSection("Elastic")["Url"]));
            var settings = new ConnectionSettings(pool);

            // ElasticClient oluşturulması
            var client = new ElasticClient(settings);

            // IElasticClient'ı DI konteynerine ekleyin
            services.AddSingleton<IElasticClient>(client);

            // Repository sınıflarını DI konteynerine ekleyin
            services.AddScoped<IReadElasticSearchRepostory, ReadElasticSearchRepostory>();
            services.AddScoped<IWriteElasticSearchRepostory, WriteElasticSearchRepostory>();
        }
    }
}
