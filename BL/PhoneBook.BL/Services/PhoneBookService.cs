using PhoneBook.BL.Interfaces;
using PhoneBook.DL;
using PhoneBook.DL.Interfaces;
using PhoneBook.ML;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BL.Services
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IPhoneBookRepository _phoneBookRepository = null;
        private readonly IEntryRepository _entryRepository = null;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="phoneBookRepository"></param>
        /// <param name="entryRepository"></param>
        public PhoneBookService(IPhoneBookRepository phoneBookRepository, IEntryRepository entryRepository)
        {
            _phoneBookRepository = phoneBookRepository ?? throw new ArgumentNullException(nameof(phoneBookRepository));
            _entryRepository = entryRepository ?? throw new ArgumentNullException(nameof(entryRepository));
        }
        /// <summary>
        /// Method to add an entry to the database
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public async Task<Entry> AddEntryAsync(Entry entry)
        {
            var result = await _entryRepository.AddAsync(entry);

            await _entryRepository.SaveChangesAsync();

            return result;
        }

        /// <summary>
        /// Method to create phonebook
        /// </summary>
        /// <param name="phoneBook"></param>
        /// <returns></returns>
        public async Task<ML.PhoneBook> CreatePhoneBookAsync(ML.PhoneBook phoneBook)
        {
            var result = await _phoneBookRepository.AddAsync(phoneBook);

            await _phoneBookRepository.SaveChangesAsync();

            return result;
        }

        /// <summary>
        /// Method to get phonebook by user Id async
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ML.PhoneBook> GetPhoneBookByUserIdAsync(int userId)
        {
            return await _phoneBookRepository.GetPhoneBookByUserIdAsync(userId);
        }

        /// <summary>
        /// Method to check if phonebook entry already exists
        /// </summary>
        /// <param name="phoneBookId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<bool> PhoneBookEntryExistsAsync(int phoneBookId, string name)
        {
            return (await _entryRepository.GetByNameAsync(name) != null);
        }

        /// <summary>
        /// Method to check if a phonebook already exists
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<bool> PhoneBookExistsAsync(string name)
        {
            return (await _phoneBookRepository.GetByNameAsync(name) != null);
        }

        /// <summary>
        /// Method to search entries
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public async Task<List<Entry>> SearchAsync(string searchText)
        {
            return await _entryRepository.GetAsync(entry => entry.Name.Equals(searchText) || entry.PhoneNumber.Equals(searchText));
        }

        /// <summary>
        /// Method to search entries
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public async Task<List<Entry>> SearchEntriesForPhoneBookAsync(int phoneBookId, string searchText)
        {
            return await _entryRepository.GetAsync(
                entry => entry.PhoneBookId == phoneBookId 
                && (entry.Name.Equals(searchText) || entry.PhoneNumber.Equals(searchText))
                );
        }


    }
}
