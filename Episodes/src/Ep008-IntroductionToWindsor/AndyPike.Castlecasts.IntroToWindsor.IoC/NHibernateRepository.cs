namespace AndyPike.Castlecasts.IntroToWindsor.IoC
{
    public class NHibernateRepository<T> : IRepository<T>
    {
        private readonly ILogger logger;

        public NHibernateRepository(ILogger logger)
        {
            this.logger = logger;
        }

        public void Save(T entity)
        {
            //Save the entity
            logger.Info("Saved an entity");
        }
    }
}