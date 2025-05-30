namespace INFRAESTRUCTURE.Repository
{

    #region Librerias

    
    using CORE.Interfaces.Repositories;
    using Domain.Context;
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;
    using System.Reflection;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BaseRepository   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        #region Atributos y Propiedades

        private readonly DbSet<T> _dbSet;

        #endregion

        #region Constructor

        public BaseRepository(EFContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
        }

        #endregion

        #region #region Métodos y Funciones
                
        public T Get(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression)!;
        }
                
        public List<T> List(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }
                
        public IEnumerable<T> IEnumerable(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
               
        public T Add(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }
                
        public IEnumerable<T> AddRange(IEnumerable<T> entity)
        {
            _dbSet.AddRange(entity);
            return entity;
        }
               
        public T Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
               
        public IEnumerable<T> AddUpdate(IEnumerable<T> entity)
        {
            _dbSet.UpdateRange(entity);
            return entity;
        }
               
        public bool Delete(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }
               
        public bool RemoveRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
            return true;
        }

        public void LoadRelatedEntity(T entity, string relatedProperty)
        {
            PropertyInfo propiedad = entity.GetType().GetProperty(relatedProperty)!;
            var entry = _dbSet.Attach(entity);
            entry.Reference(propiedad.Name).Load();
        }
              
        public void LoadRelatedEntity(T entity, Expression<Func<T, object>> relatedProperty)
        {
            string entityProperty = string.Empty;

            if (relatedProperty.Body is MemberExpression memberExpression)
                entityProperty = memberExpression.Member.Name;
            else if (relatedProperty.Body is UnaryExpression unaryExpression && unaryExpression.Operand is MemberExpression operand)
                entityProperty = operand.Member.Name;

            var entry = _dbSet.Attach(entity);
            entry.Reference(entityProperty).Load();
        }
               
        public void LoadRelatedCollection(T entity, string relatedProperty)
        {
            PropertyInfo property = entity.GetType().GetProperty(relatedProperty)!;
            var entry = _dbSet.Attach(entity);
            entry.Collection(property.Name).Load();
        }
               
        public void LoadRelatedCollection(T entity, Expression<Func<T, object>> relatedProperty)
        {
            string propertyCollection = string.Empty;

            if (relatedProperty.Body is MemberExpression memberExpression)
                propertyCollection = memberExpression.Member.Name;
            else if (relatedProperty.Body is UnaryExpression unaryExpression && unaryExpression.Operand is MemberExpression operand)
                propertyCollection = operand.Member.Name;

            var entry = _dbSet.Attach(entity);
            entry.Collection(propertyCollection).Load();
        }

        #endregion Methods

    }
}