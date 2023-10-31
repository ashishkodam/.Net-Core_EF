using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoItem.Repository
{
    using Microsoft.Extensions.Configuration;
    using TodoItem.Shared.Model;
    //public class TodoItemContext : DbContext
    //{
    //    public TodoItemContext(DbContextOptions<TodoItemContext> options)
    //        : base(options)
    //    {
    //    }
    //    protected override void OnConfiguring(DbContextOptionsBuilder options)
    //    {
    //        if (options.IsConfigured)
    //        {
    //            options.UseNpgsql("todoItem_Postgres_Db");
    //        }
    //    }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);
    //    }


    //    public DbSet<TodoItem> TodoItems { get; set; } = null!;
    //}


    public class TodoItemContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public TodoItemContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("todoItem_Postgres_Db"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<TodoItem> TodoItems { get; set; } = null!;
    }

}
