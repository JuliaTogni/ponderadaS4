using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading;

class Program
{
    static Meter s_meter = new Meter("HatCo.Store");
    static bool isRunning = true;
    static MeterListener listener = new MeterListener();

    static void Main(string[] args)
    {
        s_meter.CreateObservableGauge<int>("hatco.store.orders_pending", GetOrdersPending);

        // Configurando o listener para exibir as métricas
        listener.InstrumentPublished = (instrument, l) =>
        {
            if (instrument.Meter.Name == "HatCo.Store" && instrument.Name == "hatco.store.orders_pending")
                l.EnableMeasurementEvents(instrument);
        };

        listener.SetMeasurementEventCallback<int>((instrument, measurement, tags, state) =>
        {
            Console.WriteLine($"{instrument.Name}[{tags.GetKeyValue(0).Key}={tags.GetKeyValue(0).Value}] {measurement}");
        });

        listener.Start();

        Console.WriteLine("Press p to pause, r to resume, q to quit.");
        Console.WriteLine("    Status: Running");

        while (true)
        {
            char command = Console.ReadKey(true).KeyChar;
            switch (command)
            {
                case 'p':
                    Console.WriteLine("    Status: Paused");
                    Pause();
                    break;
                case 'r':
                    Console.WriteLine("    Status: Running");
                    Resume();
                    break;
                case 'q':
                    Quit();
                    return;
            }
        }
    }

    static IEnumerable<Measurement<int>> GetOrdersPending()
    {
        if (!isRunning) yield break;

        yield return new Measurement<int>(6, new KeyValuePair<string, object>("customer.country", "Italy"));
        yield return new Measurement<int>(3, new KeyValuePair<string, object>("customer.country", "Spain"));
        yield return new Measurement<int>(1, new KeyValuePair<string, object>("customer.country", "Mexico"));
    }

    static void Pause()
    {
        isRunning = false;
    }

    static void Resume()
    {
        isRunning = true;
    }

    static void Quit()
    {
        Console.WriteLine("Shutting down...");
        listener.Stop();  // Solicita que o listener pare de coletar eventos
        listener.Dispose();  // Libera os recursos associados ao listener
        Thread.Sleep(1000);  // Pausa para permitir que a saída final seja exibida no console

        Environment.Exit(0);  // Give time for final outputs to display
    }
}
