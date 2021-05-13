using System.Linq;

namespace Project.Core.Data
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Methods

        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        #endregion

        #region Properties

        IQueryable<TEntity> Table { get; }

        #endregion
    }
}
