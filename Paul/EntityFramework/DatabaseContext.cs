using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data;
using System.Runtime.CompilerServices;

namespace Paul.EntityFramework
{
  public abstract class DatabaseContext :DbContext
  {
      #region Constructor
      protected DatabaseContext():base()
      {
      }
      protected DatabaseContext(DbCompiledModel model)
          : base(model)
      { }

      public DatabaseContext(string nameOrConnectionString)
          : base(nameOrConnectionString)
      { }

      public DatabaseContext(DbConnection existingConnection, bool contextOwnsConnection)
          : base(existingConnection, contextOwnsConnection)
      {  }

      public DatabaseContext(ObjectContext objectContext, bool dbContextOwnsObjectContext) 
          : base(objectContext, dbContextOwnsObjectContext) 
      { }

      public DatabaseContext(string nameOrConnectionString, DbCompiledModel model)
          :base(nameOrConnectionString,model)
      {}
      public DatabaseContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
         : base(existingConnection, model, contextOwnsConnection)
      { }

      #endregion

      #region Public Method


     // private IDataReader iDataReader=null;

      //public IDataReader currentReader
      //  {
      //      [CompilerGenerated]
      //      get
      //      {
      //          return this.iDataReader;
      //      }
      //  }

      protected abstract void setDatabaseInitializer();

	  protected virtual void initializeContext()
		{
			this.setDatabaseInitializer();
        //    ((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized += new ObjectMaterializedEventHandler(this.objectContext.ObjectMaterialized);
           // ((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized += new ObjectMaterializedEventHandler(this.setDatabaseInitializer);
		}



      public ObjectContext objectContext
      {
          get
          {
              return ((IObjectContextAdapter)this).ObjectContext;
          }
      }

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
          base.OnModelCreating(modelBuilder);
      }

        //private void GetDataReader (IDataReader  reader)
        //{
			
        //}


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

      //private  void ObjectMaterialized (object sender, ObjectMaterializedEventArgs args )
      //  { 
      //     //  var encryptedProperties  = sender.GetType().GetProperties().Where(p=>p.GetCustomAttributes(typeof(Encrypted),true).Any(a => p.PropertyType == typeof(String)));

      //      //IEntity entity = //e.Entity as IEntity;
      //      //if (entity != null)
      //      //{
      //      //    entity.onMaterialized(this);
      //      //}
      //IEntity entity=
      
      //  }

    

      #endregion

  }
}
