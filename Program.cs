using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using Lightrun;

LightrunAgent.Start(new AgentOptions {
    Secret = "d5415486-6a3d-432f-b547-e19dcc36366a",
    ServerUrl = new Uri("https://app.lightrun.com"),
});


var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services => {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

host.Run();
