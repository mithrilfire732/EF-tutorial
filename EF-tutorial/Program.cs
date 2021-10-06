using EF_tutorial.Controllers;
using System;
using EF_tutorial.Models;
using System.Collections.Generic;

namespace EF_tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentsCtrl = new StudentsController();
            var majorsCtrl = new MajorsController();

            //var NewMajor = new Major()
            //{
            //    Id = 0,
            //    Code = "ECON",
            //    Description = "Economics",
            //    MinSat = 1200
            //};

            //try
            //{
            //    var ec = majorsCtrl.Create(NewMajor);
            //    if (!ec)
            //    {
            //        throw new Exception("Create failed");
            //    }

            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Exception occured: {ex.Message}");
            //}

            var NewStudent = new Student()
            {
                Id = 0, Firstname = "Alexander", Lastname = "Kidd", StateCode = "OH", Sat = 1375, Gpa = 3.85m, MajorId = majorsCtrl.GetByCode("ECON").Id, Major = null
            };
            try
            {


                var st = studentsCtrl.Create(NewStudent);
                if (!st)
                {
                    Console.WriteLine("Create Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occured: {ex.Message}");
            }
            var students = studentsCtrl.GetAll();
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Id} | {s.Firstname} {s.Lastname} | {s.Major.Id}");
            }


        }
        
        static void X()
        {
            var majorsCtrl = new MajorsController();

            var NewMajor = new Major()
            {
                Id = 0,
                Code = "CLMS",
                Description = "Music",
                MinSat = 1595
            };
            try
            {


                var rp = majorsCtrl.Create(NewMajor);
                if (!rp)
                {
                    Console.WriteLine("Create Failed");
                }
            }catch(Exception ex)
            {
                Console.WriteLine($"Exception occured: {ex.Message}");
            }

            var major = majorsCtrl.GetByCode("ACCT");
            Console.WriteLine(major);
            
            major = majorsCtrl.GetByPk(2);
            Console.WriteLine($"{major.Description}");
            
            NewMajor.Description = "Classical Music";
            majorsCtrl.Change(NewMajor.Id, NewMajor);

            var rc = majorsCtrl.Remove(NewMajor.Id);
            if (!rc)
            {
                Console.WriteLine("Remove failed");
            }

            var majors = majorsCtrl.GetAll();
            foreach (var m in majors)
            {
                Console.WriteLine(m);
            }
            

        }
    }
}
