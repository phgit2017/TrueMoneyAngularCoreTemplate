using DataAccess.Database.CoreTemplate;
using DataAccess.Entities.Context.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Context
{
    public class CoreTemplateEntities : System.Data.Entity.DbContext, ICoreTemplateEntities
    {
        public CoreTemplateEntities()
            : base("name=CoreTemplateDBV3Entities")
        {
        }

        public virtual DbSet<ServerGuide> ServerGuides { get; set; }
        public virtual DbSet<ServerType> ServerTypes { get; set; }
    }
}
