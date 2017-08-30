using System.ComponentModel.DataAnnotations;

namespace WebDev.Models
{
    public class Word
    {
        public Word()
        {

        }

        public Word(string value)
        {
            this.Value = value;
        }

        [Key]
        public int WordId { get; set; }

        public string Value { get; set; }
    }
}
