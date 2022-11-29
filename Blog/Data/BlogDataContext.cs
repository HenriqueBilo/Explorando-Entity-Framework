using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
        //Obs: DataContext � o banco em mem�ria
        public DbSet<Category> Categories { get; set; } //Representa a tabela de categorias
        public DbSet<Post> Posts { get; set; }
        //public DbSet<PostTag> PostTags { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<UserRole> UsersRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=DESKTOP-3SM81VU;Initial Catalog=Blog;Integrated Security=True;Trusted_Connection=True; TrustServerCertificate=True;");
            options.LogTo(Console.WriteLine); //Para ver as querys que est�o sendo executadas
        }


    }
}