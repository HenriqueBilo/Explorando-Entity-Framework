using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.LastUpdateDate)
                .IsRequired() //NOT NULL
                .HasColumnName("LastUpdateDate")
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValueSql("GETDATE()"); //Função do SqlServer
                //.HasDefaultValue(DateTime.Now.ToUniversalTime());

            builder.HasIndex(x => x.Slug, "IX_Post_Slug")
                .IsUnique();

            // Relacionamentos

            // Um para muitos
            builder.HasOne(x => x.Author)
                .WithMany(x => x.Posts) //Post tem um Autor mas um Autor tem muitos posts
                .HasConstraintName("FK_Post_Author")
                .OnDelete(DeleteBehavior.Cascade); //Quando exclui um post, exclui o autor 

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Posts) //Post tem um Autor mas um Autor tem muitos posts
                .HasConstraintName("FK_Post_Category")
                .OnDelete(DeleteBehavior.Cascade); //Quando exclui um post, exclui o autor 

            // Muitos para muitos
            builder.HasMany(x => x.Tags)
                .WithMany(x => x.Posts)
                .UsingEntity<Dictionary<string, object>>(   //Gera uma terceira tabela fazendo a relação de tag e post
                    "PostTag",  //Nome Tabela
                    post => post.HasOne<Tag>()
                        .WithMany()
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_PostTag_PostId")
                        .OnDelete(DeleteBehavior.Cascade),
                    tag => tag.HasOne<Post>()
                        .WithMany()
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK_PostTag_TagId")
                        .OnDelete(DeleteBehavior.Cascade)
               );
        }
    }
}
