internal interface IGenericRepository<T> where T : class, new()
{

    public T Get()
    {
        return new T();
    }
}