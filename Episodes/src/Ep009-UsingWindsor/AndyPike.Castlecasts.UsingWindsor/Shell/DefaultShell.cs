using AndyPike.Castlecasts.UsingWindsor.Handlers;
using AndyPike.Castlecasts.UsingWindsor.Services;

namespace AndyPike.Castlecasts.UsingWindsor.Shell
{
    public class DefaultShell : IShell
    {
        private readonly ILoggingService loggingService;
        private readonly IPaymentHandler paymentHandler;

        public DefaultShell(ILoggingService loggingService, IPaymentHandler paymentHandler)
        {
            this.loggingService = loggingService;
            this.paymentHandler = paymentHandler;
        }

        public void Start()
        {
            loggingService.Info("Starting shell...");

            paymentHandler.ProcessPayment();

            loggingService.Info("All done!");
        }
    }
}