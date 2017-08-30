using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDev.Models
{
    public class Topic
    {
        public Topic() { }
        public Topic(string name, string word, User author)
        {
            this.Name = name;
            this.Word = word;
            this.Author = author;
        }

        [Key]
        public int TopicId { get; set; }

        public string Name { get; set; }

        public string Word { get; set; }

        [ForeignKey("Author")]
        public string UserId { get; set; }

        public virtual User Author { get; set; }
    }
}
