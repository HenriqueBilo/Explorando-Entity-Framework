using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("Post")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Sequence
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        [ForeignKey("CategoryId")] //Classe/Propriedade(Campo) --> Category/Id
        public int CategoryId { get; set; }
        public Category Category { get; set; } //Se eu fizer JOIN, posso pegar todos dados de Categoria aqui. Isso se chama propriedade de navegação

        [ForeignKey("AuthorId")] //Classe/Propriedade(Campo) --> Author/Id
        public int AuthorId { get; set; }
        public User Author { get; set; }
    }
}