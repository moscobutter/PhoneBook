using Microsoft.AspNetCore.Mvc;
using PhoneBook.ML.Base;
using PhoneBook.ML.Metadata;

namespace PhoneBook.ML
{
    [ModelMetadataType(typeof(EntryMetadata))]
    public class Entry: BaseClass
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneBookId { get; set; }
        public PhoneBook PhoneBook { get; set; }
    }
}
