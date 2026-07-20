namespace PortfolioApp.Domain.Options;



public class HangfireSettings
{
    public string DashboardPath { get; set; } = "/jobs";
    public int WorkerCount { get; set; } = 1;
}