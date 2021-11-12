using PhoneBook.DL.Base;
using System;
using System.Collections.Generic;
using System.Text;
using ML = PhoneBook.ML;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using PhoneBook.DL.Interfaces;

namespace PhoneBook.DL
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private readonly DatabaseContext _db = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="db"></param>
        public PhoneBookRepository(DatabaseContext db)
        {
            _db = db ?? throw new ArgumentNullException("Failed to connect to the database");
        }

        /// <summary>
        /// Method to add PhoneBook record
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<ML.PhoneBook> AddAsync(ML.PhoneBook obj)
        {
            await _db.PhoneBooks.AddAsync(obj);

            return obj;
        }

        /// <summary>
        /// Method to delete PhoneBook record
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int Id)
        {
            var objToDelete = await _db.PhoneBooks.FindAsync(Id);

            if(objToDelete != null)
            {
                objToDelete.IsDeleted = true;

                _db.Entry(objToDelete).State = EntityState.Modified;
            }
        }

        /// <summary>
        /// Method to filter by custom filters
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<ML.PhoneBook>> GetAsync(Expression<Func<ML.PhoneBook, bool>> filter, int pageNum = 1, int pageSize = 100)
        {
            return await _db.PhoneBooks
                .Where(filter)
                .Skip(pageNum)
                .Take(pageSize)
                .OrderByDescending( order => order.Id)
                .ToListAsync();
        }

        /// <summary>
        /// Method to get phone book by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<ML.PhoneBook> GetByIdAsync(int Id)
        {
            return await _db.PhoneBooks.FindAsync(Id);
        }

        /// <summary>
        /// Method to update phonebook record
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public void Update(ML.PhoneBook obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
        }

        /// <summary>
        /// Save changes to the database
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveChangesAsync()
        {
            return ((await _db.SaveChangesAsync()) > 0);
        }

        /// <summary>
        /// Method to get book by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<ML.PhoneBook> GetByNameAsync(string name)
        {
            return await _db.PhoneBooks
                .Where(book => book.Name.Equals(name))
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Method to get phonebook for user by Id async
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ML.PhoneBook> GetPhoneBookByUserIdAsync(int userId)
        {
            return await _db.PhoneBooks
                .Include(book => book.Entries)
                .FirstOrDefaultAsync(book => book.IsDeleted == false && book.OwnerId == userId);
        }
    }
}
