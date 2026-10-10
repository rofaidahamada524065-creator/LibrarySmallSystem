namespace LibrarySmallSystem.Repos.Interface
{
    public interface IGenaricRepo<T> where T : class
    {
        void AddAsync(T entity);
        void Update(T entity,int id);
        void DeleteAsync(int id);
        T GetByIdAsync(int id);

        ICollection<T> GetAllAsync();
    }
}
