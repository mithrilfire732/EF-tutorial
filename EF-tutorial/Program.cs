using EF_tutorial.Models;
using System;
using System.Linq;

namespace EF_tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var _context = new EdDbContext();
            var majors = _context.Majors.ToList();
            foreach (var m in majors)
            {
                Console.WriteLine($"{m.Description}");
            }
        }
    }
}
