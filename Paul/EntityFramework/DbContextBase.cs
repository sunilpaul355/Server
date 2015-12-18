using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Paul.EntityFramework
{
    public abstract class DbContextBase : DbContext
    {
        #region
        public DbContextBase()
            : base()
        {
            this.initializeContext();
        }
        protected DbContextBase(DbCompiledModel model)
            : base(model)
        {
            this.initializeContext();
        }
        public DbContextBase(DbConnection existingConnection)
            : base(existingConnection, false)
        {
            this.initializeContext();
        }
        public DbContextBase(ObjectContext objectContext)
            : base(objectContext, false)
        {
            this.initializeContext();
        }
        public DbContextBase(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            this.initializeContext();
        }
        public DbContextBase(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {
            this.initializeContext();
        }
        public DbContextBase(DbConnection existingConnection, DbCompiledModel model)
            : base(existingConnection, model, false)
        {
            this.initializeContext();
        }

        protected abstract void setDatabaseInitializer();

        #endregion

        #region Public method
        private IDataReader _dataReader;
        //public IDataReader currentReader
        //  {
        //    //  [CompilerGenerated]
        //      get
        //      {
        //          return this._dataReader;
        //      }
        //  }

        private void DataReader(IDataReader reader)
        {
            this._dataReader = reader;
        }

        public ObjectContext objectContext
        {
            get
            {
                return ((IObjectContextAdapter)this).ObjectContext;
            }
        }

        public List<TElement> translate<TElement>(IDataReader reader)
        {
            List<TElement> result;
            try
            {
                using (ObjectResult<TElement> objectResult = this.objectContext.Translate<TElement>((DbDataReader)reader))
                {
                    result = objectResult.ToList<TElement>();
                }
            }
            finally
            {
                this.translate<TElement>(null);
                //this.(null);
            }
            return result;
        }

        public List<TElement> translate<TElement>(IDataReader reader, string entitySetName, MergeOption mergeOption)
        {
            List<TElement> result;
            try
            {
                using (ObjectResult<TElement> objectResult = this.objectContext.Translate<TElement>((DbDataReader)reader, entitySetName, mergeOption))
                {
                    result = objectResult.ToList<TElement>();
                }
            }
            finally
            {
                this.translate<TElement>(null);
            }
            return result;
        }

        protected virtual void initializeContext()
        {
            this.setDatabaseInitializer();
            //((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized += new ObjectMaterializedEventHandler(this.ObjectContextReader);
        }

        public void insertEntity<T>(T obj) where T : class
        {
            DbSet<T> dbSet = this.Set<T>();
            dbSet.Add(obj);
        }

        public void deleteEntity<T>(T obj) where T : class
        {
            DbEntityEntry<T> dbEntityEntry = base.Entry<T>(obj);
            DbSet<T> dbSet = this.Set<T>();
            if (dbEntityEntry.State == EntityState.Detached)
            {
                dbSet.Attach(dbEntityEntry.Entity);
            }
            dbSet.Remove(dbEntityEntry.Entity);
        }

        public void updateEntity<T>(T obj) where T : class
        {
            DbSet<T> dbSet = this.Set<T>();
            dbSet.Attach(obj);
            ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.ChangeObjectState(obj, EntityState.Modified);
        }

        public DateTime setUtcDateKind(DateTime value)
        {
            return DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        public DateTime? setUtcDateKind(DateTime? value)
        {
            if (!value.HasValue)
            {
                return value;
            }
            return new DateTime?(DateTime.SpecifyKind(value.Value, DateTimeKind.Utc));
        }


        private void ObjectContextReader(object sender, ObjectMaterializedEventArgs args)
        {
            IEntity entity = args.Entity as IEntity;
            if (entity != null)
            {
                entity.onMaterialized(this);
            }
        }
        #endregion
    }
}
