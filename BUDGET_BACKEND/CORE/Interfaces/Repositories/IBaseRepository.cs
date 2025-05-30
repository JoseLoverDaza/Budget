namespace CORE.Interfaces.Repositories
{

    #region Using

    using System.Linq.Expressions;

    #endregion Using

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: IBaseRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public interface IBaseRepository<T> where T : class
    {

        #region Métodos y Funciones
                
        public T Get(Expression<Func<T, bool>> expression);
               
        public List<T> List(Expression<Func<T, bool>> expression);
                
        public IEnumerable<T> IEnumerable(Expression<Func<T, bool>> expression);
                
        public T Add(T entity);
               
        public IEnumerable<T> AddRange(IEnumerable<T> entity);
                
        public T Update(T entity);
               
        public IEnumerable<T> AddUpdate(IEnumerable<T> entity);
               
        public bool Delete(T entity);
               
        public bool RemoveRange(IEnumerable<T> entity);
                
        public void LoadRelatedEntity(T entity, string relatedProperty);
                
        public void LoadRelatedEntity(T entity, Expression<Func<T, object>> relatedProperty);
               
        public void LoadRelatedCollection(T entity, string relatedProperty);
               
        public void LoadRelatedCollection(T entity, Expression<Func<T, object>> relatedProperty);

        #endregion Methods

    }
}