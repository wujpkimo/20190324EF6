using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ConsoleApp1.Models
{
    partial class ContosoUniversity190324Entities : DbContext
    {
        public override int SaveChanges()
        {
            var entries = this.ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(new { ModifyOn = DateTime.Now });
                        break;

                    default:
                        break;
                }
            }

            return base.SaveChanges();
        }
    }
}