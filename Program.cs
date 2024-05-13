using ConsoleApp_metrics;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<HatCoMetrics>();

var app = builder.Build();

// Endpoint
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
