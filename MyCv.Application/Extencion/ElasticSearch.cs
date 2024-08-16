//using Elasticsearch.Net;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Win32.SafeHandles;
//using Nest;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyCv.Application.Extencion
//{
//    public static class ElasticSearch
//    {
        
//        public static void AddElastic(this IServiceCollection services, IConfiguration configuration)
//        {
//            var pool = new SingleNodeConnectionPool(new Uri(configuration.GetSection("Elastic")["Url"]));
//            var settings= new ConnectionSettings(pool);
//            var client=new ElasticClient(settings);
//            services.AddSingleton(client);
//        }

//    }
//}
    