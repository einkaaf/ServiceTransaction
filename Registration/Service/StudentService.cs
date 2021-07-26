using Registration.Entity;
using Registration.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Service
{
    public class StudentService
    {
        private readonly StudentRepo repo;

        public StudentService(StudentRepo repo)
        {
            this.repo = repo;
        }

        public bool Register(Student student)
        {
            return repo.Insert(student);
            
        }
    }
}
