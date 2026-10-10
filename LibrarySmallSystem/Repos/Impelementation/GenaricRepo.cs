using LibrarySmallSystem.Data;
using LibrarySmallSystem.Repos.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace LibrarySmallSystem.Repos.Impelementation
{
    public class GenaricRepo<T> : IGenaricRepo<T> where T : class
    {
        private readonly AppDbcontext _context;
        public DbSet<T> db;
        public GenaricRepo(AppDbcontext appDbcontext)
        {
            db = appDbcontext.Set<T>();
        }

        public void AddAsync(T entity)
        {
            db.Add(entity);
        }

        public void DeleteAsync(int id)
        {
            var x = db.Find(id);
            db.Remove(x);
        }

        public ICollection<T> GetAllAsync()
        {
            return db.ToList();
        }

        public T GetByIdAsync(int id)
        {
            return db.Find(id);
        }

        public void Update(T entity, int id)
        {
            var x = db.Find(id);
            db.Update(entity);
        }
    }
}
