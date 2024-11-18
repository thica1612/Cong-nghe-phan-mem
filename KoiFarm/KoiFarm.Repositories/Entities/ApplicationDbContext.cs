//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml;

//namespace KoiFarm.Repositories.Entities
//{
//    public class ApplicationDbContext : DbContext
//    {
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//            : base(options)
//        {
//        }

//        public DbSet<SellConsignment> SellConsignments { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);
//            // Thêm các configuration khác nếu cần
//        }
//    }
//}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarm.Repositories.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet cho SellConsignment
        public DbSet<SellConsignment> SellConsignments { get; set; }

        // Thêm DbSet cho FeedConsignment
        public DbSet<FeedConsignment> FeedConsignments { get; set; }

        // Phương thức OnModelCreating để cấu hình các thực thể
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Bạn có thể thêm các cấu hình tùy chỉnh tại đây nếu cần
            // Ví dụ:
            // modelBuilder.Entity<FeedConsignment>().ToTable("FeedConsignmentTable");
        }
    }
}



