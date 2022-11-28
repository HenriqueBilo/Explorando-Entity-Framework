using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
        //Obs: DataContext � o banco em mem�ria
        public DbSet<Category> Categories { get; set; } //Representa a tabela de categorias
    }
}