using Entity;
using System.Linq.Expressions;

namespace Core
{
    public interface IRepository<T> where T : class, IBaseEntity, new()
    {
        T GetById(int id); // Bir nesnenin ID'sine göre senkron olarak bulunması.
        T Get(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll(); // Tüm nesnelerin senkron olarak listelenmesi.

        void Add(T entity); // Bir nesnenin senkron olarak eklenmesi.

        void Update(T entity); // Bir nesnenin senkron olarak güncellenmesi.

        void Delete(T entity); // Bir nesnenin senkron olarak silinmesi.

        void DeleteById(int id); // ID'si verilen bir nesnenin senkron olarak silinmesi.

    }
}
