using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paul.EntityFramework;
using ProformaInvoice.Users;

namespace ProformaInvoice.Core.Data
{
    public class ProformaContext : DbContextBase
    {
        #region  Constructor

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ProformaContext()
            : base("DbProformaInvoice")
        {

        }

       public ProformaContext (string nameOrConnectionString)
			: base(nameOrConnectionString)
		{
		}

		public ProformaContext (DbConnection existingConnection)
			: base(existingConnection)
		{
		}

        public ProformaContext(ObjectContext existingConnection)
			: base(existingConnection)
		{
		}
        #endregion

        #region Protected Methods
        protected override void setDatabaseInitializer()
        {
            Database.SetInitializer<ProformaContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region Public Properties

        public DbSet<User> user { get; set; }

        public DbSet<Role> roles { get; set; }

        public DbSet<UserRole> userRoles { get; set; }

        #endregion

        //public void get(object sender ,ObjectMaterializedEventArgs args)
        //{
        //    IEntity entity = args.Entity as IEntity;
        //}

    }
}
