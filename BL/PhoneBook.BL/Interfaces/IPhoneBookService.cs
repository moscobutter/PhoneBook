using System.Collections.Generic;
using System.Threading.Tasks;
namespace PhoneBook.BL.Interfaces
{
    public interface IPhoneBookService
    {
        Task<ML.PhoneBook> CreatePhoneBookAsync(ML.PhoneBook phoneBook);
        Task<ML.Entry> AddEntryAsync(ML.Entry entry);
        Task<List<ML.Entry>> SearchAsync(string searchText);
        Task<List<ML.Entry>> SearchEntriesForPhoneBookAsync(int phoneBookId, string searchText);
        Task<bool> PhoneBookExistsAsync(string name);
        Task<bool> PhoneBookEntryExistsAsync(int phoneBookId, string name);
        Task<ML.PhoneBook> GetPhoneBookByUserIdAsync(int userId);
    }
}
