using PhoneBook.DL.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DL.Interfaces
{
    public interface IEntryRepository: IBaseRepository<ML.Entry>
    {
        Task<ML.Entry> GetEntryForPhoneBookAsync(int phoneBookId, string name);
    }
}
