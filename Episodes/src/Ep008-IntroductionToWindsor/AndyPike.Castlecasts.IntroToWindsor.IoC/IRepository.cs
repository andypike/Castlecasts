namespace AndyPike.Castlecasts.IntroToWindsor.IoC
{
    public interface IRepository<T>
    {
        void Save(T entity);
    }
}