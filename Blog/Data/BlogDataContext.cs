using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
        //Obs: DataContext é o banco em memória
        public DbSet<Category> Categories { get; set; } //Representa a tabela de categorias
    }
}