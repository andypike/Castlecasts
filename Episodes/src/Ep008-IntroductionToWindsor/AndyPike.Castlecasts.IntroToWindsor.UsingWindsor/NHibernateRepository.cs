using System;

namespace AndyPike.Castlecasts.IntroToWindsor.UsingWindsor
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
            Console.WriteLine("Inside Save");

            //Save the entity
            logger.Info("Saved an entity");
        }
    }
}