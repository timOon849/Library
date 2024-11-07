using Library.Tables;
using Microsoft.EntityFrameworkCore;

namespace Library.DBContext
{
    public class DBCon : DbContext
    {
        public DBCon(DbContextOptions options) : base(options) 
        { 
        
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<Readers> Readers { get; set; }
        public DbSet<Zhanr> Zhanrs { get; set; }
        public DbSet<RentHistory> RentHistory { get; set; }
    }
}
