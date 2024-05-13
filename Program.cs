using ConsoleApp_metrics;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Adiciona HatCoMetrics como um singleton para que uma única instância seja usada durante toda a execução da aplicação
builder.Services.AddSingleton<HatCoMetrics>();

var app = builder.Build();

// Endpoint para acionar a simulação de métricas
app.MapGet("/metrics", (HatCoMetrics metrics) =>
{
    metrics.SimulateMetrics();
    return Results.Ok("Métricas simuladas com sucesso.");
});

app.Run();

public partial class Program
{
    static Meter s_meter = new Meter("HatCo.Store");
    static Counter<int> s_hatsSold = s_meter.CreateCounter<int>("hatco.store.hats_sold");
    static ObservableCounter<int> s_coatsSold = s_meter.CreateObservableCounter<int>("hatco.store.coats_sold", () => s_rand.Next(1, 10));
    static Random s_rand = new Random();

    // Esta parte parece ser um resíduo de código de console e deve ser removida ou comentada se não estiver sendo usada.
    /*
    public static void Main(string[] args)
    {
        Console.WriteLine(s_hatsSold);
        Console.WriteLine(s_coatsSold);

        while (!Console.KeyAvailable)
        {
            Thread.Sleep(1000);
            s_hatsSold.Add(4);
        }
    }
    */
}
