using System.Linq.Expressions;

namespace PortfolioApp.Application.Interfaces.Services;


public interface IBackgroundJobService
{
string Enqueue(Expression<Action> methodCall);
string Enqueue<T>(Expression<Action<T>> methodCall);
string Schedule(Expression<Action> methodCall, TimeSpan delay);
string ContinueJobWith(string parentJobId, Expression<Action> methodCall);
void AddOrUpdateRecurringJob(string recurringJobId, Expression<Action> methodCall, string cronExpression);

}