using AiGenericPostTool.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AiGenericPostTool.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Ben trong contructor
            // Goi ham init Db
            // Luu y: Khi tao lan dau database (lan dau tien migration khi doi dATABASE/ release he thong...
            // Comment cai dong Init Db

            //Sau khi migration xong => Mo lai comment do

            DataInit.InitData(this);
        }

        //Tao ra cac DbSet

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Prompt> Prompts { get; set; }
        public DbSet<History> Histories { get; set; }

    }
}