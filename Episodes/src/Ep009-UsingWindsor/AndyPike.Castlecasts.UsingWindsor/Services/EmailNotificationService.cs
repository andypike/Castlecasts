namespace AndyPike.Castlecasts.UsingWindsor.Services
{
    public class EmailNotificationService : INotificationService
    {
        private readonly ILoggingService loggingService;

        public EmailNotificationService(ILoggingService loggingService)
        {
            this.loggingService = loggingService;
        }

        public void Send()
        {
            loggingService.Info("Sent notification");
        }
    }
}