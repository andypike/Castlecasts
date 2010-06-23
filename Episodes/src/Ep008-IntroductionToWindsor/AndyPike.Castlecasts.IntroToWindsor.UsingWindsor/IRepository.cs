namespace AndyPike.Castlecasts.IntroToWindsor.UsingWindsor
{
    public interface IRepository<T>
    {
        void Save(T entity);
    }
}