namespace Demo_ASP_MVC_Modele.DAL.Interfaces
{
   
    public interface IRepository<TKey, TEntity>
        where TEntity : IEntity<TKey> 
    {
        // Ajout des méthodes du CRUD

        // - Create
        TKey Insert(TEntity entity);

        // - Read
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TKey id);

        // - Update
        bool Update(TEntity entity);

        // - Delete
        bool Delete(TKey id); //renvoit un booleen pour savoir si le delete a ete fait

    }
}
