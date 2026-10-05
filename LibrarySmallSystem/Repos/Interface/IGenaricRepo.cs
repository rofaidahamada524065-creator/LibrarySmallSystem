namespace LibrarySmallSystem.Repos.Interface
{
    public interface IGenaricRepo<T> where T : class
    {
        void Add(T entity);
        void Update(T entity,int id);
        void Delete(int id);
        T GetById(int id);

        List<T> GetAll();
    }
}
