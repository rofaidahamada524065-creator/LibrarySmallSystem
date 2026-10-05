using LibrarySmallSystem.Data;
using LibrarySmallSystem.Repos.Interface;
using Microsoft.EntityFrameworkCore;

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
        public void Add(T entity)
        {
          db.Add(entity);

        }

        public void Delete(int id)
        {
            db.Remove(db.Find(id));
        }

        public List<T> GetAll()
        {
           return db.ToList();
        }

        public T GetById(int id)
        {
           return db.Find(id);
        }

        public void Update(T entity, int id)
        {
            var x = db.Find(id);
            if (x == null)
            {
                throw new Exception("Id not found");
            }
            db.Update(entity);

        }
    }
}
