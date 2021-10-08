using EF_tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EF_tutorial.Controllers
{
    public class MajorsController
    {
        private readonly EdDbContext _context;           // difference between constant and readonly: readonly can be set only in constructor
        
        public MajorsController()
        {
            _context = new EdDbContext();
        }

        public async Task<List<Major>> GetAll()
        {
            return await _context.Majors.ToListAsync();
        }

        public async Task<Major> GetByPk(int Id)
        {
            return await _context.Majors.FindAsync(Id);
        }

        public Major GetByCode(string code)
        {
            return _context.Majors.SingleOrDefault(m => m.Code == code);
        }

        public bool Create(Major major) 
        {
            major.Id = 0;
            _context.Majors.Add(major);
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected != 1)
            {
                throw new Exception("Create failed");
            }
            return true;
        }

        public bool Change(int Id, Major major)
        {
            if(Id != major.Id)
            {
                throw new Exception("Ids don't match!");
            }
            // major.Updated = DateTime.Now();
            _context.Entry(major).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected!= 1)
            {
                throw new Exception("Create failed");
            }
            return true;
        }

        public bool Remove(int id)
        {
            var major = _context.Majors.Find(id);
            if(major == null)
            {
                return false;
            }
            _context.Majors.Remove(major);
            _context.SaveChanges();
            return true;
        }
    }
}
