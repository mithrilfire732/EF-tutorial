﻿using EF_tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_tutorial.Controllers
{
    public class StudentsController
    {
        private readonly EdDbContext _context;

        public StudentsController()
        {
            _context = new EdDbContext();
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        } 

        public Student GetByPk(int Id)
        {
            return _context.Students.Find(Id);
        }

        public bool Create(Student students)
        {
            students.Id = 0;
            _context.Students.Add(students);
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected != 1)
            {
                throw new Exception("Create failed.");
            }
            return true;
        }

        public bool Change(int Id, Student student)
        {
            if(Id != student.Id)
            {
                throw new Exception("Id's must match.");
            }
            _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected != 1)
            {
                throw new Exception("Change failed.");
            }return false;
        }

        public bool Remove(int Id)
        {
            var student = _context.Students.Find(Id);
            if(student == null)
            {
                return false;
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
            return true;
        }
    }
}
