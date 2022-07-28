using System;
using Microsoft.EntityFrameworkCore;

namespace crud.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options) {  }
        
        public DbSet<crud1> cruds { get; set; }
    }
}
