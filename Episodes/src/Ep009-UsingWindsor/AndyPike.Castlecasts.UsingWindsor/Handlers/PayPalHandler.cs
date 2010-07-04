using AndyPike.Castlecasts.UsingWindsor.Services;

namespace AndyPike.Castlecasts.UsingWindsor.Handlers
{
    public class PayPalHandler : IPaymentHandler
    {
        private readonly INotificationService notificationService;
        private readonly ILoggingService loggingService;

        public PayPalHandler(INotificationService notificationService, ILoggingService loggingService)
        {
            this.notificationService = notificationService;
            this.loggingService = loggingService;
        }

        public void ProcessPayment()
        {
            //Do something with a payment from somewhere
            loggingService.Info("Processing payment...");

            notificationService.Send(/*some params that make sense go here*/);
        }
    }
}