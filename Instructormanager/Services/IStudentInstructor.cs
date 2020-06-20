using Instructormanager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instructormanager.Services
{
    public interface IStudentInstructor
    {
        public IEnumerable<Instructor> Instructors { get; }
        public void AddInstructor(Instructor instructor);
        public Instructor Delete(long Id);
        public Instructor GetInstructor(long Id);
        public void Update(Instructor instructor);
        public IQueryable<Instructor> Search(string option);
        
    }
}
