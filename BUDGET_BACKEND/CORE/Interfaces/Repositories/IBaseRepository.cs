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

        #region Methods

        /// <summary>      
        /// Descripción: Método que define la acción de consulta de una entidad
        /// Autor: Jose Daza
        /// </summary>
        /// <param name="expression"></param>
        /// <returns> T </returns>
        public T Get(Expression<Func<T, bool>> expression);

        /// <summary>       
        /// Descripción: Método que define la acción de consulta de un listado de entidades
        /// Autor: Asesoftware - Jose Daza
        /// </summary>
        /// <param name="expression"></param>
        /// <returns> List<T> </returns>
        public List<T> List(Expression<Func<T, bool>> expression);

        /// <summary>       
        /// Descripción: Método que define la acción de consulta de un listado de entidades
        /// Autor: Asesoftware - Jose Daza
        /// </summary>
        /// <param name="expression"></param>
        /// <returns> IEnumerable<T> </returns>
        public IEnumerable<T> IEnumerable(Expression<Func<T, bool>> expression);

        /// <summary>        
        /// Descripción: Método que define la acción de guardado sobre una entidad
        /// Autor: Jose Daza
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> T </returns>
        public T Add(T entity);

        /// <summary>        
        /// Descripción: Método que define la acción de guardado sobre una lista de entidades
        /// Autor: Jose Daza
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> IEnumerable<T> </returns>
        public IEnumerable<T> AddRange(IEnumerable<T> entity);

        /// <summary>       
        /// Descripción: Método que define la acción de modificado sobre una entidad
        /// Autor: Jose Daza
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> T </returns>
        public T Update(T entity);

        /// <summary>       
        /// Descripción: Método que define la acción de modificado sobre una lista de entidades
        /// Autor: Jose Daza
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> IEnumerable<T> </returns>
        public IEnumerable<T> AddUpdate(IEnumerable<T> entity);

        /// <summary>       
        /// Descripción: Método que define la acción de borrado sobre una entidad
        /// Autor: Jose Daza
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> bool </returns>
        public bool Delete(T entity);

        /// <summary>       
        /// Descripción: Método que define la acción de borrado sobre una lista de entidad
        /// Autor: Jose Daza
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> bool </returns>
        public bool RemoveRange(IEnumerable<T> entity);

        /// <summary>       
        /// Descripción: Método para cargar entidades relacionadas segun el nombre de la propiedad
        /// Autor: Jose Daza
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="relatedProperty"></param>
        /// <returns> void </returns>
        public void LoadRelatedEntity(T entity, string relatedProperty);

        /// <summary>       
        /// Descripción: Método para cargar entidades relacionadas segun una propiedad
        /// Autor: Jose Daza
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="relatedProperty"></param>
        /// <returns></returns>
        public void LoadRelatedEntity(T entity, Expression<Func<T, object>> relatedProperty);

        /// <summary>       
        /// Descripción: Método para cargar colecciones de entidades relacionadas segun el nombre de la propiedad
        /// Autor: Jose Daza
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="relatedProperty"></param>
        /// <returns></returns>
        public void LoadRelatedCollection(T entity, string relatedProperty);

        /// <summary>        
        /// Descripción: Método para cargar colecciones de entidades relacionadas segun una propiedad
        /// Autor: Jose Daza
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="relatedProperty"></param>
        /// <returns></returns>
        public void LoadRelatedCollection(T entity, Expression<Func<T, object>> relatedProperty);

        #endregion Methods

    }
}