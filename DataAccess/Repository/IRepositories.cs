using Core.Abstract;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    // 1. <TEntity> => Bu Sınıf Bir Generic Type'dir. Her türlü Yapı ile çalışabilir anlamındadır.
    // 2. where TEntity:class => Bu Repositories sadece Class Yapılarını kabul edecektir
    // 3. IEntity => Class'lardan sadece IEntity Interface'sinden miras alanları kabul edecektir.

    /* NOT : Asenkron Programalama, Sistemden Bağımsız olarak Sırasız bir şekilde Arkaplanda işlemleri yaptırıp hazır olunca sisteme yansıtmamızı sağlayan bir kod yapısıdır. Çok Fazla Asenkron işlem Sistemi zor duruma düşürür.

    Task => İşlem'in Sonucunun Asenkron döndürüleceğini belirtir.
    Async => İşlem'in Asenkron olarak yapılacağını belirtir.

    */
    public interface IRepositories<TEntity> where TEntity:class,IEntity
    {
        public Task AsyncAdd(TEntity entity);
        public Task AsyncUpdate(TEntity entity);
        public Task<TEntity> AsyncFirst(Expression<Func<TEntity,bool>> where,params Expression<Func<TEntity,object>>[] include);
        public Task<IList<TEntity>> AsyncGetAll(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] include);
        public Task AsyncDelete(Expression<Func<TEntity, bool>> where);
    }
}
