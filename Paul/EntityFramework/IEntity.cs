using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul.EntityFramework
{
   public  interface  IEntity
    {
       void onMaterialized(DbContextBase context);
    }
}
