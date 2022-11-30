using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new BlogDataContext();

            //context.Users.Add(new User
            //{
            //    Name = "Henrique Bilo",
            //    Slug = "henriquebilo",
            //    Email = "bilo@balta.io",
            //    Bio = "Jogador caro",
            //    Image = "sem",
            //    PasswordHash = "534543543"
            //});

            var user = context.Users.FirstOrDefault(x => x.Id == 2);


            var post = new Post
            {
                Author = user,
                Body = "Meu artigo",
                Category = new Category
                {
                    Name = "Frontend",
                    Slug = "Froentend",
                },
                CreateDate = System.DateTime.Now,
                Slug = "meu-artigo",
                Summary = "Neste artigo vamos conferir...",
                Title = "Meu artigo",
            };

            context.Posts.Add(post);
            context.SaveChanges();
        }
    }
}