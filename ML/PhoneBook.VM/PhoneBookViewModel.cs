using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.VM
{
    public class PhoneBookViewModel: BaseViewModel
    {
        public string Name { get; set; }

        public List<EntryViewModel> Entries { get; set; }
    }
}
