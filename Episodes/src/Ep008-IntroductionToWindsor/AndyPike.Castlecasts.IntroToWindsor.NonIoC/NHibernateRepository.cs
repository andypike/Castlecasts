namespace AndyPike.Castlecasts.IntroToWindsor.NonIoC
{
    public class NHibernateRepository<T>
    {
        public void Save(T entity)
        {
            //Save the entity

            var logger = new FileLogger();
            logger.Info("Saved an entity");
        }
    }
}