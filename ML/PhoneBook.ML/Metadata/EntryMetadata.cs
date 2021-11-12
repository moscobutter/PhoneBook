using System.ComponentModel.DataAnnotations;

namespace PhoneBook.ML.Metadata
{
    public class EntryMetadata
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
