using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDev.Models
{
    public class Topic
    {
        private ICollection<Word> words;

        public Topic()
        {
            this.words = new HashSet<Word>();
        }

        public Topic(string name, User author)
        {
            this.Name = name;
            this.Author = author;
        }

        [Key]
        public int TopicId { get; set; }

        public string Name { get; set; }
        
        [ForeignKey("Author")]
        public int UserId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Word> Words
        {
            get
            {
                return this.words;
            }

            set
            {
                this.words = value;
            }
        }
    }
}
