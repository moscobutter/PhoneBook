using Microsoft.EntityFrameworkCore;
using PhoneBook.DL.Base;
using PhoneBook.DL.Interfaces;
using PhoneBook.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DL
{
    public class EntryRepository : IEntryRepository
    {
        private readonly DatabaseContext _db = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="db"></param>
        public EntryRepository(DatabaseContext db) 
        {
            _db = db ?? throw new ArgumentNullException("Failed to connect to the database");
        }

        /// <summary>
        /// Method to add an entry
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<Entry> AddAsync(Entry obj)
        {
            await _db.Entries.AddAsync(obj);

            return obj;
        }

        public async Task DeleteAsync(int Id)
        {
            var objToDelete = await _db.Entries.FindAsync(Id);

            if(objToDelete != null)
            {
                objToDelete.IsDeleted = true;
                objToDelete.EditedDatestamp = DateTime.Now;

                _db.Entry(objToDelete).State = EntityState.Modified;
            }
        }

        public async Task<List<Entry>> GetAsync(Expression<Func<Entry, bool>> filter, int pageNum = 1, int pageSize = 100)
        {
            return await _db.Entries
                .Where(filter)
                .Skip(pageNum)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Entry> GetByIdAsync(int Id)
        {
            return await _db.Entries.FindAsync(Id);
        }

        public async Task<Entry> GetByNameAsync(string name)
        {
            return await _db.Entries
                .Where(entry => entry.Name.Equals(name))
                .FirstOrDefaultAsync();
        }

        public async Task<Entry> GetEntryForPhoneBookAsync(int phoneBookId, string name)
        {
            return await _db.Entries
                .Where(entry => entry.PhoneBookId == phoneBookId && entry.Name.Equals(name))
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return ((await _db.SaveChangesAsync()) > 0);
        }

        public void Update(Entry obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
        }
    }
}
