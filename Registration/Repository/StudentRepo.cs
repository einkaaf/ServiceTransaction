using Registration.Entity;
using Registration.Repository.DBContext;
using System;

namespace Registration.Repository
{
    public class StudentRepo
    {
        private readonly AppDBContext db;

        public StudentRepo(AppDBContext db)
        {
            this.db = db;
        }
        public bool Insert(Student student)
        {
            try
            {
                db.students.Add(student);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
