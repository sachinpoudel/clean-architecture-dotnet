using System.Linq.Expressions;
using Hangfire;
using PortfolioApp.Application.Interfaces.Services;

namespace PortfolioApp.Infrastructure.BackgroundJobs;


public class HangfireJobService : IBackgroundJobService
{
    public void AddOrUpdateRecurringJob(string recurringJobId, Expression<Action> methodCall, string cronExpression)
    {
         RecurringJob.AddOrUpdate(recurringJobId, methodCall, cronExpression); 
    }

    public string ContinueJobWith(string parentJobId, Expression<Action> methodCall)
    {
       return BackgroundJob.ContinueJobWith(parentJobId, methodCall); 
    }

    public string Enqueue(Expression<Action> methodCall)
    {
        return BackgroundJob.Enqueue(methodCall); // this bgjob is for fire and forget job, it will be executed once and enqueue means to add the job to the queue for execution.
    }

    public string Enqueue<T>(Expression<Action<T>> methodCall)
    {
        return BackgroundJob.Enqueue(methodCall); // 
    }

    public string Schedule(Expression<Action> methodCall, TimeSpan delay)
    {
            return BackgroundJob.Schedule(methodCall, delay); // schedule means to add the job to the queue for execution after a certain delay.
        }
}