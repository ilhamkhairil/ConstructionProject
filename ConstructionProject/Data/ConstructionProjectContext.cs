using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConstructionProject.Model;

namespace ConstructionProject.Data
{
    public class ConstructionProjectContext : DbContext
    {
        public ConstructionProjectContext (DbContextOptions<ConstructionProjectContext> options)
            : base(options)
        {
        }

        public DbSet<ConstructionProject.Model.ProjectModel> ProjectModel { get; set; } = default!;
    }
}
