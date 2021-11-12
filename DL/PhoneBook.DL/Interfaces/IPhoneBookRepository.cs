using PhoneBook.DL.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DL.Interfaces
{
    public interface IPhoneBookRepository: IBaseRepository<ML.PhoneBook>
    {
        Task<ML.PhoneBook> GetPhoneBookByUserIdAsync(int userId);
    }
}
