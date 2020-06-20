using Instructormanager.Data;
using Instructormanager.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instructormanager.Services
{
    public class StudentInstructorRepository : IStudentInstructor
    {
        //Injecting DataContext Dependency using constructor in jection
        private readonly DataContext _context;
        public StudentInstructorRepository(DataContext data) => _context = data;


        /* public IEnumerable<EmployeeModel> Employee => return _context.EmployeeTable; the Table in the Datacontext has been exposed*/

        public IEnumerable<Instructor> Instructors
        {
            get
            {
                return _context.InstructorTable;
            }

        }


        
        public void AddInstructor (Instructor instructor)
        {

            _context.InstructorTable.Add(instructor);
            _context.SaveChanges();

        }


        public Instructor Delete(long Id)
        {
            Instructor instructor = _context.InstructorTable.Find(Id);

            if (instructor != null)
            {
                _context.InstructorTable.Remove(instructor);
                _context.SaveChanges();
            }
            return instructor;
        }

        public Instructor GetInstructor(long Id)
        {
            return _context.InstructorTable.Find(Id);
        }

        public void Update(Instructor instructor)
        {
            _context.Update(instructor);
            _context.SaveChanges();
        }
         //[Authorize]
        public IQueryable<Instructor> Search(string option)
        {

            var temp = _context.InstructorTable.Where(T => T.Surname.Contains(option) || T.Othername.Contains(option) || T.Email.Contains(option) || T.Address.Contains(option));

            return temp;


        }
        
    }
}
