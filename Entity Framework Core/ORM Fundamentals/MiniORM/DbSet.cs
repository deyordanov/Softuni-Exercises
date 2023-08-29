namespace MiniORM
{
    using System.Collections;
    using Exceptions;

    public class DbSet<TEntity> : ICollection<TEntity>
        where TEntity : class, new()
    {
        internal DbSet(IEnumerable<TEntity> entities)
        {
            this.Entities = entities.ToList();
            this.ChangeTracker = new ChangeTracker<TEntity>(entities);
        }
        internal ChangeTracker<TEntity> ChangeTracker { get; set; }
        internal IList<TEntity> Entities { get; set; }

        public void Add(TEntity? entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(ExceptionMessages.NullItemException);
            }
            this.Entities.Add(entity);
            this.ChangeTracker.Add(entity);
        }

        public void Clear()
        {
            while (this.Entities.Any())
            {
                TEntity entity = this.Entities.First();
                Remove(entity);
            }
        }

        public bool Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(ExceptionMessages.NullItemException);
            }
            
            bool isRemoved = this.Entities.Remove(entity);

            if (isRemoved)
            {
                this.ChangeTracker.Remove(entity);
            }

            return isRemoved;
        }
        public bool Contains(TEntity entity) => this.Entities.Contains(entity);
        public void CopyTo(TEntity[] array, int arrayIndex) => Entities.CopyTo(array, arrayIndex);
        public int Count => this.Entities.Count;
        public bool IsReadOnly => this.Entities.IsReadOnly;

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Remove(entity);
            }
        }
        public IEnumerator<TEntity> GetEnumerator() => this.Entities.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
