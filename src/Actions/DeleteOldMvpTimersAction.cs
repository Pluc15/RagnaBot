using Microsoft.Extensions.Logging;

public class DeleteOldMvpTimersAction(
    MvpTimersRepository mvpTimersRepository,
    ILogger<DeleteOldMvpTimersAction> logger)
{
    public void Run()
    {
        foreach (var timer in mvpTimersRepository.GetTimersOldTimers())
        {
            mvpTimersRepository.DeleteTimer(timer.Timer.Id);
            logger.LogInformation($"Old timer deleted for {timer.Timer.Id}");
        }
    }
}