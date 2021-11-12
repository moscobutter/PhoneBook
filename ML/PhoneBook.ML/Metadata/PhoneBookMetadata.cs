using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneBook.ML.Metadata
{
    public class PhoneBookMetadata
    {
        [Required]
        public string Name { get; set; }
    }
}
