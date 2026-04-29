using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class Worker : BackgroundService
{
    private readonly  ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Remote agent started!");

        while(!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Agent is still alive at {time}", DateTimeOffset.Now);
            await Task.Delay(3000, stoppingToken);
        }
    }
}