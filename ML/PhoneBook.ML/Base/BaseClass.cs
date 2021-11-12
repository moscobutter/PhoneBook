using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.ML.Base
{
    public abstract class BaseClass
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedById { get; set; }
        public int EditedById { get; set; }
        public DateTime CreatedDatestamp { get; set; }
        public DateTime EditedDatestamp { get; set; }
        public string LogReason { get; set; }

    }
}
