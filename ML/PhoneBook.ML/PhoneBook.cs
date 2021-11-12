using PhoneBook.ML.Base;
using PhoneBook.ML.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.ML
{
    [ModelMetadataType(typeof(PhoneBookMetadata))]
    public class PhoneBook: BaseClass
    {
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public List<Entry> Entries { get; set; }
    }
}
