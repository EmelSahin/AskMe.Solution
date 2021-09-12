using AskMe.Entities.Model;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace AskMe.DataAccessLayer.Concrete.EntityFramework.Context
{
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
