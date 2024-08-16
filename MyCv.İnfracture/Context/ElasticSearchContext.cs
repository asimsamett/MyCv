using Microsoft.Extensions.Configuration;
using Nest;

public class ElasticSearchContext
{
    private readonly IElasticClient _client;

    public ElasticSearchContext(IConfiguration configuration)
    {
        var settings = new ConnectionSettings(new Uri(configuration["Elasticsearch:Url"]))
            .DefaultIndex(configuration["Elasticsearch:DefaultIndex"]);

        _client = new ElasticClient(settings);
    }

    public IElasticClient Client => _client;
}
